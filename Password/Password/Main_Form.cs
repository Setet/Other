using System;
using System.Windows.Forms;

namespace Password
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
            button5.Visible = false;
        }
        public static string s = "";

        public void passGenerate(String s)
        {
            int i = 0;
            
            string alf = "qwertyuiopasdfghjklzxcvbnm!@#$%^&*()0123456789";
            alf += alf.ToUpper();
            for (i = 0; i <= Main_Form.s.Length - 1; i++)
            {
                s.Replace(s[i], alf[i]);
            }
            textBox2.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s = "";
            textBox3.Text = "";
            Generating_a_Password_Form newForm = new Generating_a_Password_Form();
            newForm.Owner = this;
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = s;
            button2.Visible = false;
            button5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            passGenerate(Main_Form.s);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button5.Visible = false;
            string abc = s;
            string light = "";
            for (int i = 0; i <abc.Length ; i++)
            {
                light += "*";
            }
            textBox3.Text = light;
        }
    }
}
