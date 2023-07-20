using AddressBook.DataLayer;
using AddressBook.DataLayer.Entities;

namespace AddressBook.PresentationLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to My Address Book");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Save Contact");
                Console.WriteLine("2. View All Contacts");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Edit Contact");
                Console.WriteLine("6. Exit");
                Console.WriteLine("--------------------------");
                Console.Write("Enter your choie [1-6] :");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Save(); break;
                    case 2: ViewAll(); break;
                    //case 3: Search(); break;
                    //case 4: Delete(); break;
                    //case 5: Edit(); break;
                    case 6: break;
                    default:
                        Console.WriteLine("Wrong choice...");
                        break;
                }
            }
        }

        static void Save()
        {
            Contact contact = new Contact();
            Console.Write("Enter Contact Name :");
            contact.Name = Console.ReadLine();
            Console.Write("Enter Email ID :");
            contact.Email = Console.ReadLine();
            Console.Write("Enter Mobile Number :");
            contact.Mobile = Console.ReadLine();
            Console.Write("Enter City :");
            contact.City = Console.ReadLine();

            IContactsRepository repo = new ContactsRepository();
            repo.Save(contact);
            Console.WriteLine("Contact saved...press enter to continue");
            Console.ReadLine();

        }
        static void ViewAll()
        {
            IContactsRepository repo = new ContactsRepository();
            List<Contact> contacts = repo.GetAll();
            Console.WriteLine("Name\tEmail\tMobile\tCity");
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.Name}\t{c.Email}\t{c.Mobile}\t{c.City}");
            }
        }
    }
}