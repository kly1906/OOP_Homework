internal class Program
{

    private static void Main(string[] args)
    {
        MyDate md1 = new MyDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        Console.WriteLine("{0}/{1}/{2}", md1.Day, md1.Month, md1.Year);

        PersonManager manager = new PersonManager();
        Person[] people = new Person[3];

        // nhap thong tin 3 nguoi 
        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine($"\nInput Information of Person {i + 1}:");
            people[i] = manager.InputPersonInfo();
        }

        // hien thi thon tin 3 nguoi da nhap
        Console.WriteLine("\nInformation of Person you have entered:");
        foreach (var person in people)
        {
            person.DisplayPersonInfo();
        }

        // sap xep va hien thi ket qua
        Console.WriteLine("\nSorted Information by Salary:");
        people = manager.SortBySalary(people);

        // hien thi cac doi tuong 
        foreach (var person in people)
        {
            person.DisplayPersonInfo();
        }
    }
}

public class Person
{
    public string Name;
    public string Address;
    public double Salary;

    // Constructor
    public Person(string name, string address, double salary)
    {
        Name = name;
        Address = address;
        Salary = salary;
    }

    // hien thi thong tin nguoi 
    public void DisplayPersonInfo()
    {
        Console.WriteLine($"Name: {Name}\tAddress: {Address}\tSalary: {Salary}");
    }
}

public class PersonManager
{
    // nhap thong tin nguoi
    public Person InputPersonInfo()
    {
        string name, address;
        double salary;

        Console.Write("Name: ");
        name = Console.ReadLine();

        Console.Write("Address: ");
        address = Console.ReadLine();

        while (true)
        {
            Console.Write("Salary: ");
            string salaryInput = Console.ReadLine();

            if (double.TryParse(salaryInput, out salary))
            {
                if (salary <= 0) // luong phai lon hon 0
                {
                    Console.WriteLine("Salary must be greater than zero");
                }
                else break;
            }
            else
            {
                Console.WriteLine("You must input digit!");
            }
        }

        // tao doi tuong voi ten, dia chi, luong da nhap
        return new Person(name, address, salary);
    }

    // sap xep theo luong tang dan
    public Person[] SortBySalary(Person[] persons)
    {
        bool swapped;
        for (int i = 0; i < persons.Length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < persons.Length - 1 - i; j++)
            {
                if (persons[j].Salary > persons[j + 1].Salary)
                {
                    // 
                    var temp = persons[j];
                    persons[j] = persons[j + 1];
                    persons[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped)
            {
                break;
            }
        }
        return persons;
    }
}