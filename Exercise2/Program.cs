using System;

class Program
{
    static void Main(string[] args)
    {
        int balance = 100;
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

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": // ฝากเงิน
                    Console.Write("Enter money to deposit : ");
                    int depositAmount = int.Parse(Console.ReadLine());
                    
                    if (depositAmount > 0)
                    {
                        balance += depositAmount;
                        Console.WriteLine("Account balance is : " + balance);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    WaitUser();
                    break;

                case "2": // ถอนเงิน
                    Console.Write("Enter money to withdraw : ");
                    int withdrawAmount = int.Parse(Console.ReadLine());

                    if (withdrawAmount > 0)
                    {
                        // เช็คว่าถอนแล้วเหลือต่ำกว่า 100 บาทหรือไม่
                        if (balance - withdrawAmount < 100)
                        {
                            Console.WriteLine("Cannot withdraw because money will less 100");
                        }
                        else
                        {
                            balance -= withdrawAmount;
                            Console.WriteLine("Account balance is : " + balance);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    WaitUser();
                    break;

                case "3": // เช็คยอดเงิน
                    Console.WriteLine("Account balance is : " + balance);
                    WaitUser();
                    break;

                case "0": // จบ
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection.");
                    WaitUser();
                    break;
            }
        }
    }

    static void WaitUser()
    {
        Console.Write("Press any key...");
        Console.ReadKey();
    }
}