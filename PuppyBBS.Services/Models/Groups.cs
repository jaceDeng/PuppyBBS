using System;
namespace PuppyBBS.Services.Models
{
        /// <summary>
        ///tb_groups 
        /// </summary>      
        [NPoco.TableName("tb_groups")]
        [NPoco.PrimaryKey("gid",AutoIncrement =false)]
        
		public class Groups
        {    
		     
			/// <summary>
			/// 
			/// </summary>                       
			[NPoco.Column("gid")]
            public Int32 GID {get;set;}   
             
			/// <summary>
			/// 群组
			/// </summary>                       
			[NPoco.Column("name")]
            public String Name {get;set;}   
               
    }    
} 

