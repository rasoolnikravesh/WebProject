using Data;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebProject.Controllers
{
    [Authorize]
    public class HomeController : Infrastructure.ControllerWithIdentity
    {
        public HomeController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(unitOfWork, userManager, roleManager, signInManager)
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var post = UnitOfWork.PostRepository.GetLast10Posts();
            if (post != null)
                ViewData["posts"] = post;
            return View();
        }


        

    }
}
