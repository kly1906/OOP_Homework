class Program
{
    static void Main()
    {
        Employee clerk = new Employee("Tam");

        // Tạo các mặt hàng
        Item candyBar = new Item("Candy Bar", 1.35, 0.25);
        Item soda = new Item("Soda", 2.50, 0.0);
        Item chips = new Item("Chips", 3.00, 0.50);

        // Tạo các dòng hóa đơn
        BillLine CandyBar = new BillLine(candyBar, 2);
        BillLine Soda = new BillLine(soda, 1);
        BillLine Chips = new BillLine(chips, 3);

        DiscountBill discountBill = new DiscountBill(clerk, true);
        discountBill.Add(CandyBar);
        discountBill.Add(Soda);
        discountBill.Add(Chips);

        discountBill.PrintReceipt();
        discountBill.PrintDiscountDetails();
    }
}
public class Employee
{ 
        public string Name { get; set; }

        public Employee(string name)
        {
            Name = name;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }

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

    public class GroceryBill
    {
        private BillLine[] billLines;
        private int itemCount = 0;
        public Employee Clerk { get; set; }

        public GroceryBill(Employee clerk)
        {
            Clerk = clerk;
            billLines = new BillLine[10]; 
        }

        public void Add(BillLine billLine)
        {
            if (itemCount < billLines.Length)
            {
                billLines[itemCount] = billLine;
                itemCount++;
            }
        }

        public double GetTotal()
        {
            double total = 0;
            for (int i = 0; i < itemCount; i++)
            {
                total += billLines[i].GetTotalPrice();
            }
            return total;
        }

        public void PrintReceipt()
        {
            Console.WriteLine($"Receipt (Clerk: {Clerk.Name}):");
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine($"{billLines[i].Item.Name} x{billLines[i].Quantity} - {billLines[i].GetTotalPrice():C}");
            }
            Console.WriteLine($"Total: {GetTotal():C}");
        }
    }


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
