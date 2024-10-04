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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly KnowledgeHubPortalDbContext _context = null;

        public CategoryRepository(KnowledgeHubPortalDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
