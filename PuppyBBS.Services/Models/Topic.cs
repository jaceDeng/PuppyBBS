using System;
namespace PuppyBBS.Services.Models
{
    /// <summary>
    ///tb_topic 
    /// </summary>      
    [NPoco.TableName("tb_topic")]
    [NPoco.PrimaryKey("tid", AutoIncrement = false)]

    public class Topic
    {

        /// <summary>
        /// 生成id
        /// </summary>                       
        [NPoco.Column("tid")]
        public Int64 TID { get; set; }

        /// <summary>
        /// 所属论坛
        /// </summary>                       
        [NPoco.Column("fid")]
        public Int32 FID { get; set; }

        /// <summary>
        /// 发帖人
        /// </summary>                       
        [NPoco.Column("uid")]
        public Int64 UID { get; set; }

        /// <summary>
        /// 最后回复人id
        /// </summary>                       
        [NPoco.Column("ruid")]
        public Int64 RuID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>                       
        [NPoco.Column("title")]
        public String Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>                       
        [NPoco.Column("content")]
        public String Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>                       
        [NPoco.Column("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最新评论时间
        /// </summary>                       
        [NPoco.Column("lastreply")]
        public DateTime? Lastreply { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>                       
        [NPoco.Column("views")]
        public Int32 Views { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>                       
        [NPoco.Column("comments")]
        public Int32 Comments { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>                       
        [NPoco.Column("is_top")]
        public Boolean IsTop { get; set; }

        /// <summary>
        /// 是否邮件通知楼主
        /// </summary>                       
        [NPoco.Column("enable_alert")]
        public Boolean EnableAlert { get; set; }

        /// <summary>
        /// 是否加精
        /// </summary>                       
        [NPoco.Column("is_splendidness")]
        public Boolean IsSplendIdness { get; set; }

        /// <summary>
        /// 采纳的答案
        /// </summary>                       
        [NPoco.Column("acceptance_cid")]
        public Int64 AcceptanceCID { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>                       
        [NPoco.Column("deleted ")]
        public Boolean Deleted { get; set; }

    }
}

