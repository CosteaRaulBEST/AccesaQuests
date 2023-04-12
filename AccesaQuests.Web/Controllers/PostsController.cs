using AccesaQuests.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AccesaQuests.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository postRepository;

        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var Post = await postRepository.GetByUrlHandleAsync(urlHandle);
            return View(Post);
        }
    }
}
