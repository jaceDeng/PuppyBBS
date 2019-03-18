using System;
namespace PuppyBBS.Services.Models
{
        /// <summary>
        ///tb_forum 
        /// </summary>      
        [NPoco.TableName("tb_forum")]
        [NPoco.PrimaryKey("fid",AutoIncrement =false)]
        
		public class Forum
        {    
		     
			/// <summary>
			/// 
			/// </summary>                       
			[NPoco.Column("fid")]
            public Int32 FID {get;set;}   
             
			/// <summary>
			/// 
			/// </summary>                       
			[NPoco.Column("name")]
            public String Name {get;set;}   
             
			/// <summary>
			/// 
			/// </summary>                       
			[NPoco.Column("display_name")]
            public String DisplayName {get;set;}   
             
			/// <summary>
			/// 支持访问角色
			/// </summary>                       
			[NPoco.Column("gid")]
            public Int32 GID {get;set;}   
               
    }    
} 

