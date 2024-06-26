﻿using System;
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

        void RANDOM(int n)
        {
            string password = "";
            string symbol = "";
            
            if (radioButton1.Checked)
            {
                symbol = "0123456789";
            }
            if (radioButton2.Checked)
            {
                symbol = "qwertyuiopasdfghjklzxcvbnm"; 
            }
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

            Random rand = new Random();
            int RAND_MAX = 10;
            for (int i = 0; i < n; i++)
            {
                int j = 1 + (int)(10.0 * (rand.Next(0, symbol.Length) / (RAND_MAX + 1.0)));
                password += symbol[j];
            }
            textBox3.Text = password;
        }

        void RANDOM_Not_me(int n)
        {
            string password = "";
            string symbol = "";
            if (radioButton1.Checked)
            {
                symbol = "0123456789";
            }
            if (radioButton2.Checked)
            {
                symbol = "qwertyuiopasdfghjklzxcvbnm";
            }
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
            textBox2.Text = password;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(comboBox1.Text);

            if ((radioButton1.Checked || radioButton2.Checked)==false)
            {
                MessageBox.Show("Вы не выбрали формат пароля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                RANDOM_Not_me(n);
                RANDOM(n);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refence_Form_2 newForm = new Refence_Form_2();
            newForm.Owner = this;
            newForm.Show();
        }
    }
}
