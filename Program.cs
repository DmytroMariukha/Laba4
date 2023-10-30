class Par
{
    protected double side1;
    protected double side2;
    protected double angle;

    public Par(double side1, double side2, double angle)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.angle = angle * Math.PI / 180; 
    }

    public virtual void Print()
    {
        Console.WriteLine($"Сторона 1: {side1}");
        Console.WriteLine($"Сторона 2: {side2}");
        Console.WriteLine($"Кут між сторонами (в радіанах): {angle}");
    }

    public virtual double Sqr()
    {
        return side1 * side2 * Math.Sin(angle);
    }

    public double Diag(out double diagonal2)
    {
        double diagonal1 = Math.Sqrt(side1 * side1 + side2 * side2 - 2 * side1 * side2 * Math.Cos(angle));
        diagonal2 = Math.Sqrt(side1 * side1 + side2 * side2 + 2 * side1 * side2 * Math.Cos(angle));
        return diagonal1;
    }
}

class Pryam : Par
{
    public Pryam(double side1, double side2) : base(side1, side2, 90) 
    {
    }

    public override double Sqr()
    {
        return side1 * side2;
    }

    public double Radius()
    {
        return Math.Sqrt(side1 * side1 + side2 * side2) / 2;
    }
}

class Program
{
    static void Main()
    {
        Par shape;

        Random random = new Random();

        for (int i = 0; i < 3; i++)
        {
            double side1 = random.Next(1, 10);
            double side2 = random.Next(1, 10);

            if (i % 2 == 0)
            {
                shape = new Par(side1, side2, random.Next(1, 180));
                Console.WriteLine("Створено паралелограм:");
            }
            else
            {
                shape = new Pryam(side1, side2);
                Console.WriteLine("Створено прямокутник:");
            }

            shape.Print();
            Console.WriteLine($"Площа: {shape.Sqr()}");

            if (shape is Pryam)
            {
                Pryam rectangle = (Pryam)shape;
                Console.WriteLine($"Радіус описаного кола: {rectangle.Radius()}");
            }

            Console.WriteLine();
        }
    }
}
