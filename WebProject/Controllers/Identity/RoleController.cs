using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebProject.Controllers.Identity
{
    [Authorize(Roles = "superAdmin")]
    public class RoleController : Infrastructure.ControllerWithIdentity
    {
        public RoleController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(unitOfWork, userManager, roleManager, signInManager)
        {
        }

        public IActionResult Index()
        {
            ViewData["Roles"] = RoleManager.Roles.ToList();
            return View();
        }

        public async Task<IActionResult> InsertRole(ViewModels.Role.InsertRole role)
        {
            var result = await RoleManager.CreateAsync(new Models.ApplicationRole { Name = role.Name });
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction(nameof(Index));
        }



    }
}
