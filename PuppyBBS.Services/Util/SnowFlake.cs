using IdGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuppyBBS.Services.Util
{
    /// <summary>
    /// 雪花算法
    /// </summary>
    public class SnowFlake
    {
        private static readonly IdGenerator generator;
        static SnowFlake()
        {
            var epoch = new DateTime(2019, 1, 28, 0, 0, 0, DateTimeKind.Utc);
            // Create a mask configuration of 45 bits for timestamp, 2 for generator-id 
            // and 16 for sequence
            var mc = new MaskConfig(45, 2, 16);
            // Create an IdGenerator with it's generator-id set to 0, our custom epoch 
            // and mask configuration
            generator = new IdGenerator(0, epoch, mc);
        }

        /// <summary>
        /// 唯一ID
        /// </summary>
        /// <returns></returns>
        public static long CreateId()
        {
            return generator.CreateId();
        }
    }
}
