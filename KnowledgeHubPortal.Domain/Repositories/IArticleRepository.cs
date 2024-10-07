using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Repositories
{
    public interface IArticleRepository
    {
        //void AddArticle(Article article);
        //List<Article> GetArticlesForSave(int categoryId);
        //List<Article> GetArticlesForReview(int categoryId);
        //void ApproveArticle(List<int> acticlesId);
        //void RejectArticle(List<int> acticlesId);

        Task AddArticleAsync(Article article);

        Task<List<Article>> GetArticlesForSaveAsync(int categoryId);

        Task<List<Article>> GetArticlesForReviewAsync(int categoryId);

        Task ApproveArticleAsync(List<int> acticlesId);

        Task RejectArticleAsync(List<int> acticlesId);

        Task<List<Article>> GetArticlesAsync();
    }
}
