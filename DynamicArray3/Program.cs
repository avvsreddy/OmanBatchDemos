namespace DynamicArray3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept day number and display day name without using any conditional stmt
            // ex: 1 - Sunday, 2 - Monday, 7 - Saturday

            Dictionary<int, string> day = new Dictionary<int, string>();
            day.Add(1, "Sun");
            day.Add(2, "Mon");
            day.Add(3, "Tue");
            int dayNo;
            Console.Write("Enter day number:");
            dayNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(day[dayNo]);
            //switch (dayNo)
            //{
            //    case 1: Console.WriteLine("Sunday"); break;
            //    case 2: Console.WriteLine("Monday"); break;
            //    case 3: Console.WriteLine("Tuesday"); break;
            //    default:
            //        Console.WriteLine("Invalid day number");
            //        break;
            //}

            // want a collection to store deptno and its employee names

            Dictionary<int, List<string>> empList = new Dictionary<int, List<string>>();
            List<string> names1 = new List<string>();
            names1.Add("AAAA1");
            names1.Add("AAAA2");
            names1.Add("AAAA3");

            List<string> names2 = new List<string>();
            names2.Add("BBBB1");
            names2.Add("BBBB2");
            names2.Add("BBBB3");

            empList.Add(111, names1);
            empList.Add(222, names2);




        }
    }
}