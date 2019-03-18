using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
    public class TopicReplayModel : IVaptchaToken
    {
        public TopicReplayModel()
        {
            this.Replytime = DateTime.Now; 
        }
        /// <summary>
        /// 生成id
        /// </summary>                       
        public Int64 CID { get; set; }


        public Int64 TID { get; set; }

        /// <summary>
        /// 所属论坛
        /// </summary>                       

        public Int32 FID { get; set; }

        /// <summary>
        /// 发帖人
        /// </summary>                       

        public Int64 UID { get; set; }
 
 

        /// <summary>
        /// 正文
        /// </summary>                       

        public String Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>                       

        public DateTime Replytime { get; set; }

       
  
        public string vaptcha_token { get; set; }

        public string scene => "03";
    }
}
