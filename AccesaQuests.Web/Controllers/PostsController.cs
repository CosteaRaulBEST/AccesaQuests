using AccesaQuests.Web.Repositories;
using AccesaQuests.Web.Models.ViewsName;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AccesaQuests.Web.Models.Domain;

namespace AccesaQuests.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public PostsController(IPostRepository postRepository,
            IBlogPostLikeRepository blogPostLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBlogPostCommentRepository blogPostCommentRepository)
        {
            this.postRepository = postRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)    
        {
            var post = await postRepository.GetByUrlHandleAsync(urlHandle);
            var blogDetailsViewModel = new BlogDetailsViewModel();

            if (post != null)
            {
                var totalLikes = await blogPostLikeRepository.GetTotalLikes(post.Id);


                var blogCommentsDomainModel = await blogPostCommentRepository.GetCommentsByBlogIdAsync(post.Id);

                var blogCommentsForView = new List<BlogComment>();
                foreach (var blogComment in blogCommentsDomainModel)
                {
                    blogCommentsForView.Add(new BlogComment
                    {
                        Description = blogComment.Description,
                        DateAdded = blogComment.DateAdded,
                        Username = (await userManager.FindByIdAsync(blogComment.UserId.ToString())).UserName
                    });
                }
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
                    TotalLikes = totalLikes,
                    Comments = blogCommentsForView
                    
                };
            }

            return View(blogDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            if(signInManager.IsSignedIn(User))
            {
                var domainModel = new BlogPostComment
                {
                    BlogPostId = blogDetailsViewModel.Id,
                    Description = blogDetailsViewModel.CommentDescription,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdded =DateTime.Now
                };

                await blogPostCommentRepository.AddAsync(domainModel);
                return RedirectToAction("Index", "Home" ,
                    new {urlHandle = blogDetailsViewModel.UrlHandle});
            }
            return View();
          
        }
    }
}
