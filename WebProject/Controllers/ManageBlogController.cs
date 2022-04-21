using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebProject.Controllers
{
    [Authorize(Policy = "admin")]
    public class ManageBlogController : Infrastructure.ControllerWithIdentity
    {
        public ManageBlogController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(unitOfWork, userManager, roleManager, signInManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPost()
        {
            return View();
        }
    }
}
