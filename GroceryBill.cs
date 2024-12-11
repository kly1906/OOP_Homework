public class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
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
        billLines = new BillLine[10];  // Mảng lưu tối đa 10 BillLine
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

