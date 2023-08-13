using KnowledgeHubPortal.Domain.CategoryManager;
using KnowledgeHubPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class CategoriesController : Controller
    {

        private IManageCategory manageCategory = null;// new ManageCategory(new CategoryRepository());

        public CategoriesController(IManageCategory manageCategory)
        {
            this.manageCategory = manageCategory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            // send empty view for accepting category info
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            // do validation - server side 
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save
            manageCategory.CreateCategory(category);


            return View("Thanks");
        }
    }
}
