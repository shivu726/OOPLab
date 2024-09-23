public class Program
{
    public static void Main(string[] args)
    {
        var products = GetProducts();

        var result1 = products.Where(x => x.Price >= 50000 && x.Price <= 80000).Select(x => x);

        Console.WriteLine("Products whose price between 50k to 80k.");
        foreach (var product in result1)
        {            
            Console.WriteLine($"Name - {product.Name}, Category - {product.Catagory.Name}, Price - {product.Price}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------");

        var result2 = products.Where(x => x.Catagory.Name == "Laptops").Select(x => x);
        Console.WriteLine("Products of Laptop category.");
        foreach (var product in result2)
        {
            Console.WriteLine($"Name - {product.Name}, Category - {product.Catagory.Name}, Price - {product.Price}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------");

        var result3 = products.Select(x => x);
        Console.WriteLine("Products Name and Category.");
        foreach (var product in result3)
        {
            Console.WriteLine($"Name - {product.Name}, Category - {product.Catagory.Name}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        var costlyProduct = products.Select(x => x).OrderByDescending(x => x.Price).First();
        Console.WriteLine("Costliest product from the list is.");
        Console.WriteLine($"Name - {costlyProduct.Name}, Category - {costlyProduct.Catagory.Name}, Price - {costlyProduct.Price}");

        Console.WriteLine("-----------------------------------------------------------------------------------------");

        var result4 = products.Select(x => x).OrderBy(x => x.Price).First();
        Console.WriteLine("Cheapest product from the list is.");
        Console.WriteLine($"Name - {result4.Name}, Category - {result4.Catagory.Name}, Price - {result4.Price}");

        Console.WriteLine("-----------------------------------------------------------------------------------------");

        var result5 = products.OrderBy(x => x.Price).Skip(1).Take(2);
        Console.WriteLine("2nd and 3rd highest Product from the list.");
        foreach (var product in result5)
        {
            Console.WriteLine($"Name - {product.Name}, Category - {product.Catagory.Name}, Price - {product.Price}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------");

        var result6 = products.OrderBy(x => x.Price);
        Console.WriteLine("Product in ascending order of price.");
        foreach (var product in result6)
        {
            Console.WriteLine($"Name - {product.Name}, Category - {product.Catagory.Name}, Price - {product.Price}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------");

        var productCount = products.Where(x => x.Catagory.Name == "Tablets").Count();
        Console.WriteLine($"Total count of the Tablets products is: {productCount}");

        Console.WriteLine("-----------------------------------------------------------------------------------------");

        //var result7 = from prod in products
        //              group prod by prod.Catagory.CatagoryID into cat
        //              select (from prod in cat orderby prod.Price descending select prod).First();

        var result7 = (from prod in products
                       orderby prod.Price descending
                       select prod).First();

        Console.WriteLine($"Category {result7.Catagory.Name} has the costliest product of price -  {result7.Price}");

        var result8 = (from prod in products
                       orderby prod.Price ascending
                       select prod).Select(x => x.Catagory).First();







        Console.ReadLine();

    }

    static List<Product> GetProducts()
    {
        Catagory cat1 = new Catagory { CatagoryID = 101, Name = "Laptops" };
        Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
        Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

        Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
        Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
        Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
        Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
        Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

        cat1.Products.Add(p1);
        cat1.Products.Add(p2);
        cat2.Products.Add(p3);
        cat2.Products.Add(p4);
        cat3.Products.Add(p5);

        List<Product> products = new List<Product>();
        products.Add(p1);
        products.Add(p2);
        products.Add(p3);
        products.Add(p4);
        products.Add(p5);

        return products;
    }

    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
    }
    class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}
