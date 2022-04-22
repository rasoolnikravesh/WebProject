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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Posts"] = await UnitOfWork.PostRepository.GetAllAsync();
            return View();
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(ViewModels.MangeBlog.AddPostViewModel model, [FromServices] AutoMapper.IMapper mapper)
        {
            var post = mapper.Map<Models.Post>(model);
            post.UserId = (await UserManager.FindByNameAsync(User.Identity?.Name)).Id;
            await UnitOfWork.PostRepository.InsertAsync(post);
            await UnitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var post = UnitOfWork.PostRepository.GetById(id);
            UnitOfWork.PostRepository.Delete(post);
            UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
