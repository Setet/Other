using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace Password
{
    public partial class Cracking_a_Password_Form : Form
    {
        public Cracking_a_Password_Form()
        {
            InitializeComponent();
        }
        const int n = 72;
        string[] A = new string[n] { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p",
                                     "a", "s", "d", "f", "g", "h", "j", "k", "l",
                                     "z", "x", "c", "v", "b", "n", "m",
                                     "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P",
                                     "A", "S", "D", "F", "G", "H", "J", "K", "L",
                                     "Z", "X", "C", "V", "B", "N", "M",
                                     "!", "@", "#", "$", "%", "^", "&", "*", "(", ")",
                                     "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        void Hack_1(string password)
        {
            string path = @"C:\Users\user\Desktop\1.txt";
            int k = 0;

            // Open the file to read from.
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                if (password == s)
                {
                    k++;
                }
            }
            if(k==0)
            {
                MessageBox.Show("Пароль не вскрыт");
            }
            else
            {
                MessageBox.Show("Пароль вскрыт");
            }
        }

        void Hack_3(string password)
        {
            int q = password.Length;
            int[] Razm = new int[q];

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            recfan2(Razm, A, n, q, password);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            richTextBox1.Text = elapsedTime;
        }

        void recfan2(int[] Razm, string[] A, int n, int k, string password)
        {
             string aboba = "";

            int q = 0;
            for (int i = 0; i < k; i++)
                Razm[i] = 0;

            while (nextCombObject(Razm, k, n))
            {
                foreach (int item in Razm)
                {
                    aboba += A[item];
                    if (password == aboba)
                    {
                        MessageBox.Show("Пароль вскрыт");
                        q++;
                        break;
                    }
                }
                if (q>0)
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

        private void button1_Click(object sender, EventArgs e)//словарь
        {
            string password = textBox1.Text;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Hack_1(password);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            richTextBox1.Text = elapsedTime;
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
            richTextBox1.Text = elapsedTime;
        }

        private void button3_Click(object sender, EventArgs e)//перебор
        {
            string password = textBox1.Text;;

            Hack_3(password);
        }
    }
}
