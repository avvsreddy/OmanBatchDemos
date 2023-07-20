using AddressBook.DataLayer.Entities;

namespace AddressBook.DataLayer
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly string file = "contacts.txt";
        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public void Edit(Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            List<Contact> list = new List<Contact>();
            StreamReader sr = new StreamReader(file);

            while (!sr.EndOfStream)
            {
                Contact contact = new Contact();
                string line = sr.ReadLine();
                string[] data = line.Split(',');
                contact.Name = data[0];
                contact.Email = data[1];
                contact.Mobile = data[2];
                contact.City = data[3];
                list.Add(contact);
            }
            sr.Close();
            return list;
        }

        public void Save(Contact contactToSave)
        {
            StreamWriter sw = new StreamWriter(file, true);
            string contactCSV = $"{contactToSave.Name},{contactToSave.Email},{contactToSave.Mobile},{contactToSave.City}";
            sw.WriteLine(contactCSV);
            sw.Close();
        }

        public List<Contact> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
