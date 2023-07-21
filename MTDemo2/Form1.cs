namespace MTDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new Thread(() =>
            {
                // red
                Graphics red = panel1.CreateGraphics();
                Random rnd = new Random();
                int Left, Top;
                for (int i = 1; i <= 500; i++)
                {
                    Left = rnd.Next(panel1.Height);
                    Top = rnd.Next(panel1.Width);

                    red.DrawRectangle(Pens.Red, Left, Top, 20, 20);
                    Thread.Sleep(100);
                }
            }).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                // blue
                Graphics blue = panel2.CreateGraphics();
                Random rnd = new Random();
                int Left, Top;
                for (int i = 1; i <= 500; i++)
                {
                    Left = rnd.Next(panel2.Height);
                    Top = rnd.Next(panel2.Width);

                    blue.DrawRectangle(Pens.Blue, Left, Top, 20, 20);
                    Thread.Sleep(100);
                }
            }).Start();
        }
    }
}