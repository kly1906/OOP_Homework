public class BillLine
{
    public Item Item { get; set; }
    public int Quantity { get; set; }

    public BillLine(Item item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return Item.GetPrice() * Quantity;
    }

    public double GetTotalDiscount()
    {
        return Item.GetDiscount() * Quantity;
    }
}
