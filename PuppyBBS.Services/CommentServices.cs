using System;
using System.Collections.Generic;
using System.Text;

namespace PuppyBBS.Services
{
    public class CommentServices : PuppyService<Models.Comments>
    {
        public CommentServices(string conn) : base(conn)
        {

        }

        public List<Models.Comments> FillAuthor(List<Models.Comments> comments)
        {
            UserServices user = new UserServices(this.ConnectString);
            user.BeginCache();
            foreach (var item in comments)
            { 
                item.Author = user.SingleOrDefaultById(item.UID);
            }
            user.EndCache();
            return comments;
        }
    }
}
