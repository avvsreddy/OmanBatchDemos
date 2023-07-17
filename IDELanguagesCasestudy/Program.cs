namespace IDELanguagesCasestudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            LanguageC c = new LanguageC();
            LanguageCSharp cs = new LanguageCSharp();
            LanguageJava java = new LanguageJava();
            ide.CSharp = cs;
            ide.Java = java;
            ide.C = c;

            ide.Work();
        }
    }


    // Problem in the code
    // Lot of duplicate code
    // ide can work with only 3 languages
    // if you want ide to work with another language, we must modify the ied class. which means ide class is not maintanable
    class IDE
    {
        public LanguageCSharp CSharp { get; set; }
        public LanguageJava Java { get; set; }
        public LanguageC C { get; set; }

        public void Work()
        {
            Console.WriteLine(CSharp.GetName());
            Console.WriteLine(CSharp.GetUnit());
            Console.WriteLine(CSharp.GetParadigm());

            Console.WriteLine(Java.GetName());
            Console.WriteLine(Java.GetUnit());
            Console.WriteLine(Java.GetParadigm());

            Console.WriteLine(C.GetName());
            Console.WriteLine(C.GetUnit());
            Console.WriteLine(C.GetParadigm());
        }
    }

    class LanguageCSharp
    {
        public string GetName()
        {
            return "C Sharp";
        }
        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "OOP";
        }
    }

    class LanguageJava
    {
        public string GetName()
        {
            return "Java";
        }
        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "OOP";
        }
    }

    class LanguageC
    {
        public string GetName()
        {
            return "C Language";
        }
        public string GetUnit()
        {
            return "Function";
        }
        public string GetParadigm()
        {
            return "Procedural";
        }
    }
}