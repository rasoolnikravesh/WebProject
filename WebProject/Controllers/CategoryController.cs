using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebProject.Controllers
{
    [Authorize("admin")]
    public class CategoryController : Infrastructure.ControllerWithIdentity
    {
        public CategoryController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager) : base(unitOfWork, userManager, roleManager, signInManager)
        {

        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> List()
        {
            var Categories = await UnitOfWork.CategoryRepository.GetAllAsync();

            return View(Categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ViewModels.Category.CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category { Title = model.Title };

                await UnitOfWork.CategoryRepository.InsertAsync(category);
                await UnitOfWork.SaveAsync();
                return RedirectToAction(nameof(List));
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var cat = UnitOfWork.CategoryRepository.GetById(id);
            if (cat != null)
            {
                await UnitOfWork.CategoryRepository.DeleteAsync(cat);
                await UnitOfWork.SaveAsync();
                return RedirectToAction(nameof(List));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
