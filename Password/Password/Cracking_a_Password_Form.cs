using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using ZedGraph;

namespace Password
{
    public partial class Cracking_a_Password_Form : Form
    {
        GraphPane paneMain;

        PointPairList Hack_list = new PointPairList();

        public Cracking_a_Password_Form()
        {
            InitializeComponent();
            CenterToScreen();
            AutoSize = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            paneMain = zMain.GraphPane;
            paneMain.XAxis.Title.Text = "Длина пароля";
            paneMain.YAxis.Title.Text = "Время в секундах+миллисекундах";
            paneMain.Title.Text = "Рассчет эффективности";
        }
        int cout = 1;
        const int n = 72;
        string[] A = new string[n] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p",
                                     "a", "s", "d", "f", "g", "h", "j", "k", "l",
                                     "z", "x", "c", "v", "b", "n", "m",
                                     "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P",
                                     "A", "S", "D", "F", "G", "H", "J", "K", "L",
                                     "Z", "X", "C", "V", "B", "N", "M",
                                     "!", "@", "#", "$", "%", "^", "&", "*", "(", ")",
                                     "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public static String[] insertionSort(String[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = 0;
                for (; j < i; j++)
                {
                    if (arr[j].Length > arr[j + 1].Length)
                    {
                        String temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        void Hack_1(string password)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string path = @"1.txt";
            int k = 0;

            // Open the file to read from.
            string[] readText = File.ReadAllLines(path);

            insertionSort(readText);

            foreach (string s in readText)
            {
                if (s.Length == password.Length)
                {
                    if (password == s)
                    {
                        k++;
                    }
                }

            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            if (k == 0)
            {
                DialogResult result = MessageBox.Show("Пароль не вскрыт.Добавить его в словарь?", "Сообщение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.AppendAllText(path, password + "\n");
                }
            }
            else
            {
                MessageBox.Show("Пароль вскрыт за : " + ts.Hours + " часов " + ts.Minutes +
                    " минут " + ts.Seconds + " секунды " + ts.Milliseconds + " микро.секунд" + ".", "Сообщение");
                string elapsedTime = Convert.ToString(ts.TotalSeconds);
                double time = Convert.ToDouble(elapsedTime);
                Hack_list.Add(password.Length, time);
                string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);//Формат времени секндомера
                richTextBox1.Text += "Дейстивие " + cout + " : " + button1.Text + ".Время : " + elapsedTime2 + "\n";
                cout++;
            }
        }

        void Hack_3(string password)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int q = password.Length;
            int[] Razm = new int[q];

            string aboba = "";

            int p = 0;
            for (int i = 0; i < q; i++)
            {
                Razm[i] = 0;
            }

            while (nextCombObject(Razm, q, n))
            {
                foreach (int item in Razm)
                {
                    aboba += A[item];
                    if (password == aboba)
                    {
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;
                        MessageBox.Show("Пароль вскрыт за : " + ts.Hours + " часов " + ts.Minutes +
                    " минут " + ts.Seconds + " секунды " + ts.Milliseconds + " микро.секунд" + ".", "Сообщение");
                        string elapsedTime = Convert.ToString(ts.TotalSeconds);
                        double time = Convert.ToDouble(elapsedTime);
                        Hack_list.Add(password.Length, time);
                        string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);//Формат времени секндомера
                        richTextBox1.Text += "Дейстивие " + cout + " : " + button1.Text + ".Время : " + elapsedTime2 + "\n";
                        cout++;
                        p++;
                        break;
                    }
                }
                if (p > 0)
                {
                    break;
                }
                aboba = "";
            }
        }

        bool nextCombObject(int[] Razm, int k, int n)
        {
            int j = k - 1;
            while (j >= 0 && Razm[j] == n - 1) j--;
            if (j == -1) return false;
            Razm[j]++;
            for (int i = j + 1; i < k; i++)
                Razm[i] = 0;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;

            Hack_1(password);
        }

        private void button2_Click(object sender, EventArgs e)//маска
        {
            string password = textBox1.Text;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Hack_2(password);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
        }

        private void button3_Click(object sender, EventArgs e)//перебор
        {
            string password = textBox1.Text; ;

            Hack_3(password);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            zMain.GraphPane.CurveList.Clear();

            LineItem Hack_Curve = paneMain.AddCurve("Hack", Hack_list, Color.Black, SymbolType.None);


            zMain.AxisChange();
            zMain.Invalidate();
        }
    }
}
