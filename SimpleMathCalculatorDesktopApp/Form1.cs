namespace SimpleMathCalculatorDesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fno, sno, sum;
            fno = int.Parse(textBox1.Text);
            sno = int.Parse(textBox2.Text);

            sum = SimpleMathCalculator.Calculator.FindSum(fno, sno);

            MessageBox.Show($"The sum of {fno} and {sno} is {sum}");
        }
    }
}