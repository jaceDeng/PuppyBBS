using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using SkiaSharp;

namespace PuppyBBS.Web.Controllers
{
    /// <summary>
    /// 验证码检查
    /// </summary>
    public class CaptchaController : Controller
    {

        /// <summary>
        /// 正弦曲线Wave扭曲图片
        /// </summary>
        /// <param name="srcBmp">图片</param>
        /// <param name="bXDir">如果扭曲则选择为True</param>
        /// <param name="dMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
        /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
        /// <returns></returns>
        public Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);
            double PI2 = 6.283185307179586476925286766559;
            // 将位图背景填充为白色
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();

            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);

                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }
            return destBmp;
        }



        /// <summary>
        /// 验证码
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public ActionResult Code()
        {
            int w = 114, h = 38;
            int codeW = 100;
            int codeH = 38;

            if (!(h > 300 || h <= 0 || w > 600 || w <= 0))
            {
                codeW = w;
                codeH = h;
            }
            int fontSize = 26;
            string chkCode = string.Empty;
            //颜色列表，用于验证码、噪线、噪点 
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            //字体列表，用于验证码 
            string[] font = { "Times New Roman", "Verdana", "Arial", "Gungsuh", "Impact" };
            //验证码的字符集，去掉了一些容易混淆的字符 
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            Random rnd = new Random();
            //生成验证码字符串 
            for (int i = 0; i < 4; i++)
            {
                chkCode += character[rnd.Next(character.Length)];
            }
            //写入Session
            //  SessionHelper.SetObject("ValidateCode", chkCode);
            //创建画布
            Bitmap bmpTmp = new Bitmap(100, 40);
            Graphics g = Graphics.FromImage(bmpTmp);
            g.Clear(Color.White);
            Color clFont = color[rnd.Next(color.Length)];
            //画验证码字符串 
            for (int i = 0; i < chkCode.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, fontSize);
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clFont), (float)i * 18 + 2, (float)0);
            }
            //扭曲
            bmpTmp = TwistImage(bmpTmp, true, 4, 1.6);
            Bitmap bmp = new Bitmap(bmpTmp, codeW, codeH);
            // bmpTmp.Save(bmp);
            //清除该页输出缓存，设置该页无缓存 
            //Response.Buffer = true;
            //Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0);
            //Response.Expires = 0;
            Response.Headers.Add("CacheControl", "no-cache");
            Response.Headers.Add("Pragma", "No-Cache");
            //将验证码图片写入内存流，并将其以 "image/Png" 格式输出 
            MemoryStream ms = new MemoryStream();
            try
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return File(ms.ToArray(), @"image/Png");
            }
            finally
            {
                //显式释放资源 
                bmpTmp.Dispose();
                bmp.Dispose();
                g.Dispose();
            }
        }
    }
}
