using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlog.Model
{
    /// <summary>
    /// 作者表
    /// </summary>
    public class BlogNews:BaseId
    {
        //nvarchar 带中文比较好
        [SugarColumn(ColumnDataType ="nvarchar(30)" )]
        public string Title { get; set; }
        [SugarColumn(ColumnDataType ="text")]
        public string Content { get; set; }

        public DateTime Time { get; set; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public int BrowseCount { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        public int LikeCount { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>
        public int WriterId { get; set; }
        /// <summary>
        /// 文章类型ID
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 类型 不映射到数据库
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public TypeInfo TypeInfo { get; set; }

        [SugarColumn(IsIgnore = true)]
        public WriterInfo WriterInfo { get; set; }
    }
}

