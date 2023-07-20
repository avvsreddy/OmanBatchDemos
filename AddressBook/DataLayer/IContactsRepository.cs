
using AddressBook.DataLayer.Entities;

namespace AddressBook.DataLayer
{
    public interface IContactsRepository
    {
        void Save(Contact contactToSave);
        List<Contact> GetAll();
        List<Contact> Search(string name);

        void Delete(string name);

        void Edit(Contact contact);
    }
}
