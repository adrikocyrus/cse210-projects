using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - customer in the USA
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Sarah Johnson", "C-1001", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P-100", 800.00, 1));
        order1.AddProduct(new Product("Mouse", "P-101", 20.00, 2));
        order1.AddProduct(new Product("Keyboard", "P-102", 40.00, 1));

        // Order 2 - customer outside the USA
        Address address2 = new Address("45 Kira Road", "Kampala", "Central Region", "Uganda");
        Customer customer2 = new Customer("Adriko Cyrus", "C-1002", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Headphones", "P-200", 60.00, 1));
        order2.AddProduct(new Product("Phone Case", "P-201", 15.00, 3));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("----------------------------------------");
        order.DisplayProducts();
        Console.WriteLine();
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order.CalculateTotal():F2}");
        Console.WriteLine();
    }
}