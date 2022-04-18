using Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class ControllerWithIdentity : BaseController
    {
        public ControllerWithIdentity(IUnitOfWork unitOfWork,
            UserManager<Models.ApplicationUser> userManager,
            RoleManager<Models.ApplicationRole> roleManager)
            : base(unitOfWork)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public UserManager<Models.ApplicationUser> UserManager { get; }
        public RoleManager<Models.ApplicationRole> RoleManager { get; }
    }
}
