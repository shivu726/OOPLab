using CoolProductsAPIService.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoolProductsAPIService.Models.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(1, 999999)]
        public int Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        public string? Category { get; set; }
        public string? Country { get; set; }
        public bool InStock { get; set; }
    }
}

