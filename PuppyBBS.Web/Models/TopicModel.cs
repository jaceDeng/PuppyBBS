using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
    public class TopicModel : IVaptchaToken
    {
        public TopicModel()
        {
            this.CreateTime = DateTime.Now;
            this.Lastreply = null;
        }
        /// <summary>
        /// 生成id
        /// </summary>                       

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
        /// 最后回复人id
        /// </summary>                       

        public Int64 RuID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>                       

        public String Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>                       

        public String Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>                       

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新评论时间
        /// </summary>                       

        public DateTime? Lastreply { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>                       

        public Int32 Views { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>                       

        public Int32 Comments { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>                       

        public Boolean IsTop { get; set; }

        /// <summary>
        /// 是否邮件通知楼主
        /// </summary>                       

        public Boolean EnableAlert { get; set; }

        /// <summary>
        /// 是否加精
        /// </summary>                       

        public Boolean IsSplendIdness { get; set; }

        /// <summary>
        /// 采纳的答案
        /// </summary>                       

        public Int64 AcceptanceCID { get; set; }

        /// <summary>
        /// 作者信息
        /// </summary>
        public UserModel Author { get; set; }

        /// <summary>
        /// 回帖
        /// </summary>
        public NPoco.Page<CommentsModel> Comment { get; set; }

        public string vaptcha_token { get; set; }

        public string scene => "03";
    }
}
