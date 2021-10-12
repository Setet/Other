using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password
{
    public partial class Selection_by_Mask_Form : Form
    {
        public Selection_by_Mask_Form()
        {
            InitializeComponent();
            CenterToScreen();
            AutoSize = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Min_n = (int)numericUpDown1.Value;
            int Max_n = (int)numericUpDown2.Value;

            MessageBox.Show("Кнопка ещё не работает!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Selection_by_Mask_Form main = this.Owner as Selection_by_Mask_Form;
            this.Close();
        }
    }
}
