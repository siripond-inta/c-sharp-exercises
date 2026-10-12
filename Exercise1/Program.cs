using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] money = { 1000, 500, 100, 50, 10, 5, 1 };
        Dictionary<int, int> stock = new Dictionary<int, int>();

        Console.WriteLine("จำนวนเงินเริ่มต้น");
        for (int i = 0; i < money.Length; i++)
        {
            if (money[i] >= 20)
            {
                Console.Write("แบงค์ " + money[i] + ": ");
            }
            else if (money[i] == 1)
            {
                Console.Write("เหรียญ 1: ");
            }
            else
            {
                Console.Write("เหรียญ " + money[i] + ": ");
            }
            stock[money[i]] = int.Parse(Console.ReadLine());
        }

        while (true)
        {
            Console.Write("\nต้องการทอน: ");
            string input = Console.ReadLine();

            if (input == "-1")
            {
                break;
            }

            int changeNeeded = int.Parse(input);
            int totalCash = 0;

            foreach (KeyValuePair<int, int> item in stock)
            {
                totalCash += item.Key * item.Value;
            }

            if (changeNeeded > totalCash)
            {
                Console.WriteLine("ไม่สามารถทอนได้ เนื่องจาก เงินไม่พอ");
                continue;
            }

            int remaining = changeNeeded;
            Dictionary<int, int> used = new Dictionary<int, int>();

            for (int i = 0; i < money.Length; i++)
            {
                int denom = money[i];
                int countNeeded = remaining / denom;
                int countAvailable = stock[denom];

                int countToUse = 0;
                if (countNeeded < countAvailable)
                {
                    countToUse = countNeeded;
                }
                else
                {
                    countToUse = countAvailable;
                }

                if (countToUse > 0)
                {
                    used[denom] = countToUse;
                    remaining -= countToUse * denom;
                }
            }

            if (remaining > 0)
            {
                Console.WriteLine("ไม่สามารถทอนได้ เนื่องจาก ไม่มีเศษ");
                continue;
            }

            foreach (KeyValuePair<int, int> kvp in used)
            {
                int denom = kvp.Key;
                int countUsed = kvp.Value;

                stock[denom] -= countUsed;

                if (denom >= 20)
                {
                    Console.WriteLine("ใช้แบงค์" + denom + ": " + countUsed + " เหลือ " + stock[denom]);
                }
                else if (denom == 1)
                {
                    Console.WriteLine("ใช้เหรียญบาท: " + countUsed + " เหลือ " + stock[denom]);
                }
                else
                {
                    Console.WriteLine("ใช้เหรียญ" + denom + ": " + countUsed + " เหลือ " + stock[denom]);
                }
            }
        }
    }
}