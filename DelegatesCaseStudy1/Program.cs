using System.Diagnostics;

namespace DelegatesCaseStudy1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Application of delegates in real world");
            // Client 1 : display all running processes
            ProcessManager.ShowProcessList(x => true);

            // Client 2 : display all running process names starts with S
            //ProcessManager.ShowProcessList("Se");
            ProcessManager.ShowProcessList(FilterByName);

            // Anonymous Delegates
            ProcessManager.ShowProcessList(delegate (Process p)
                {
                    return p.ProcessName.StartsWith("Se");
                }
            );

            // Lambda -  Light Weight Syntax for Anonymous Delegates

            // Lambda Statements
            ProcessManager.ShowProcessList((Process p) =>
            {
                return p.ProcessName.StartsWith("Se");
            }
            );

            // Lambda Expression 1
            ProcessManager.ShowProcessList((Process p) =>

                p.ProcessName.StartsWith("Se")

            );

            // Lambda Expression 2
            ProcessManager.ShowProcessList(p => p.ProcessName.StartsWith("Se"));

            // Client 3 : Display all huge processes (Memory rise bigger than 100MB)
            //ProcessManager.ShowProcessList(100 * 1024 * 1024);
            //FilterDelegate filter = new FilterDelegate(FilterByMemSize);
            //ProcessManager.ShowProcessList(filter);

            ProcessManager.ShowProcessList(p => p.WorkingSet64 >= 100 * 1024 * 1024);



        }

        // Cleint 3 delegate method
        public static bool FilterByMemSize(Process p)
        {
            if (p.WorkingSet64 >= 100 * 1024 * 1024)
            {
                return true;
            }
            else
                return false;
        }

        // client 2 delegate method
        public static bool FilterByName(Process p)
        {
            return p.ProcessName.StartsWith("Se");
        }
    }


    public delegate bool FilterDelegate(Process p);

    // Developer 1
    public class ProcessManager
    {
        //public static void ShowProcessList()
        //{
        //    foreach (Process process in Process.GetProcesses())
        //    {
        //        Console.WriteLine(process.ProcessName);
        //    }
        //}

        public static void ShowProcessList(FilterDelegate filter)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (filter(process))
                    Console.WriteLine(process.ProcessName);
            }
        }

        //public static void ShowProcessList(long memSize)
        //{
        //    foreach (Process process in Process.GetProcesses())
        //    {
        //        if (process.WorkingSet64 >= memSize)
        //            Console.WriteLine(process.ProcessName);
        //    }
        //}
    }
}