public class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }

    public Item() 
    {
        Name = "";
        Price = 0;
        Discount = 0;
    }
    public Item(string name, double price, double discount)
    {
        Name = name;
        Price = price;
        Discount = discount;
    }

    public double GetPrice()
    {
        return Price;
    }

    public double GetDiscount()
    {
        return Discount;
    }
}