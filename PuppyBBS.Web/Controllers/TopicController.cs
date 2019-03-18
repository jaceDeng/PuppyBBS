using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuppyBBS.Services;
using PuppyBBS.Services.Models;
using PuppyBBS.Web.ActionFilters;
using PuppyBBS.Web.Models;

namespace PuppyBBS.Web.Controllers
{
    public class TopicController : Controller
    {
        private TopicServices AppServices = null;
        private UserServices UserServices = null;
        private CommentServices CommentServices = null;
        public TopicController(TopicServices services, UserServices userServices, CommentServices comment)
        {
            AppServices = services;
            UserServices = userServices;
            CommentServices = comment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [VaptchaTokenFilter]
        [Authorize]
        public IActionResult Add(TopicModel model)
        {
            var topic = PuppyBBS.Services.EMapper.Mapper<TopicModel, Services.Models.Topic>(model);
            topic.TID = Services.Util.SnowFlake.CreateId();
            topic.UID = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var obj = AppServices.Insert(topic);
            return Json(new JsonModel { status = 0, msg = "发布成功", action = "/topic/detail/" + topic.TID.ToString() });
        }
        [HttpPost]
        [VaptchaTokenFilter]
        [Authorize]
        public IActionResult Reply(TopicReplayModel model)
        {
            var topic = PuppyBBS.Services.EMapper.Mapper<TopicReplayModel, Services.Models.Comments>(model);
            topic.CID = Services.Util.SnowFlake.CreateId();
            topic.UID = Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var obj = CommentServices.Insert(topic);
            AppServices.Update(x => x.TID == topic.TID, x =>
            {
                x.Comments++;
                x.Lastreply = DateTime.Now;
                x.RuID = topic.UID;
                x.Views++;
                return x;
            });
            return Json(new JsonModel { status = 0, msg = "发布成功", action = "/topic/detail/" + topic.TID.ToString() + "#" + topic.CID.ToString() });
        }
        [HttpGet]
        public IActionResult Detail(long id)
        {
            var model = AppServices.SingleOrDefaultById(id);
            var topic = PuppyBBS.Services.EMapper.Mapper<Services.Models.Topic, TopicModel>(model);
            topic.Author = PuppyBBS.Services.EMapper.Mapper<Services.Models.Users, UserModel>(UserServices.SingleOrDefaultById(topic.UID));
            var pg = CommentServices.PageQuery(1, 15, x => x.TID == topic.TID);
            topic.Comment = new NPoco.Page<CommentsModel>()
            {
                CurrentPage = pg.CurrentPage,
                ItemsPerPage = pg.ItemsPerPage,
                TotalItems = pg.TotalItems,
                TotalPages = pg.TotalPages
            };
            topic.Comment.Items = EMapper.Mapper<Comments, CommentsModel>(CommentServices.FillAuthor(pg.Items), x =>
            {
                if (x.PraiseID == null)
                {
                    x.PraiseID = new long[0];
                }
            });
            return View(topic);
        }
    }
}