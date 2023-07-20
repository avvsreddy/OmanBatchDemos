namespace AddressBookWindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveForm saveForm = new SaveForm();
            saveForm.ShowDialog();
        }
    }
}