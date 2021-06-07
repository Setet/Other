using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog openFileDialog1 = new OpenFileDialog();//создаём объект класса для работы с открытием файла

        SaveFileDialog saveFileDialog1 = new SaveFileDialog();//создаём объект класса для работы с сохранением файла файла

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            openFileDialog1.FileName = @"Тест.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";

            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            // Чтение текстового файла
            try
            {
                var Читатель = new System.IO.StreamReader(
                openFileDialog1.FileName, Encoding.GetEncoding(1251));
                richTextBox1.Text = Читатель.ReadToEnd();
                Читатель.Close();
            }
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация.Message + "\nНет такого файла",
                         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Ситуация)
            { // отчет о других ошибках
                MessageBox.Show(Ситуация.Message,
                     "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                fileStream = saveFileDialog1.OpenFile();

                fileStream.Close();
                MessageBox.Show("Файл создан!!!");
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var Писатель = new System.IO.StreamWriter(
                    saveFileDialog1.FileName, false,
                                        System.Text.Encoding.GetEncoding(1251));
                    Писатель.Write(richTextBox1.Text);
                    Писатель.Close();
                }
                catch (Exception Ситуация)
                { // отчет о других ошибках
                    MessageBox.Show(Ситуация.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = 0;

            if (comboBox2.SelectedIndex == 0)
            {
                ind = 10;
            }

            if (comboBox2.SelectedIndex == 1)
            {
                ind = 15;
            }

            if (comboBox2.SelectedIndex == 2)
            {
                ind = 20;
            }

            if (comboBox2.SelectedIndex == 3)
            {
                ind = 25;
            }

            if (comboBox2.SelectedIndex == 4)
            {
                ind = 30;
            }

            if (comboBox2.SelectedIndex == 5)
            {
                ind = 35;
            }

            /////////////////////////////////////////////////////////

            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Font = new Font("Helvetica", ind);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Font = new Font("Times New Roman",ind);
            }

            if (comboBox1.SelectedIndex == 2)
            {
                richTextBox1.Font = new Font("Avenir", ind);
            }

            if (comboBox1.SelectedIndex == 3)
            {
                richTextBox1.Font = new Font("Calibri", ind);
            }

            if (comboBox1.SelectedIndex == 4)
            {
                richTextBox1.Font = new Font("Candara", ind);
            }

            if (comboBox1.SelectedIndex == 5)
            {
                richTextBox1.Font = new Font("Forte", ind);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = 0;

            if (comboBox2.SelectedIndex == 0)
            {
                ind = 10;
            }

            if (comboBox2.SelectedIndex == 1)
            {
                ind = 15;
            }

            if (comboBox2.SelectedIndex == 2)
            {
                ind = 20;
            }

            if (comboBox2.SelectedIndex == 3)
            {
                ind = 25;
            }

            if (comboBox2.SelectedIndex == 4)
            {
                ind = 30;
            }

            if (comboBox2.SelectedIndex == 5)
            {
                ind = 35;
            }

            /////////////////////////////////////////////////////////

            if (comboBox1.SelectedIndex == 0)
            {
                richTextBox1.Font = new Font("Helvetica", ind);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                richTextBox1.Font = new Font("Times New Roman", ind);
            }

            if (comboBox1.SelectedIndex == 2)
            {
                richTextBox1.Font = new Font("Avenir", ind);
            }

            if (comboBox1.SelectedIndex == 3)
            {
                richTextBox1.Font = new Font("Calibri", ind);
            }

            if (comboBox1.SelectedIndex == 4)
            {
                richTextBox1.Font = new Font("Candara", ind);
            }

            if (comboBox1.SelectedIndex == 5)
            {
                richTextBox1.Font = new Font("Forte", ind);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                richTextBox1.ForeColor = Color.Red;
            }

            if (comboBox3.SelectedIndex == 1)
            {
                richTextBox1.ForeColor = Color.Blue;
            }

            if (comboBox3.SelectedIndex == 2)
            {
                richTextBox1.ForeColor = Color.Green;
            }

            if (comboBox3.SelectedIndex == 3)
            {
                richTextBox1.ForeColor = Color.Black;
            }

            if (comboBox3.SelectedIndex == 4)
            {
                richTextBox1.ForeColor = Color.Purple;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Italic);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style ^ FontStyle.Underline);
        }
    }
}