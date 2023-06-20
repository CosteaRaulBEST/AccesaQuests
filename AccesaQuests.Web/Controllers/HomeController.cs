using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AccesaQuests.Web.Models;
using AccesaQuests.Web.Models.ViewsName;
using AccesaQuests.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccesaQuests.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private const int PageSize = 16; // Number of posts per page

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository, ITagRepository tagRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index(int page = 1, string tag = null)
        {
            var posts = await _postRepository.GetAllAsync();
            var tags = await _tagRepository.GetAllAsync();

            // Filter posts by tag if provided
            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(p => p.Tags.Any(t => t.Name == tag)).ToList();
            }

            // Sort posts by release date in descending order
            var sortedPosts = posts.OrderByDescending(p => p.PublishedDate).ToList();

            int totalCount = sortedPosts.Count;
            int totalPages = (int)Math.Ceiling((double)totalCount / PageSize);

            // Validate current page number
            if (page < 1)
            {
                page = 1;
            }
            else if (page > totalPages)
            {
                page = totalPages;
            }

            // Calculate the start and end indexes for the current page
            int startIndex = (page - 1) * PageSize;
            int endIndex = Math.Min(startIndex + PageSize - 1, totalCount - 1);

            // Retrieve the posts for the current page
            var currentPosts = sortedPosts.GetRange(startIndex, endIndex - startIndex + 1);

            var model = new HomeViewModel
            {
                Posts = currentPosts,
                Tags = tags,
                CurrentPage = page,
                TotalPages = totalPages,
                CurrentTag = tag
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
