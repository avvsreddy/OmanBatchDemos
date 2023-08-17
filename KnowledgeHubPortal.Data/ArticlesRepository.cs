using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;

namespace KnowledgeHubPortal.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        private KnowledgeHubPortalOmanDB db = new KnowledgeHubPortalOmanDB();

        public void ApproveArticles(int[] articleIdsToApprove)
        {
            foreach (var article in GetArticlesForReview())
            {
                foreach (var id in articleIdsToApprove)
                {
                    if (article.ArticleID == id)
                    {
                        article.IsApproved = true;
                    }
                }
            }
            db.SaveChanges();
        }

        public List<Article> GetArticlesByCategoryForBrowse(int categoryID)
        {
            return db.Articles.Where(a => a.IsApproved && a.CategoryID == categoryID).ToList();

        }

        public List<Article> GetArticlesByCategoryForReview(int categoryID)
        {
            return db.Articles.Where(a => !a.IsApproved && a.CategoryID == categoryID).ToList();
        }

        public List<Article> GetArticlesForBrowse()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }

        public List<Article> GetArticlesForReview()
        {
            var articles = from a in db.Articles
                           where a.IsApproved == false
                           select a;
            return articles.ToList();
        }

        public void RejectArticles(int[] articleIdsToReject)
        {
            foreach (var article in GetArticlesForReview())
            {
                foreach (var id in articleIdsToReject)
                {
                    if (article.ArticleID == id)
                    {
                        db.Articles.Remove(article);
                    }
                }
            }
            db.SaveChanges();
        }

        public void SubmitArticle(Article articleToSubmit)
        {
            db.Articles.Add(articleToSubmit);
            db.SaveChanges();
        }
    }
}
