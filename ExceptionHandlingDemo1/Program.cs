namespace ExceptionHandlingDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // accept two  even ints and find the sum repeatedly

            while (true)
            {
                try // primary path
                {
                    int fno;
                    int sno;
                    int sum = 0;
                    Console.Write("Enter First Number: ");
                    fno = int.Parse(Console.ReadLine());
                    Console.Write("Enter Second Number: ");
                    sno = int.Parse(Console.ReadLine());
                    sum = Calculator.FindSum(fno, sno);
                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                }

                // alternative path for format exp
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter only numbers");
                }
                catch (NotEvenNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }                //catch (OverflowException ex)
                //{
                //    Console.WriteLine("Enter small number");
                //}
                // catch all exp block
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    Console.WriteLine("Done...");
                }
            }
        }
    }


    /* this is multi line
     * comment
     * */


    /// <summary>
    /// Calculator class will be used to calculate simple mathematical values
    /// </summary>
    public class Calculator // back-end code
    {

        /// <summary>
        /// Find the sum of two even ints
        /// </summary>
        /// <param name="a">first int</param>
        /// <param name="b">second int</param>
        /// <returns>the sum of two ints</returns>
        /// <exception cref="NotEvenNumberException"></exception>
        public static int FindSum(int a, int b)
        {
            if (a % 2 == 0 && b % 2 == 0)
            {
                try
                {
                    //DBManager.Save($"The sum of {a} and {b} is {a + b}");
                    return a + b;
                }
                catch (Exception ex)
                {
                    //log the exp
                    // serilog, nlog, log4net ......

                    File.WriteAllText("e:logs/log.txt", "Unable to save data into db");
                    throw ex;
                }
            }
            else
                //return "Enter only even numbers";
                throw new NotEvenNumberException("Provide only even numbers for finding the sum");

        }
    }

    public class NotEvenNumberException : ApplicationException
    {
        public NotEvenNumberException(string msg) : base(msg)
        {
            //this.Message = msg;
        }
    }

    public class DBManager // DAL
    {
        public static void Save(string data)
        {
            // open db connection 
            // save data
            //sdfsdfsdf
            //sdfsdfsdf
            throw new Exception("DB Error");
        }
    }
}