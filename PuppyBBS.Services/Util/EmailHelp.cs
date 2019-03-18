using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PuppyBBS.Services.Util
{

    public class EmailHelp
    {
        public static void Send(string template, string email, object templateval)
        {
            MailMessage myMail = new MailMessage();

            myMail.From = new MailAddress(ConstConfig.EMAIL);
            myMail.To.Add(new MailAddress(email));
            myMail.Subject = "C#发送Email";
            myMail.SubjectEncoding = Encoding.UTF8;

            myMail.Body = "this is a test email from QQ!";
            myMail.BodyEncoding = Encoding.UTF8;
            myMail.IsBodyHtml = true;

            //邮件推送的SMTP地址和端口
            SmtpClient smtp = new SmtpClient("smtpdm.aliyun.com", 25);
            foreach (var item in templateval.GetType().GetProperties())
            {
                //string txt = txt.Replace("{" + item.Name + "}", item.GetValue(templateval).ToString());
            }
            smtp.Credentials = new NetworkCredential(ConstConfig.EMAIL, ConstConfig.SECRET);

            smtp.Send(myMail);
        }

    }
}
