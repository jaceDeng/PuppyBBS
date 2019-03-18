using System;
using System.Collections.Generic;
using System.Text;

namespace PuppyBBS.Services
{
    public class TopicServices : PuppyService<Models.Topic>
    {
        public TopicServices(string conn) : base(conn)
        {

        }

        public List<Models.Topic> Comprehensive(int take)
        {
            using (var db = GetDatabase())
            {
                return db.SkipTake<Models.Topic>(0,take, "WHERE is_top=false ORDER BY create_time DESC");
            }
        }
    }
}
