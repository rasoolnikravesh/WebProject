using Data;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class BlogController : Infrastructure.BaseController
    {
        public BlogController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IActionResult> Index()
        {
            var data = await UnitOfWork.GetRepository<Models.Post>().GetAllAsync();

            ViewData["Posts"] = data;
            return View();
        }
    }
}
