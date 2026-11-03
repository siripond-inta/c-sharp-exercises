using System;
using System.Threading;

class Program
{
    static void PrintHeader(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 45));
        Console.WriteLine($"  {title}");
        Console.WriteLine(new string('=', 45));
    }

    // เพิ่มการนำ class Box และ Dice มาใช้
    // ปรับให้ดูอ่านง่ายขึ้น
    static void Main(string[] args)
    {
        // ข้อ 1
        PrintHeader("Exercise 1 : Box Demo");

        Box b1 = new Box(3.0, 4.0, 5.0);
        Box b2 = new Box(6.0);          // ลูกบาศก์
        Box b3 = new Box(b1);           // copy จาก b1

        Console.WriteLine("b1 : " + b1);
        Console.WriteLine("b2 : " + b2);
        Console.WriteLine("b3 : " + b3);

        // ข้อ 2 โยนลูกเต๋าจนได้ 1
        PrintHeader("Exercise 2 : Roll Until 1");

        Dice dic1 = new Dice();
        int mark = 0;
        int i    = 1;

        while (mark != 1)
        {
            mark = dic1.Throw();
            Console.WriteLine($"  Roll {i,4} | Value : {mark}");
            Thread.Sleep(10);
            i++;
        }
        Console.WriteLine($"\n  Rolled {i - 1} time(s) before getting 1.");

        // ข้อ 3: Snake Eyes 
        PrintHeader("Exercise 3 : Snake Eyes");

        Dice d1    = new Dice();
        Dice d2    = new Dice();
        int  count = 0;
        int  m1, m2;

        do
        {
            count++;
            m1 = d1.Throw();
            m2 = d2.Throw();
            Console.WriteLine($"  Round {count,4} | Dice1 = {m1}  Dice2 = {m2}"
                              + (m1 == 1 && m2 == 1 ? "  << Snake Eyes!" : ""));
            Thread.Sleep(10);
        }
        while (!(m1 == 1 && m2 == 1));

        Console.WriteLine($"\n  Snake Eyes appeared after {count} roll(s).");

        Console.WriteLine();
        Console.Write("Press Enter to exit...");
        Console.ReadLine();
    }
}
