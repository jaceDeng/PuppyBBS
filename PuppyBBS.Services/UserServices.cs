using System;
using System.Collections.Generic;
using System.Text;
using PuppyBBS.Services.Models;
using PuppyBBS.Services.Util;

namespace PuppyBBS.Services
{
    /// <summary>
    /// 用户基础服务
    /// </summary>
    public class UserServices : PuppyService<Models.Users>
    {
        private Dictionary<object, Models.Users> UsersCache = null;
        /// <summary>
        /// 将影响
        /// </summary>
        public void BeginCache()
        {
            UsersCache = new Dictionary<object, Users>();
        }

        public void EndCache()
        {
            UsersCache = null;
        }

        public UserServices(string conn) : base(conn)
        {

        }
        public override Models.Users SingleOrDefaultById(object primaryKey)
        {
            //针对开启局部缓存 方便大量相同用户信息的时候减少请求
            if (UsersCache != null && UsersCache.ContainsKey(primaryKey))
            {
                return UsersCache[primaryKey];
            }
            else if (UsersCache != null)
            {
                UsersCache.Add(primaryKey, base.SingleOrDefaultById(primaryKey));
                return UsersCache[primaryKey];
            }
            return base.SingleOrDefaultById(primaryKey);
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public string Reg(Models.Users user)
        {
            if (Count(x => x.Email == user.Email) > 0)
            {
                return ERROR.EMAIL_EXIST;
            }
            user.UID = SnowFlake.CreateId();
            user.GID = 0;
            user.CreateDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            user.Status = "";
            user.Salt = RandomUtil.Random(6);
            user.EmailActivate = false;
            user.Password = Algorithm.MD5.ComputeHash(user.Password + Algorithm.MD5.ComputeHash(user.Salt));
            object obj = Insert(user);
            return "";
        }

        public bool Login(Users user)
        {
            string email = user.Email;
            var u = SingleOrDefault(x => x.Email == email);

            if (u == null) return false;
            bool b = (Algorithm.MD5.ComputeHash(user.Password + Algorithm.MD5.ComputeHash(u.Salt)) == u.Password);
            if (b)
            {
                EMapper.Mapper(u, user);
            }
            return b;
        }
    }
}
