using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repository
{
    public interface IArticlesRepository
    {
        void SubmitArticle(Article articleToSubmit);
        List<Article> GetArticlesForReview();
        List<Article> GetArticlesForBrowse();

        void ApproveArticles(int[] articleIdsToApprove);
        void RejectArticles(int[] articleIdsToReject);

        List<Article> GetArticlesByCategoryForReview(int categoryID);
        List<Article> GetArticlesByCategoryForBrowse(int categoryID);
    }
}
