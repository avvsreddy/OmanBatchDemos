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
            ide.Languages.Add(c);
            ide.Languages.Add(cs);
            ide.Languages.Add(java);
            LanguageVBNet vb = new LanguageVBNet();
            ide.Languages.Add(vb);
            ide.Work();
        }
    }


    // Problem in the code
    // Lot of duplicate code
    // ide can work with only 3 languages
    // if you want ide to work with another language, we must modify the ied class. which means ide class is not maintanable

    interface ILanguage
    {
        string GetName();
        string GetUnit();
        string GetParadigm();
    }

    class IDE // OCP
    {
        //public LanguageCSharp CSharp { get; set; }
        //public LanguageJava Java { get; set; }
        //public LanguageC C { get; set; }

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

        public void Work()
        {

            foreach (ILanguage language in Languages)
            {
                Console.WriteLine(language.GetName());
                Console.WriteLine(language.GetUnit());
                Console.WriteLine(language.GetParadigm());
            }


            //Console.WriteLine(Java.GetName());
            //Console.WriteLine(Java.GetUnit());
            //Console.WriteLine(Java.GetParadigm());

            //Console.WriteLine(C.GetName());
            //Console.WriteLine(C.GetUnit());
            //Console.WriteLine(C.GetParadigm());
        }
    }

    class LanguageCSharp : OOParadigm
    {
        public override string GetName()
        {
            return "C Sharp";
        }

    }

    abstract class OOParadigm : ILanguage
    {
        abstract public string GetName();


        public string GetParadigm()
        {
            return "OOP";
        }

        public string GetUnit()
        {
            return "Class";
        }
    }

    abstract class ProceduralParadigm : ILanguage
    {
        abstract public string GetName();


        public string GetParadigm()
        {
            return "Procedural";
        }

        public string GetUnit()
        {
            return "Function";
        }
    }

    class LanguageJava : OOParadigm
    {
        public override string GetName()
        {
            return "Java";
        }

    }

    class LanguageC : ProceduralParadigm
    {
        public override string GetName()
        {
            return "C Language";
        }

    }

    class LanguageVBNet : OOParadigm
    {
        public override string GetName()
        {
            return "VB.Net";
        }


    }
}