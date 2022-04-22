using Data;
using Microsoft.AspNetCore.Identity;
using Models;

namespace WebProject.Controllers
{
    public class CategoryController : Infrastructure.ControllerWithIdentity
    {
        public CategoryController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(unitOfWork, userManager, roleManager, signInManager)
        {

        }
    }
}
