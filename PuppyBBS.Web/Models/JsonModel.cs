using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Models
{
    public class JsonModel<T>
    {
        public int status { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
        public string action { get; set; }
    }
    public class JsonModel : JsonModel<object>
    {

    }
}
