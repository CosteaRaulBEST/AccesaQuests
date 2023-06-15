using AccesaQuests.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccesaQuests.Web.Repositories;
using AccesaQuests.Web.Models.ViewsName;

namespace AccesaQuests.Web.Controllers
{ 

  public class HomeController : Controller
  { 
    private readonly ILogger<HomeController> _logger;
    private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository ,ITagRepository tagRepository)
    {
        _logger = logger;
        this.postRepository = postRepository;
            this.tagRepository = tagRepository;
        }

    public async Task<IActionResult> Index()
    {

        var Posts = await postRepository.GetAllAsync();


         var tags = await tagRepository.GetAllAsync();

            var model = new HomeViewModel
            {
                Posts = Posts,
                Tags = tags
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
} }
