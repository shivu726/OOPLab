
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
    }
}
