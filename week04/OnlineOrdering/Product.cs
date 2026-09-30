using System;

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingText()
    {
        return $"{_name} (ID: {_productId})";
    }

    public void DisplayProduct()
    {
        Console.WriteLine($"{_name} (ID: {_productId}) - ${_price:F2} x {_quantity} = ${GetTotalCost():F2}");
    }
}