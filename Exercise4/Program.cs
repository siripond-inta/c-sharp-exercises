using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Test Dice ---");
        int mark = 0;
        int i = 1;
        dice dic1 = new dice();

        while (mark != 1)
        {
            mark = dic1.Throw();
            Console.WriteLine(" {0} Mark of Dice : {1} ", i, mark); 
            Thread.Sleep(10); 
            i++;
        }
        Console.WriteLine("Throw of dice = 1 is : " + (i - 1) + " time"); 
        Console.WriteLine("\n----------------------------\n");
        Console.WriteLine("--- Test Snake Eyes ---");

        dice d1 = new dice();
        dice d2 = new dice();

        int count = 0;
        int m1 = 0;
        int m2 = 0;

        while (true)
        {
            count++;
            m1 = d1.Throw();
            m2 = d2.Throw();

            Console.WriteLine("Round " + count + " : Dice 1 = " + m1 + ", Dice 2 = " + m2);
            Thread.Sleep(10);

            if (m1 == 1 && m2 == 1)
            {
                break;
            }
        }

        Console.WriteLine("\nTotal rolls: " + count + " times");
        Console.ReadLine();
    }
}