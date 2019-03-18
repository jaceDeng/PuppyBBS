using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
    public class CommentsModel
    {
        public CommentsModel()
        {
            PraiseID = new Int64[0];
        }
        public Int64 CID { get; set; }

        /// <summary>
        /// 所属帖子
        /// </summary>                       

        public Int64 TID { get; set; }

        /// <summary>
        /// 回复人
        /// </summary>                       

        public Int64 UID { get; set; }

        /// <summary>
        /// 正文内容
        /// </summary>                       

        public String Content { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>                       

        public DateTime ReplyTime { get; set; }

        /// <summary>
        /// 赞
        /// </summary>                       

        public Int32 Praise { get; set; }

        /// <summary>
        /// 回复人
        /// </summary>                       

        public Int64[] ReplyID { get; set; }


        public Int64[] PraiseID { get; set; }
        /// <summary>
        /// 作者信息
        /// </summary>
        public UserModel Author { get; set; }
    }
}
