using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi.Utility.ApiResult;
using System;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;

        public BlogNewsController(IBlogNewsService iBlogNewsService)
        {
            this._iBlogNewsService = iBlogNewsService;
        }

        [HttpGet("GetBlogNews")]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        {
            var data = await _iBlogNewsService.QueryAsync();
            if (data is null)
            {
                return ApiResultHelper.Error("data is null");
            }
            return ApiResultHelper.Success(data);
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string title, string content, int typeid)
        {
            //数据验证
            BlogNews blogNews = new BlogNews
            {
                BrowseCount = 0,
                Title = title,
                Content = content,
                Time = DateTime.Now,
                WriterId = 1,
                TypeId = typeid,
                LikeCount = 0
            };
            bool b = await _iBlogNewsService.CreateAsync(blogNews);
            if (!b)
            {
                return ApiResultHelper.Error("添加失败：服务器发生错误");
            }
            return ApiResultHelper.Success(blogNews);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<ApiResult>> Update(int id,string title,string content,int typeid)
        {
            var blognews = await _iBlogNewsService.GetByIdAsync(id);
            if (blognews is null)
            {
                return ApiResultHelper.Error("未找到改文章");
            }
            else
            {
                blognews.Title = title;
                blognews.Content = content; 
                blognews.TypeId = typeid;
                var  b = await _iBlogNewsService.EditAsync(blognews);
                if (!b) return ApiResultHelper.Error("修改失败");
                return ApiResultHelper.Success(blognews);
            }
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            var b = await _iBlogNewsService.DeleteAsync(id);
            if (!b) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(b);
        }

    }
}
