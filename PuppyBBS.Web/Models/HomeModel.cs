using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
    public class HomeModel
    {
        public List<PuppyBBS.Services.Models.Forum> Forums { get; set; }

        public List<Models.TopicModel> Topics { get; set; }

        /// <summary>
        /// 综合排序
        /// </summary>
        public List<Models.TopicModel> Comprehensiveness { get; set; }
    }
}
