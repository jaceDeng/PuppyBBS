using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
    public class UserModel
    {
        /// <summary>
        /// 主键
        /// </summary>                       

        public Int64 UID { get; set; }

        /// <summary>
        /// 群组
        /// </summary>                       

        public Int32 GID { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>                       

        public String NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>                       

        public String Gender { get; set; }


        private string avatar = null;

        /// <summary>
        /// 头像
        /// </summary>                       

        public String Avatar
        {
            get
            {
                if (avatar == null)
                    return "/res/images/avatar/default.png";
                return avatar;
            }
            set
            {
                avatar = value;
            }
        }



        /// <summary>
        /// 邮件
        /// </summary>                       
        [NPoco.Column("email")]
        public String Email { get; set; }

        /// <summary>
        /// 邮箱是否激活
        /// </summary>                       
        [NPoco.Column("email_activate")]
        public Boolean EmailActivate { get; set; }

        /// <summary>
        /// 手机实名
        /// </summary>                       
        [NPoco.Column("phone")]
        public String Phone { get; set; }

        /// <summary>
        /// 是否实名认证
        /// </summary>                       
        [NPoco.Column("auth")]
        public Boolean Auth { get; set; }

        /// <summary>
        /// 实名信息
        /// </summary>                       
        [NPoco.Column("auth_info")]
        public String AuthInfo { get; set; }

        /// <summary>
        /// 经验值
        /// </summary>                       
        [NPoco.Column("experience")]
        public Int32 Experience { get; set; }

        /// <summary>
        /// 城市
        /// </summary>                       
        [NPoco.Column("city")]
        public String City { get; set; }

        /// <summary>
        /// 个性签名信息
        /// </summary>                       
        [NPoco.Column("slogon")]
        public String Slogon { get; set; }

        /// <summary>
        /// 状态
        /// </summary>                       
        [NPoco.Column("status")]
        public String Status { get; set; }

        /// <summary>
        /// ip地址和设备信息
        /// </summary>                       
        [NPoco.Column("create_by")]
        public String CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>                       
        [NPoco.Column("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// ip地址和设备信息
        /// </summary>                       
        [NPoco.Column("update_by")]
        public String UpdateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>                       
        [NPoco.Column("update_date")]
        public DateTime UpdateDate { get; set; }



        /// <summary>
        /// 软删除
        /// </summary>                       
        [NPoco.Column("deleted ")]
        public Boolean Deleted { get; set; }

    }
}
