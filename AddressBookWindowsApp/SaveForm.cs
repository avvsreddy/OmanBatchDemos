using AddressBook.DataLayer;
using AddressBook.DataLayer.Entities;

namespace AddressBookWindowsApp
{
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save contact
            IContactsRepository repo = new ContactsRepository();
            Contact c = new Contact();
            c.Name = textBox1.Text;
            c.Email = textBox2.Text;
            c.Mobile = textBox3.Text;
            c.City = textBox4.Text;
            repo.Save(c);
            MessageBox.Show($"{c.Name} saved successfully");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
