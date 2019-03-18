using System;
using System.Collections.Generic;
using System.Text;

namespace PuppyBBS.Services
{
    /// <summary>
    /// 论坛服务
    /// </summary>
    public class ForumServices : PuppyService<Models.Forum>
    {
        public ForumServices(string conn) : base(conn)
        {

        }
    }
}
