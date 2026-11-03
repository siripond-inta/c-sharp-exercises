using System;

// ชื่อ class ต้องเป็นตัวพิมพ์ใหญ่
class Dice
{
    private Random rnd = new Random();

    public int Throw()
    {
        return rnd.Next(1, 7);
    }
}
