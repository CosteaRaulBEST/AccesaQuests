using AccesaQuests.Web.Repositories;
using AccesaQuests.Web.Models.ViewsName;
using BlogPost.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AccesaQuests.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public PostsController(IPostRepository postRepository,
            IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.postRepository = postRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var Post = await postRepository.GetByUrlHandleAsync(urlHandle);
            var blogDetailsViewModel = new BlogDetailsViewModel();
            if (Post != null) 
            {
                var totalLikes = await blogPostLikeRepository.GetTotalLikes(Post.Id);
                blogDetailsViewModel = new BlogDetailsViewModel
                {
                    Id = Post.Id,
                    Content = Post.Content,
                    PostTitle = Post.PostTitle,
                    Author = Post.Author,
                    FeaturedImageUrl = Post.FeaturedImageUrl,
                    PostHeading = Post.PostHeading,
                    PublishedDate = Post.PublishedDate,
                    ShortDescription = Post.ShortDescription,
                    UrlHandle = Post.UrlHandle,
                    Tags = Post.Tags,
                    TotalLikes = totalLikes
                };
                
            }
            return View(blogDetailsViewModel);
        }
    }
}
