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

        //เงื่อนไขซ้ำซ้อน รวมการเช็คเหรียญ 1 5 10 เปลี่ยนเป็นการเขียนแบบ short hand
        for (int i = 0; i < money.Length; i++)
        {
            if (money[i] >= 20)
            {
                Console.Write($"แบงค์ {money[i]}: ");
            }
            else
            {
                Console.Write($"เหรียญ {money[i]}: ");
            }
            // stock[money[i]] = int.Parse(Console.ReadLine());
            //เพิ่ม input validation 
            if (!int.TryParse(Console.ReadLine(), out int amount) || amount < 0)
            {
                Console.WriteLine("กรุณาใส่ตัวเลขที่ถูกต้อง");
                i--;
                continue;
            }
            stock[money[i]] = amount;
        }

        while (true)
        {
            Console.Write("\nต้องการทอน: ");
            // string input = Console.ReadLine();
            string input = Console.ReadLine() ?? string.Empty; // อาจ return null

            if (input == "-1")
            {
                break;
            }

            // int changeNeeded = int.Parse(input);
            if (!int.TryParse(input, out int changeNeeded) || changeNeeded < 0)
            {
                Console.WriteLine("กรุณาใส่ตัวเลขที่ถูกต้อง");
                continue;
            }
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

                int countToUse = Math.Min(countNeeded, countAvailable); //ใช้ math.min แทนการเขียน if else

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
                    Console.WriteLine($"ใช้แบงค์ {denom}: {countUsed} เหลือ {stock[denom]}");
                }
                else
                {
                    Console.WriteLine($"ใช้เหรียญ {denom}: {countUsed} เหลือ {stock[denom]}");
                }
            }
        }
    }
}