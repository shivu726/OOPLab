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


//[HttpPost]
//public IActionResult Post(Products products)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest("Invalid input.");
//    }
//    _context.Products.Add(products);
//    _context.SaveChanges();

//    return Created($"api/products/{products.ProductId}", products);
//}

//[HttpDelete]
//[Route("{id}")]
//public IActionResult DeleteProduct(int id)
//{
//    var prod = _context.Products.Find(id);
//    if (prod == null)
//    {
//        return NotFound();
//    }
//    else
//    {
//        _context.Products.Remove(prod);
//        _context.SaveChanges();

//        return Ok();
//    }
//}

//[HttpPut]
//[Route("")]
//public IActionResult UpdateProduct([FromHeader] int id, [FromBody] Products products)
//{
//    //var data = _context.Products.Find(id);
//    //if (data == null)
//    //{
//    //    return NotFound();
//    //}

//    if (!ModelState.IsValid)
//    {
//        return BadRequest("Invalid input.");
//    }

//    _context.Products.Update(products);
//    _context.SaveChanges();
//    return Ok();
//}
