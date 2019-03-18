using PuppyBBS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Core
{
    public class Captcha
    {
        private static readonly HttpClient httpClient = new HttpClient()
        {


        };

        static Captcha()
        {
            httpClient = new HttpClient(new HttpClientHandler()
            {
             //   Proxy = new System.Net.WebProxy("127.0.0.1:8888", true)
            });

        }
        public async static Task<bool> Validate(string ip, IVaptchaToken token)
        {
            try
            {
                var v = new Dictionary<string, string>
                {
                    { "id", "5c4aae6bfc650e1254614ec6"},
                    { "secretkey", "3e954a709e8d4151a3a14b3070126fdc"},
                    { "scene",token.scene},
                    { "token", token.vaptcha_token},
                    { "ip", ip}
                };
                var message = (await httpClient.PostAsync("http://api.vaptcha.com/v2/validate", new FormUrlEncodedContent(v)));

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<VaptchaResult>(await message.Content.ReadAsStringAsync());
                //
                return result.success == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public class Vaptcha
        {
            public string id { get; set; } = "5c4aae6bfc650e1254614ec6";
            public string secretkey { get; set; } = "3e954a709e8d4151a3a14b3070126fdc";
            public string scene { get; set; } = "01";
            public string token { get; set; }
            public string ip { get; set; }

        }

        public class VaptchaResult
        {
            /// <summary>
            /// 
            /// </summary>
            public int success { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int score { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string msg { get; set; }
        }
    }
}
