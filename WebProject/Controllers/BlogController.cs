using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebProject.Controllers
{
    [Route("[controller]")]
    public class BlogController : Infrastructure.BaseController
    {
        public BlogController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public async Task<IActionResult> Index()
        {
            var data = await UnitOfWork.PostRepository.GetAllWithCategoryAsync();
            ViewData["Posts"] = data;
            return View();
        }
        [HttpGet("[action]/{PostTitle}")]
        public async Task<IActionResult> Post(string PostTitle)
        {
            var result = await UnitOfWork.PostRepository.GetAllWithCategoryAsync();
            Post? post = result.Where(x => x.Title == PostTitle).SingleOrDefault();
            return View(post);
        }
    }
}
