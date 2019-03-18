using System;
namespace PuppyBBS.Services.Models
{
    /// <summary>
    ///tb_comments 
    /// </summary>      
    [NPoco.TableName("tb_comments")]
    [NPoco.PrimaryKey("cid", AutoIncrement = false)]

    public class Comments
    {

        /// <summary>
        /// 主键
        /// </summary>                       
        [NPoco.Column("cid")]
        public Int64 CID { get; set; }

        /// <summary>
        /// 所属帖子
        /// </summary>                       
        [NPoco.Column("tid")]
        public Int64 TID { get; set; }

        /// <summary>
        /// 回复人
        /// </summary>                       
        [NPoco.Column("uid")]
        public Int64 UID { get; set; }

        /// <summary>
        /// 正文内容
        /// </summary>                       
        [NPoco.Column("content")]
        public String Content { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>                       
        [NPoco.Column("reply_time")]
        public DateTime ReplyTime { get; set; }

        /// <summary>
        /// 赞
        /// </summary>                       
        [NPoco.Column("praise")]
        public Int32 Praise { get; set; }

        /// <summary>
        /// 回复人
        /// </summary>                       
        [NPoco.Column("reply_id")]
        public Int64[] ReplyID { get; set; }

        /// <summary>
        /// 点赞人数
        /// </summary>                       
        [NPoco.Column("praise_id")]
        public Int64[] PraiseID { get; set; }


        [NPoco.ResultColumn]
        /// <summary>
        /// 回复人
        /// </summary>
        public Users Author { get; set; }
    }
}

