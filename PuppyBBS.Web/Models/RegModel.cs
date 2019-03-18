using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
    public class RegModel: IVaptchaToken
    {
        /// <summary>
        /// 人机校验
        /// </summary>
        public String vaptcha_token { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>  
        public String nickname { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String password { get; set; }

        public string scene { get { return "02"; } }

    
        /// <summary>
        /// 邮件
        /// </summary>  
        public String email { get; set; }

 


 

    }
}
