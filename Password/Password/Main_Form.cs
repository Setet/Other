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
            Reference_Form_1 newForm = new Reference_Form_1();
            newForm.Owner = this;
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generating_a_Password_Form newForm = new Generating_a_Password_Form();
            newForm.Owner = this;
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cracking_a_Password_Form newForm = new Cracking_a_Password_Form();
            newForm.Owner = this;
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reference_Form_1 newForm = new Reference_Form_1();
            newForm.Owner = this;
            newForm.Show();
        }
    }
}
