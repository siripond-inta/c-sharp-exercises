using System;

class Program
{
    static void Main(string[] args)
    {
        decimal balance = 100; //เปลี่ยนเป็น decimal เพราะเป็น Type สำหรับเงิน
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Account");
            Console.WriteLine("=======");
            Console.WriteLine(" 1. Deposit");
            Console.WriteLine(" 2. Withdraw");
            Console.WriteLine(" 3. Check Balance");
            Console.WriteLine(" 0. Exit");
            Console.Write("Select number : ");

             string choice = Console.ReadLine() ?? string.Empty;
            Console.WriteLine();

            // แยกเป็น case ของแต่ละเมนู กับ method แต่ละเมนู
    switch (choice)
            {
                case "1":
                    balance = Deposit(balance);
                    WaitUser();
                    break;
                case "2":
                    balance = Withdraw(balance);
                    WaitUser();
                    break;
                case "3":
                    PrintBalance(balance);
                    WaitUser();
                    break;
                case "0":
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please choose 0-3.");
                    WaitUser();
                    break;
            }
        }
    }

    static decimal Deposit(decimal balance)
    {
         Console.Write("Enter amount to deposit: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
            return balance;
        }
        balance += amount;
        Console.WriteLine($"Account balance is {balance}"); //ใช้ $ ในการรวม string กับตัวแปร
        return balance;
    }

    static decimal Withdraw(decimal balance)
    {
        Console.Write("Enter amount to withdraw: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a positive number.");
            return balance;
        }
        if (balance - amount < 100)
        {
            Console.WriteLine("Cannot withdraw because money will be less than 100");
            return balance;
        }
        balance -= amount;
        Console.WriteLine($"Account balance is : {balance}");
        return balance;
    }

    static void PrintBalance(decimal balance)
    {
        Console.WriteLine($"Account balance is: {balance}");
    }

    static void WaitUser()
    {
        Console.Write("Press any key...");
        Console.ReadKey();
    }
}