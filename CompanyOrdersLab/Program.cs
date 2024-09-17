

internal class Program
{
    static void Main(string[] args)
    {
        Company company = new Company();

        Customer c1 = new Customer();
        Customer c2 = new Customer();

        company.Customers.Add(c1);
        company.Customers.Add(c2);

        //RegisterCustomer registerCustomer1 = new RegisterCustomer();
        //RegisterCustomer registerCustomer2 = new RegisterCustomer();

        //company.Customers.Add(registerCustomer1);
        //company.Customers.Add(registerCustomer2);

        Console.WriteLine($"No. of all customer in a company: {company.Customers.Count}");
        // Console.WriteLine($"No. of normal customer in a company: {company.Customers.Count}");
        // Console.WriteLine($"No. of registered customer in a company: {company.Customers.Count}");


        Order order1 = new Order();
        c1.Orders.Add(order1);

        Order order2 = new Order();
        c2.Orders.Add(order2);

        Item item1 = new Item() { Description = "IPhone", Rate = 75000 };
        OrderItem orderItem1 = new OrderItem();
        orderItem1.Item = item1;
        orderItem1.Quantity = 2;       

        Item item2 = new Item() { Description = "Galaxy Watch", Rate = 15000 };
        OrderItem orderItem2 = new OrderItem() { Item = item2, Quantity = 5 };

        //company.Items.Add(item1);
        //company.Items.Add(item2);

        order1.OrderItems.Add(orderItem1);
        order2.OrderItems.Add(orderItem2);

        Console.WriteLine(company.GetTotalWorthOfOrdersPlaced());
    }
}

class Company
{
    public List<Customer> Customers { get; set; } = new List<Customer>();

    public List<Item> Items { get; set; } = new List<Item>();
    public double GetTotalWorthOfOrdersPlaced()
    {
        double total = 0;
        foreach (Customer customer in Customers)
        {
            var data = customer.Orders.FirstOrDefault();

            var item = data.OrderItems.FirstOrDefault().Item.Rate;

            var itemQty = data.OrderItems.FirstOrDefault().Quantity;

            total += itemQty * item;

        }
        

        // TO DO..

        return total;
    }
}

public class Item
{
    public string? Description { get; set; }

    public double Rate { get; set; }
}

public class Customer
{
    public List<Order> Orders { get; set; } = new List<Order>();
}

public class OrderItem
{
    public Item Item { get; set; } = new Item();
    public int Quantity { get; set; }

}

public class Order // Is - A relationship
{
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

public class RegisterCustomer : Customer
{
    public double SpecialDiscount { get; set; }

    //public double GetSpecialDiscount()
    //{
    //    return SpecialDiscount;
    //}
}
