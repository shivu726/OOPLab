using Microsoft.EntityFrameworkCore;
using ProductsManagement.Data;
using ProductsManagement.Entities;

namespace ProductsManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new ProductsDbContext();

                                // This is eager loading..
            var products = from prod in dbContext.Products.Include(c => c.Category) select prod;    

            foreach (var product in products)
            {
                Console.WriteLine(product.Name + "\t" + product.Category.Name);
            }

            //CreateProductByCategory();

            //NewProductAndCategory();

            //DeleteProduct();
            //EditAndUpdateProduct();
            //GetAllProducts();
            //AddProduct();

        }

        private static void CreateProductByCategory()
        {
            // New product with existing category..

            var dbContext = new ProductsDbContext();

            var category = dbContext.Categories.Find(1);

            var product = new Product() { Name = "IPhone 16Max Pro", Brand = "Apple", Price = 99999, Category = category };

            dbContext.Products.Add(product);

            dbContext.SaveChanges();
        }

        private static void NewProductAndCategory()
        {
            ProductsDbContext context = new ProductsDbContext();

            var category = new Category() { Name = "Mobile", Description = "Mobile Phones" };

            var product = new Product() { Name = "IPhone 16", Brand = "Apple", Price = 89999, Category = category };

            context.Products.Add(product);
            context.Categories.Add(category);   // it will be optional...

            context.SaveChanges();
        }

        private static void DeleteProduct()
        {
            // Delete the product from database based on Id..

            ProductsDbContext dbContext = new ProductsDbContext();
            var deleteProd = dbContext.Products.Find(3);

            if (deleteProd != null)
            {

                dbContext.Remove(deleteProd);
                dbContext.SaveChanges();
            }
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
