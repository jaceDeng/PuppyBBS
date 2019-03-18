using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PuppyBBS.Services.Algorithm
{
    public class MD5
    {

        public static string ComputeHash(string txt)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                var buffer = provider.ComputeHash(Encoding.UTF8.GetBytes(txt));
                StringBuilder sb = new StringBuilder(buffer.Length * 2);
                foreach (var item in buffer)
                {
                    sb.AppendFormat("{0:X2}", item);
                }
                return sb.ToString();
                //return Convert.ToBase64String(buffer);
            }
        }
    }
}
