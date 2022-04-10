using System;
using System.Windows.Forms;

namespace Magic_Square
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            CenterToScreen();
            AutoSize = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Titul newForm = new Titul();
            newForm.Owner = this;
            newForm.Show();
            textBox1.Text = "Привет абитуриент";
        }

        static int[] ReadMatrix(string Matrix)
        {
            char[] Separators = new char[] { ' ', '\n' };
            return Array.ConvertAll(Matrix.Split(Separators), s => int.Parse(s));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] myMatryx = ReadMatrix(richTextBox1.Text);
            if (En_De_cryption.MagicSquare(myMatryx))
            {
                try
                {
                    textBox3.Text = En_De_cryption.EnDe_code(textBox1.Text, ReadMatrix(richTextBox1.Text));
                    textBox2.Text = textBox3.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Не подходит размер текста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else
            {
                MessageBox.Show("Не магический квадрат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] myMatryx = ReadMatrix(richTextBox1.Text);
            if (En_De_cryption.MagicSquare(myMatryx))
            {
                try
                {
                    textBox4.Text = En_De_cryption.EnDe_code(textBox2.Text, ReadMatrix(richTextBox1.Text));
                    textBox2.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Не подходит размер текста!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Не магический квадрат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Titul newForm = new Titul();
            newForm.Owner = this;
            newForm.Show();
        }
    }
}
