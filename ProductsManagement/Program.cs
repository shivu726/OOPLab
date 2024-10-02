using Microsoft.EntityFrameworkCore;
using ProductsManagement.Data;
using ProductsManagement.Entities;

namespace ProductsManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Delete the product from database based on Id..

            ProductsDbContext dbContext = new ProductsDbContext();
            var deleteProd = dbContext.Products.Find(3);

            if (deleteProd != null) { 
                
                dbContext.Remove(deleteProd);
                dbContext.SaveChanges();
            }

            //EditAndUpdateProduct();
            //GetAllProducts();
            //AddProduct();

        }

        private static void EditAndUpdateProduct()
        {
            // change the price of any product..

            // Get the object for editing or deleting by id provided..

            var dbContext = new ProductsDbContext();

            var productToEdit = dbContext.Products.Find(2);
            if (productToEdit != null)
            {
                productToEdit.Price += 1500;
            }

            dbContext.SaveChanges();
        }

        private static void GetAllProducts()
        {
            // Get all Products..

            using (ProductsDbContext dbContext = new ProductsDbContext())
            {
                var products = from pro in dbContext.Products
                               select pro;

                foreach (var prod in products)
                {
                    Console.WriteLine(prod.Name);
                }
            }
        }

        private static void AddProduct()
        {
            Product product = new Product();

            product.Name = "IPhone 16Max Pro";
            product.Price = 119999;

            using (ProductsDbContext dbContext = new ProductsDbContext())
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                Console.WriteLine("Products added.");
            }
        }
    }
}
