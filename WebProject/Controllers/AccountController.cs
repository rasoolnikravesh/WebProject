using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebProject.Controllers
{
    public class AccountController : Infrastructure.ControllerWithIdentity
    {
        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(unitOfWork, userManager, roleManager, signInManager)
        {
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register
            (ViewModels.Account.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Models.ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    EmailConfirmed = true
                };
                IdentityResult resualt = await UserManager.CreateAsync(user, model.Password);
                var users = UserManager.Users.Count();
                if (users == 1)
                {
                    var result = await UserManager.IsInRoleAsync(user, "admin");
                    if (!result)
                    {
                        var role = await RoleManager.FindByNameAsync("admin");
                        if (role == null)
                            await RoleManager.CreateAsync(new ApplicationRole { Name = "admin" });
                        await UserManager.AddToRoleAsync(user, "admin");
                    }
                }

                if (resualt.Succeeded)
                {
                    RedirectToAction(actionName: "Index", controllerName: nameof(HomeController));
                }

                foreach (var item in resualt.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (SignInManager.IsSignedIn(User))
                return RedirectToAction("Index", "home");
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ViewModels.Account.LoginViewModel model, string? returnUrl = null)
        {
            if (SignInManager.IsSignedIn(User))
                return RedirectToAction("Index", "home");
            ViewData["returnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ViewData["ErrorMessage"] = Resources.Messages.UserNotFond;
                }
                else
                {

                    var resault = await SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                    if (resault.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                            Redirect(returnUrl);
                        return RedirectToAction("index", "Home");
                    }

                    if (resault.IsLockedOut)
                    {
                        ViewData["ErrorMessage"] = Resources.Messages.UserIsLockOuted;
                        return View(model);
                    }
                    ModelState.AddModelError(key: "", errorMessage: "نام کاربری یا رمز وروداشتباه است");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(controllerName: "home", actionName: "Index");
        }

        public async Task<IActionResult> IsValidEmail(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null) return Json(data: true);
            return Json(Resources.Messages.EmailIsUsed);
        }
        public async Task<IActionResult> IsValidUsername(string Username)
        {
            var user = await UserManager.FindByNameAsync(Username);
            if (user == null) return Json(data: true);
            return Json(Resources.Messages.UsernameIsUsed);
        }
    }
}
