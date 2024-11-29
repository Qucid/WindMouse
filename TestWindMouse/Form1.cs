using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using WindMouse;

namespace TestWindMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartLocationSearchTask();
        }
        CancellationTokenSource cTSLocationTask = new CancellationTokenSource();
        Task LocationSearchTask { get; set; }
        private void StartLocationSearchTask()
        {
            LocationSearchTask = new Task(() =>
            {
                while (true)
                {
                    Point MouseLocation = MouseAPI.GetMouseLocation();
                    int X = MouseLocation.X;
                    int Y = MouseLocation.Y;

                    if (X.ToString().CompareTo(textBox_X_Cur.Text) != 0 || Y.ToString().CompareTo(textBox_Y_Cur.Text) != 0)
                    {
                        this.Invoke(() =>
                        {
                            textBox_X_Cur.Text = X.ToString();
                            textBox_Y_Cur.Text = Y.ToString();
                        });
                    }
                    Thread.Sleep(100);
                }
            }, cTSLocationTask.Token);
            LocationSearchTask.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cTSLocationTask?.Cancel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int X,Y = 0;
            bool isXParsed = int.TryParse(textBox_X_New.Text, out X);
            bool isYParsed = int.TryParse(textBox_Y_New.Text, out Y);
            if (isXParsed == false || isYParsed == false)
            {
                MessageBox.Show("Not parsed new coords!");
                return;
            }

            MouseAPI.MoveMouseWindAsync(new(X, Y));
            

        }
    }
}
