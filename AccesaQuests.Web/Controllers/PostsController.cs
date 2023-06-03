using AccesaQuests.Web.Repositories;
using AccesaQuests.Web.Models.ViewsName;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccesaQuests.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public PostsController(IPostRepository postRepository, IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.postRepository = postRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var post = await postRepository.GetByUrlHandleAsync(urlHandle);
            var blogDetailsViewModel = new BlogDetailsViewModel();

            if (post != null)
            {
                var totalLikes = await blogPostLikeRepository.GetTotalLikes(post.Id);
                blogDetailsViewModel = new BlogDetailsViewModel
                {
                    Id = post.Id,
                    Content = post.Content,
                    PostTitle = post.PostTitle,
                    Author = post.Author,
                    FeaturedImageUrl = post.FeaturedImageUrl,
                    PostHeading = post.PostHeading,
                    PublishedDate = post.PublishedDate,
                    ShortDescription = post.ShortDescription,
                    UrlHandle = post.UrlHandle,
                    Tags = post.Tags,
                    TotalLikes = totalLikes
                };
            }

            return View(blogDetailsViewModel);
        }
    }
}
