using AccesaQuests.Web.Models.ViewsName;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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
            if (ModelState.IsValid)
            {
                var identyUser = new IdentityUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                };

                var identitResult = await userManager.CreateAsync(identyUser, registerViewModel.Password);

                if (identitResult.Succeeded)
                {
                    // Assign the user the "user" role
                    var roleIdentity = await userManager.AddToRoleAsync(identyUser, "User");
                    if (roleIdentity.Succeeded)
                    {
                        // Show success notification
                        TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                        return RedirectToAction("Register");
                    }
                }

                // If there are any errors, add them to ModelState for display
                foreach (var error in identitResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If registration failed or model is invalid, return to the registration view
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var signInResult = await signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);

            if (signInResult.Succeeded && signInResult != null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Show error
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
