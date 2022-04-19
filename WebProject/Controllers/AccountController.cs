using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebProject.Controllers
{
    public class AccountController : Infrastructure.ControllerWithIdentity
    {
        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) : base(unitOfWork, userManager, roleManager)
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
    }
}
