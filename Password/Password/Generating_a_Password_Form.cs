using System;
using System.Windows.Forms;

namespace Password
{
    public partial class Generating_a_Password_Form : Form
    {
        public Generating_a_Password_Form()
        {
            InitializeComponent();
            CenterToScreen();
            AutoSize = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main_Form main = this.Owner as Main_Form;

            int n = Convert.ToInt32(textBox1.Text);
            string password = "";
            string symbol = "qwertyuiopasdfghjklzxcvbnm";
            if (checkBox1.Checked)
            {
                symbol += symbol.ToUpper();//использовать заглавные
            }
            if (checkBox2.Checked)
            {
                symbol += "!@#$%^&*()";//использовать спецсимволы
            }
            if (checkBox3.Checked)
            {
                symbol += "0123456789";//использовать цифры
            }
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                password += symbol[rnd.Next(symbol.Length)];
            }
            Main_Form.s += password;

            string light = "";
            for (int i = 0; i < password.Length; i++)
            {
                light += "*";
            }

            main.textBox3.Text += light;
            this.Close();
        }
    }
}
