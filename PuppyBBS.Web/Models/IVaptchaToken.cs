using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
   public interface IVaptchaToken
    {
        /// <summary>
        /// 人机校验
        /// </summary>
        String vaptcha_token { get; set; }
        string scene { get; }
    }
}
