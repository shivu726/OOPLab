using EFCore.BulkExtensions;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Data
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly KnowledgeHubPortalDbContext _context = null;

        public ArticleRepository(KnowledgeHubPortalDbContext context)
        {
            _context = context;
        }

        public async Task AddArticleAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }

        public async Task ApproveArticleAsync(List<int> articlesId)
        {
            var approveList = new List<Article>();

            foreach (var ids in articlesId)
            {
                var approveArticle = _context.Articles.Find(ids);
                approveArticle!.IsApprove = true;
                approveList.Add(approveArticle);
            }

            await _context.BulkUpdateAsync(approveList);
        }

        public async Task<List<Article>> GetArticlesForReviewAsync(int categoryId = 0)
        {
            List<Article> articles = null;

            if (categoryId == 0) 
            {
                articles = await _context.Articles.Where(a => !a.IsApprove).ToListAsync();
            }
            else
            {
                articles = await _context.Articles.Where(a => !a.IsApprove && a.CategoryId == categoryId).ToListAsync();
            }

            return articles;
        }

        public async Task<List<Article>> GetArticlesForSaveAsync(int categoryId)
        {
            List<Article> articles = null;

            if (categoryId == 0)
            {
                articles = await _context.Articles.Where(a => a.IsApprove).ToListAsync();
            }
            else
            {
                articles = await _context.Articles.Where(a => a.IsApprove && a.CategoryId == categoryId).ToListAsync();
            }

            return articles;
        }

        public async Task RejectArticleAsync(List<int> articlesId)
        {
            var rejectList = new List<Article>();
            foreach (var ids in articlesId)
            {
                var articlesReject = _context.Articles.Find(ids);
                rejectList.Add(articlesReject);
            }

            await _context.BulkDeleteAsync(rejectList);

            // Normal way of deleting...
            //foreach (var ids in articlesId)
            //{
            //    var articlesReject = _context.Articles.Find(ids);
            //    _context.Articles.Remove(articlesReject);
            //}
            //await _context.SaveChangesAsync();
        }
    }
}
