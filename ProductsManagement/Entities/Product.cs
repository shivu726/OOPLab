
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsManagement.Entities
{
    [Table("tbl_Products")]
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(50)]
        [MinLength(0)]
        [Required]
        public string Name { get; set; }

        public int Price { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        public string Brand { get; set; }

        [NotMapped]
        public string ProfitMargin { get; set; }

        public Category Category { get; set; }

        public List<Supplier> Suppliers { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public List<Product> Products { get; set; }
    }

    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string GST { get; set; }
        public int Rating { get; set; }
        public List<Product> Products { get; set; }
    }
}
