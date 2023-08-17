using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;

namespace KnowledgeHubPortal.Domain.ArticlesManager
{
    public class ManageArticle : IManageArticle
    {
        private IArticlesRepository repo;

        public ManageArticle(IArticlesRepository repo)
        {
            this.repo = repo;
        }
        public void ApproveArticles(int[] articleIdsToApprove)
        {
            repo.ApproveArticles(articleIdsToApprove);
        }

        public List<Article> GetArticlesByCategoryForBrowse(int categoryID)
        {
            return repo.GetArticlesByCategoryForBrowse(categoryID);
        }

        public List<Article> GetArticlesByCategoryForReview(int categoryID)
        {
            return repo.GetArticlesByCategoryForReview(categoryID);
        }

        public List<Article> GetArticlesForBrowse()
        {
            return repo.GetArticlesForBrowse();
        }

        public List<Article> GetArticlesForReview()
        {
            return repo.GetArticlesForReview();
        }

        public void RejectArticles(int[] articleIdsToReject)
        {
            repo.RejectArticles(articleIdsToReject);
        }

        public void SubmitArticle(Article articleToSubmit)
        {
            repo.SubmitArticle(articleToSubmit);
        }
    }
}
