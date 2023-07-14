namespace TrainerTraineeCasestudy
{
    internal class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");
            Training dotNetTraining = new Training();
            Trainer venkat = new Trainer();
            dotNetTraining.Trainer = venkat;
            Organization org = new Organization();
            org.Name = "IIHT";
            venkat.Organization = org;
            Console.WriteLine("Org Name: " + dotNetTraining.GetTrainingOrgnizationName());

            // get trainees count
            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            dotNetTraining.Trainees.Add(t1);
            dotNetTraining.Trainees.Add(t2);
            Console.WriteLine("Trainees Count " + dotNetTraining.GetNumberOfTrainees());

            // get the training duration


            Course course = new Course();
            dotNetTraining.Course = course;
            Module m1 = new Module();
            Module m2 = new Module();
            course.Modules.Add(m1);
            course.Modules.Add(m2);

            Unit u1 = new Unit { Duration = 10 };
            Unit u2 = new Unit { Duration = 20 };
            m1.Units.Add(u1);
            m1.Units.Add(u2);
            Unit u3 = new Unit { Duration = 10 };
            Unit u4 = new Unit { Duration = 20 };
            m2.Units.Add(u3);
            // m2.Units.Add(u4);
            Console.WriteLine("Duration :" + dotNetTraining.GetTrainingDuration());
        }

    }

    public class Organization
    {
        public string Name { get; set; }
    }








    public class Trainer
    {
        //private Organization org = new Organization();
        public Organization Organization { get; set; }
        //private List<Trainee> Trainees = new List<Trainee>(); // Field

        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();
        public string GetOrganization()
        {
            return Organization.Name;
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


        public string GetTrainingOrgnizationName()
        {
            return Trainer.GetOrganization();
        }

        public int GetNumberOfTrainees()
        {
            return Trainees.Count;
        }

        public int GetTrainingDuration()
        {
            int duration = 0;
            // for each module
            foreach (Module module in Course.Modules)
            {
                // for each unit in a moudule
                foreach (Unit unit in module.Units)
                {
                    //duration += unit.Duration;
                    duration = duration + unit.Duration;
                }
            }
            return duration;
        }
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