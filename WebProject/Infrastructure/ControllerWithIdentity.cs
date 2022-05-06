using Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public class ControllerWithIdentity : BaseController
{

    public ControllerWithIdentity(IUnitOfWork unitOfWork,
        UserManager<Models.ApplicationUser> userManager,
        RoleManager<Models.ApplicationRole> roleManager,
        SignInManager<Models.ApplicationUser> signInManager)
        : base(unitOfWork)
    {
        UserManager = userManager;
        RoleManager = roleManager;
        SignInManager = signInManager;
    }

    public UserManager<Models.ApplicationUser> UserManager { get; }
    public RoleManager<Models.ApplicationRole> RoleManager { get; }
    public SignInManager<Models.ApplicationUser> SignInManager { get; }
}
