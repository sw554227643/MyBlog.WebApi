using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
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

        [HttpGet]
        public async Task<ActionResult> GetBlogNews()
        {
            var data = await  _iBlogNewsService.QueryAsync();
            return Ok(data);
        }

    }
}
