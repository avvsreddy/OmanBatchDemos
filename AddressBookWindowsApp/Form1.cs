using System.Data;

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
        EmployeeManagementSystem.DataLayerLibrary.EmployeeRepository repo = new EmployeeManagementSystem.DataLayerLibrary.EmployeeRepository();

        DataSet ds = null;
        private void button1_Click(object sender, EventArgs e)
        {
            // get all emp

            ds = repo.GetAllEmployeesDisconnected();

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Employees";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            repo.Update(ds);
            MessageBox.Show("Changes saved...");

            //ds.WriteXml("employees.xml");
            //ds.ReadXml("emp.xml");
        }
    }
}