using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class HomeController : Infrastructure.BaseController
    {
        public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IActionResult Index()
        {
            var post = UnitOfWork.PostRepository.GetAll();
            if (post != null)
                ViewData["posts"] = post;
            return View();
        }
        [HttpGet]
        public IActionResult AddPosts()
        {
            return View();
        }
        public IActionResult InsertConfirm(ViewModels.InsertPostViewModel model)
        {
            Models.Post post = new Models.Post
            {
                Name = model.Name,
                Text = model.Text,
            };
            UnitOfWork.PostRepository.Insert(post);
            UnitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult test()
        {

            return RedirectToAction(nameof(Index));
        }
    }
}
