public class Customer
{
    private string _name;
    private string _customerId;
    private Address _address;

    public Customer(string name, string customerId, Address address)
    {
        _name = name;
        _customerId = customerId;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetAddressText()}";
    }
}