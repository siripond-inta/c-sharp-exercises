using System;
using System.Threading;

class Box
{
    private double width;
    private double height;
    private double length;

    public Box(double width, double height, double length)
    {
        this.width = width;
        this.height = height;
        this.length = length;
    }

    public Box(double side)
    {
        this.width = side;
        this.height = side;
        this.length = side;
    }

    public Box(Box oldBox)
    {
        this.width = oldBox.width;
        this.height = oldBox.height;
        this.length = oldBox.length;
    }

    public double faceArea()
    {
        return width * height;
    }

    public double topArea()
    {
        return width * length;
    }

    public double sideArea()
    {
        return height * length;
    }

    public double area()
    {
        return 2 * faceArea() + 2 * topArea() + 2 * sideArea();
    }
}