using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ArticleURL { get; set; }

        public int CategoryId { get; set; }

        public bool IsApprove { get; set; }

        public string PostedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }
    }
}
