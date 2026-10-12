using System;
using System.Threading;

class dice
{
    private Random rnd = new Random();

    public int Throw()
    {
        return rnd.Next(1, 7);
    }
}

