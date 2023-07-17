namespace InheritanceDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ref. variable of a base class can hold object of derived class - Dynamic Polymorphism

            //Shape s = new Shape();
            Triangle t = new Triangle();
            t.W = 10;
            t.H = 10;
            WorkWithShape(t);

        }

        static void WorkWithShape(Shape s)
        {
            Console.WriteLine(s.Draw);
            Console.WriteLine(s.CalcuateArea());
        }


    }


    //abstract class BankAccount
    interface BankAccount
    {
        void Open();// { }

        void Close();// { }

    }

    interface Contract2
    {

    }

    interface Contract3
    {

    }

    class SavingsBankAccount : BankAccount, Contract2, Contract3
    {
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Shape
    {
        public int W { get; set; }
        public int H { get; set; }
        abstract public void Draw();
        //{
        // Console.WriteLine("Drawing Shape");
        //}
        public virtual int CalcuateArea() // instance methods
        {
            Console.WriteLine("Calculating Shape area");
            return W * H;
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }

    class Triangle : Shape
    {
        public override int CalcuateArea() // instance methods
        {
            Console.WriteLine("Calculating Triangle area");
            return W * H / 2;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}