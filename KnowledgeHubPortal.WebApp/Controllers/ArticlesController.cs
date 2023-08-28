using KnowledgeHubPortal.Domain.ArticlesManager;
using KnowledgeHubPortal.Domain.CategoryManager;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.OutputCaching;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class ArticlesController : Controller
    {

        private IManageCategory categoriesManager;
        private IManageArticle articlesManager;

        public ArticlesController(IManageCategory categoriesManager, IManageArticle articlesManager)
        {
            this.categoriesManager = categoriesManager;
            this.articlesManager = articlesManager;
        }
        [OutputCache(Duration = 100)]
        [ResponseCache]
        public IActionResult Index() // this is for browse articles 
        {
            return View(articlesManager.GetArticlesForBrowse());
        }
        [HttpGet]
        public IActionResult Submit()
        {
            List<Category> categoryList = categoriesManager.GetAllCategories();
            var categories = from c in categoryList
                             select new SelectListItem
                             {
                                 Value = c.CategoryId.ToString(),
                                 Text = c.Name
                             };
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Submit(ArticleSubmitViewModel vmArticle)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            Article domainArticle = new Article
            {
                Title = vmArticle.Title,
                URL = vmArticle.URL,
                Description = vmArticle.Description,
                CategoryID = vmArticle.CategoryID
            };

            domainArticle.IsApproved = false;
            domainArticle.DateSubmited = DateTime.Now;
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
                domainArticle.PostedBy = User.Identity.Name;
            else
                domainArticle.PostedBy = "Anonymous";




            articlesManager.SubmitArticle(domainArticle);
            TempData["Message"] = $"Article {vmArticle.Title} has been submited successfully for admin review";
            return RedirectToAction("Index");
        }
    }
}
