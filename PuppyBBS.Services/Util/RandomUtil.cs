using System;
using System.Collections.Generic;
using System.Text;

namespace PuppyBBS.Services.Util
{
    public class RandomUtil
    {

        public static string Random(int len)
        {
            Random random = new Random();
            char[] str = new char[len];
            for (int i = 0; i < len; i++)
            {
                str[i] = (char)random.Next(33,126);
            }
            return new string(str);
        }
    }
}
