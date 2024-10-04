using KnowledgeHubPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Repositories
{
    public interface ICategoryRepository    // Contract class 
    {
        //void Create(Category category);

        //List<Category> GetAll();

        Task CreateAsync(Category category);

        Task<List<Category>> GetAllAsync();
    }
}
