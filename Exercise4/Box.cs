using System;

class Box
{
    private double width;
    private double height;
    private double length;

    public Box(double width, double height, double length)
    {
        this.width  = width;
        this.height = height;
        this.length = length;
    }

    public Box(double side)
    {
        this.width  = side;
        this.height = side;
        this.length = side;
    }

    public Box(Box oldBox)
    {
        this.width  = oldBox.width;
        this.height = oldBox.height;
        this.length = oldBox.length;
    }

    // คำนวณพื้นที่ผิวทั้งหมดจากพื้นที่ผิวแต่ละด้าน
    public double FaceArea()  => width * height;
    public double TopArea()   => width * length;
    public double SideArea()  => height * length;
    public double Area()      => 2 * FaceArea() + 2 * TopArea() + 2 * SideArea();

    public override string ToString()
        => $"Box({width} x {height} x {length}) | Surface Area = {Area():F2}";
}
