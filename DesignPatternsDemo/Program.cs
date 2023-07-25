using System.Configuration;

namespace DesignPatternsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BillingSystem.GenerateBill();
        }
    }



    public class CalculatorFactory
    {

        private CalculatorFactory() { }

        public static readonly CalculatorFactory Instance = new CalculatorFactory();


        public ITaxCalculatorStrategy CreateTaxCalculator()
        {
            // create one tax calculator strategy and return
            string taxClassName = ConfigurationManager.AppSettings["TAXCALC"];
            //return new TNTaxCalculator();
            // Reflextion
            // convert string class to type
            Type theType = Type.GetType(taxClassName);
            return (ITaxCalculatorStrategy)Activator.CreateInstance(theType);

        }
    }

    public class BillingSystem
    {

        public static void GenerateBill()
        {
            // scan and total
            double amount = 5600;
            int discount = 120;
            double amountAfterDisc = amount - discount;
            //double tax = TaxCalculator.CalculateTax(amountAfterDisc, "TN");
            //CalculatorFactory calculatorFactory1 = CalculatorFactory.Instance;
            //CalculatorFactory calculatorFactory2 = CalculatorFactory.Instance;
            //Console.WriteLine($" calculatorFactory1 holding object id {calculatorFactory1.GetHashCode()}");
            //Console.WriteLine($" calculatorFactory2 holding object id {calculatorFactory2.GetHashCode()}");
            //CalculatorFactory calculatorFactory = CalculatorFactory.Instance;
            ITaxCalculatorStrategy taxStrategy = CalculatorFactory.Instance.CreateTaxCalculator();
            double tax = taxStrategy.CalculateTax(amountAfterDisc);
            double billingAmt = amountAfterDisc + tax;
            // generate the bill and print
        }
    }


    public interface ITaxCalculatorStrategy // strategy
    {
        double CalculateTax(double amount);
    }

    public class KATaxCalculator : ITaxCalculatorStrategy // concreate strategy - Realization
    {
        public double CalculateTax(double amount)
        {
            int kst = 100;
            int cst = 140;
            int es = 80;
            int kkt = 50;
            double tax = kst + cst + es + kkt;
            Console.WriteLine("Calculating tax for KA");
            return tax;
        }
    }

    public class TNTaxCalculator : ITaxCalculatorStrategy
    {
        public double CalculateTax(double amount)
        {
            int tst = 100;
            int cst = 140;
            int tes = 80;
            int abc = 50;
            double tax = tst + cst + tes + abc;
            Console.WriteLine("Calcuating tax for TN");
            return tax;
        }
    }


    public class MuscotTaxCalculatorAdaptor : ITaxCalculatorStrategy
    {
        public double CalculateTax(double amount)
        {
            MuscotTaxCalculator muscotTaxCalculator = new MuscotTaxCalculator();
            float tax = muscotTaxCalculator.ComputeTax((float)amount);

            return tax;
        }
    }
    // written by some one else 
    public class MuscotTaxCalculator
    {
        public float ComputeTax(float amount)
        {
            int xyz = 100;
            int abc = 140;
            int tes = 80;
            int aaa = 50;
            float tax = xyz + aaa + tes + abc;
            Console.WriteLine("Calcuating tax for Muscot");
            return tax;
        }
    }
}