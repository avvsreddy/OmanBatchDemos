namespace SimpleCalculatorLibrary
{
    public class Calculator : ICalculator
    {
        IRepository repository = null;
        public Calculator()
        {
            repository = new FileRepository();
        }

        // DI
        public Calculator(IRepository repo)
        {
            repository = repo;
        }
        public int FindSum(int fno, int sno)
        {
            // check the business rules
            //1. Check for non-zero numbers
            if (fno == 0 || sno == 0)
            {
                throw new NonZeroNumbersException("Provide only non-zero numbers");
            }
            //2. check for +ve ints
            if (fno < 0 || sno < 0)
            {
                throw new NegativeNumbersException("Provide only positive numbers");
            }
            //3. check for even numbers
            if (fno % 2 != 0 || sno % 2 != 0)
            {
                throw new NotEvenNumberException("Provide only even numbers");
            }

            // save the result into file
            //FileRepository repository = new FileRepository();
            bool isDone = true;
            isDone = repository.SaveToFile($"{fno} + {sno} = {fno + sno}");
            //if (isDone)
            return fno + sno;
            //else
            //    return 0;

        }
    }


    public interface IRepository
    {
        bool SaveToFile(string filename);
    }

    public class FileRepository : IRepository
    {
        public bool SaveToFile(string data)
        {
            File.WriteAllText("A:\\data.txt", data);
            return true;
        }
    }
}