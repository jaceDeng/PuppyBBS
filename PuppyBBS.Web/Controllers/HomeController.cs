using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PuppyBBS.Services;
using PuppyBBS.Web.Models;

namespace PuppyBBS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ForumServices ForumServices { get; set; }
        public TopicServices TopicServices { get; set; }

        public UserServices UserServices { get; set; }
        public HomeController(ForumServices services, TopicServices topicServices, UserServices userServices)
        {
            ForumServices = services;
            this.TopicServices = topicServices;
            UserServices = userServices;
        }
        public IActionResult Index()
        {
            UserServices services = new UserServices(this.UserServices.ConnectString);
            services.BeginCache();
            HomeModel model = new HomeModel();
            model.Forums = this.ForumServices.Fetch();
            model.Topics = EMapper.Mapper<Services.Models.Topic, Models.TopicModel>(this.TopicServices.Fetch(x => x.IsTop),
                p => p.Author = EMapper.Mapper<Services.Models.Users, Models.UserModel>(services.SingleOrDefaultById(p.UID)));
            model.Comprehensiveness = EMapper.Mapper<Services.Models.Topic, Models.TopicModel>(this.TopicServices.Comprehensive(20),
                p => p.Author = EMapper.Mapper<Services.Models.Users, Models.UserModel>(services.SingleOrDefaultById(p.UID)));
            services.EndCache();
            return View(model);
        }


    }
}
