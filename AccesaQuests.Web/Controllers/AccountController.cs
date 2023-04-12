using AccesaQuests.Web.Models.ViewsName;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace AccesaQuests.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var identyUser = new IdentityUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
            };

            var identitResult = await userManager.CreateAsync(identyUser, registerViewModel.Password);

            if (identitResult.Succeeded)
            {
                //asign the user the "user" role
                var roleIdentity = await userManager.AddToRoleAsync(identyUser, "User");
                if (roleIdentity.Succeeded)
                {
                    //Show succes notification
                    return RedirectToAction("Register");
                }
            }
            //SHOW ERROR NOTIFICATION
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password ,false ,false);

            if (signInResult.Succeeded && signInResult != null)
            {
                return RedirectToAction("Index" , "Home");

            }
            //Show error
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
