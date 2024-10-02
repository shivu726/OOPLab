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
        void AddArticle(Article article);

        List<Article> GetArticlesForSave(int categoryId);

        List<Article> GetArticlesForReview(int categoryId);

        void ApproveArticle(List<int> acticlesId);

        void RejectArticle(List<int> acticlesId);
    }
}
