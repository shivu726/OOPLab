using CoolProductsAPIService.Models.Data;
using CoolProductsAPIService.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CoolProductsAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDbContext _context = null;

        public ProductsController(ProductsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Using OData for Get Products..
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        [Authorize]
        public IQueryable<Products> GetAllProducts()
        {
            return _context.Products.AsQueryable();
        }

        // Normal get method
        //[HttpGet]
        //public List<Products> GetAllProducts()
        //{
        //    return _context.Products.ToList();
        //}

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("name/{name:alpha}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var prod = await _context.Products.Where(x => x.Brand.Contains(name)).ToListAsync();
            if (prod != null)
            {
                return Ok(prod);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("brand/{brand}")]
        public IActionResult GetProductByBrand(string brand)
        {
            var prod = _context.Products.Where(x => x.Brand.Contains(brand)).ToList();
            if (prod != null)
            {
                return Ok(prod);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("country/{country}")]
        public IActionResult GetProductByCountry(string country)
        {
            var countryProd = _context.Products.Where(c => c.Country == country).ToList();

            if (countryProd != null)
            {
                return Ok(countryProd);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("inStock/{inStock:bool}")]
        public IActionResult GetStockProducts(bool inStock)
        {
            var stockProduct = (from stock in _context.Products
                                where stock.InStock == inStock
                                select stock).ToList();

            if (stockProduct != null)
            {
                return Ok(stockProduct);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("cheapest")]
        public IActionResult GetCheapestProduct()
        {
            var cheapestProd = from prod in _context.Products
                               orderby prod.Price
                               select prod;
            return Ok(cheapestProd.FirstOrDefault());
        }

        [HttpGet]
        [Route("{min:int}/{max:int}")]
        public IActionResult GetProductByPriceRange(int min, int max)
        {
            var products = (from product in _context.Products
                            where product.Price >= min && product.Price <= max
                            select product).ToList();

            if (products.Count == 0)
                return NotFound();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }
            _context.Products.Add(products);
            _context.SaveChanges();

            return Created($"api/products/{products.ProductId}", products);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var prod = _context.Products.Find(id);
            if (prod == null)
            {
                return NotFound();
            }
            else
            {
                _context.Products.Remove(prod);
                _context.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateProduct([FromHeader] int id, [FromBody] Products products)
        {
            //var data = _context.Products.Find(id);
            //if (data == null)
            //{
            //    return NotFound();
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }

            _context.Products.Update(products);
            _context.SaveChanges();
            return Ok();
        }
    }
}
