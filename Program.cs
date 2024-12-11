class Program
{
    static void Main()
    { 
        Employee clerk = new Employee("Tam");

        Item candyBar = new Item("Candy Bar", 1.35, 0.25);
        Item soda = new Item("Soda", 2.50, 0.0);
        Item chips = new Item("Chips", 3.00, 0.50);

        BillLine CandyBar = new BillLine(candyBar, 2);
        BillLine Soda = new BillLine(soda, 1);
        BillLine Chips = new BillLine(chips, 3);

        DiscountBill discountBill = new DiscountBill(clerk, true);
        discountBill.Add(CandyBar);
        discountBill.Add(Soda);
        discountBill.Add(Chips);

        discountBill.PrintReceipt();
        discountBill.PrintDiscountDetails();

        Console.ReadKey();
    }
}