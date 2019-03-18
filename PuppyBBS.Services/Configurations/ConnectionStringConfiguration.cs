

namespace PuppyBBS.Services.Configurations
{
    /// <summary>
    /// 数据库字符串链接配置
    /// </summary>
    
    public class ConnectionStringConfiguration  
    {
        private string defaultConnectionString;

        /// <summary>
        /// 获取或设置读库链接串
        /// </summary>
        public string DefaultConnectionString
        {
            get
            {
                return GetConnectionString(defaultConnectionString);
            }
            set
            {
                defaultConnectionString = value;
            }
        } 


        /// <summary>
        /// 获取数据库连接串
        /// </summary>
        /// <param name="rawString">原始连接串</param>
        /// <returns></returns>
        private string GetConnectionString(string rawString)
        { 
            return rawString;
        }
    }
}
