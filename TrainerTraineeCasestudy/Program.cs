namespace TrainerTraineeCasestudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Organization
    {
        public string Name { get; set; }
    }
    public class Trainer
    {
        private Organization org = new Organization();

        //private List<Trainee> Trainees = new List<Trainee>(); // Field

        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();
        public string GetOrganization()
        {
            return org.Name;
        }
    }

    public class Trainee
    {
        //private Trainer trainer = new Trainer();
        public Trainer Trainer { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
    }

    public class Training
    {
        //private Trainer trainer = new Trainer;
        public Trainer Trainer { get; set; }

        public List<Trainee> Trainees { get; set; } = new List<Trainee>();

        public Course Course { get; set; }
    }

    public class Course
    {

        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();

    }

    public class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }

    public class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }

    public class Topic
    {
        public string Name { get; set; }
    }
}