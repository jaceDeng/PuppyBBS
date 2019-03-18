using System;
namespace PuppyBBS.Services.Models
{
        /// <summary>
        ///tb_email_template 
        /// </summary>      
        [NPoco.TableName("tb_email_template")]
        [NPoco.PrimaryKey("tid",AutoIncrement =false)]
        
		public class EmailTemplate
        {    
		     
			/// <summary>
			/// 
			/// </summary>                       
			[NPoco.Column("tid")]
            public Int32 TID {get;set;}   
             
			/// <summary>
			/// 模板名称
			/// </summary>                       
			[NPoco.Column("name")]
            public String Name {get;set;}   
             
			/// <summary>
			/// 模板内容使用｛name｝进行替换
			/// </summary>                       
			[NPoco.Column("content")]
            public String Content {get;set;}   
             
			/// <summary>
			/// 标题
			/// </summary>                       
			[NPoco.Column("title")]
            public String Title {get;set;}   
               
    }    
} 

