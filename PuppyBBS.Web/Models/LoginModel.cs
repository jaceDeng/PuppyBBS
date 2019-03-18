using System;

namespace PuppyBBS.Web.Models
{
    public class LoginModel : IVaptchaToken
    {

        /// <summary>
        /// 人机校验
        /// </summary>
        public String vaptcha_token { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        public String password { get; set; }



        /// <summary>
        /// 邮件
        /// </summary>  
        public String email { get; set; }
        public string scene { get { return "01"; } }
    }
}