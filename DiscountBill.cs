public class DiscountBill : GroceryBill
{
    private bool preferredCustomer;
    private double totalDiscount = 0;
    private int discountItemCount = 0;

    public DiscountBill(Employee clerk, bool preferredCustomer) : base(clerk)
    {
        this.preferredCustomer = preferredCustomer;
    }

    public new void Add(BillLine billLine)
    {
        base.Add(billLine);

        if (preferredCustomer && billLine.Item.GetDiscount() > 0)
        {
            discountItemCount++;
            totalDiscount += billLine.GetTotalDiscount();
        }
    }

    public double GetDiscountAmount()
    {
        return totalDiscount;
    }

    public double GetDiscountPercent()
    {
        double originalTotal = GetTotal() + totalDiscount;
        return (totalDiscount / originalTotal) * 100;
    }

    public new double GetTotal()
    {
        double total = base.GetTotal() - totalDiscount;
        return total;
    }

    public void PrintDiscountDetails()
    {
        Console.WriteLine($"Total Discount: {GetDiscountAmount():C}");
        Console.WriteLine($"Discount Percent: {GetDiscountPercent():0.00}%");
        Console.WriteLine($"Discounted Item Count: {discountItemCount}");
    }
}