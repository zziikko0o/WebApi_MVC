using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_APP.Models;
using MVC_APP.ViewModels;

namespace MVC_APP.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<MVCAppUser> signInManager;
        private readonly UserManager<MVCAppUser> userManager;

        public AccountController(SignInManager<MVCAppUser> signInManager, UserManager<MVCAppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginVM.Username!, loginVM.Password!, loginVM.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt");
                return View(loginVM);
            }
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                MVCAppUser user = new()
                {
                    Name = registerVM.Name,
                    UserName = registerVM.Email,
                    Email = registerVM.Email,
                };
                var result = await userManager.CreateAsync(user, registerVM.Password!);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public async Task <IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
    }
}
