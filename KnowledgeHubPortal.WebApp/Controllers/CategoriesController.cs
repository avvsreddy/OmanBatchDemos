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

        /// <summary>
        /// displays the categories list
        /// </summary>
        /// <returns></returns>
        /// 

        // .../categories/index
        public IActionResult Index()
        {
            // fetch the required data from model
            var categories = manageCategory.GetAllCategories();
            // pass the data to the view
            return View(categories);
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

            ViewBag.Msg = category.Name;
            //ViewData["Msg"] = category.Name;


            return View("Thanks");
        }

        public IActionResult Delete(int id)
        {
            //manageCategory.DeleteCategory(id);
            var category = manageCategory.GetCategory(id);
            return View(category);

        }

        public IActionResult ConfirmDelete(int id)
        {
            manageCategory.DeleteCategory(id);
            //var categories = manageCategory.GetAllCategories();
            //return View("Index", categories);


            TempData["Msg"] = $"The Category ID {id} successfully deleted";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var catToEdit = manageCategory.GetCategory(id);
            return PartialView("InlineEdit", catToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Category catToEdit)
        {
            // validate
            if (!ModelState.IsValid)
                return View();

            manageCategory.UpdateCategory(catToEdit);
            return RedirectToAction("Index");
        }
    }
}
