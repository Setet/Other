using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            AutoSize = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Reference_Form_1 newForm = new Reference_Form_1();
            newForm.Owner = this;
            newForm.Show();
            textBox1.Text = "привет это тестовая строка";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked || radioButton2.Checked) == false)
            {
                MessageBox.Show("Вы не выбрали формат пароля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (radioButton1.Checked)
                {
                    // Cчитываем из файла сообщения
                    string m = textBox1.Text;

                    int nomer; // Номер в алфавите
                    int d; // Смещение
                    int q; //Сдвиг
                    string s; //Результат
                    int j; // Переменная для циклов

                    q = Convert.ToInt32(textBox3.Text);

                    char[] massage = m.ToCharArray(); // Превращаем строку в массив символов.

                    char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о',
                               'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

                    // Перебираем каждый символ сообщения
                    for (int i = 0; i < massage.Length; i++)
                    {
                        // Ищем индекс буквы
                        for (j = 0; j < alfavit.Length; j++)
                        {
                            if (massage[i] == alfavit[j])
                            {
                                break;
                            }
                        }

                        if (j != 33) // Если j равно 33, значит символ не из алфавита
                        {
                            nomer = j; // Индекс буквы
                            d = nomer + q; // Делаем смещение

                            // Проверяем, чтобы не вышли за пределы алфавита
                            if (d > 32)
                            {
                                d = d - 33;
                            }

                            massage[i] = alfavit[d]; // Меняем букву
                        }
                    }

                    s = new string(massage); // Собираем символы обратно в строку.
                    textBox2.Text = s;
                }
                if (radioButton2.Checked)
                {
                    string m = textBox1.Text;

                    int nomer; 
                    int d; 
                    int q; 
                    string s; 
                    int j; 

                    q = Convert.ToInt32(textBox3.Text);

                    char[] massage = m.ToCharArray(); 

                    char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о',
                               'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

                    
                    for (int i = 0; i < massage.Length; i++)
                    {
                        
                        for (j = 0; j < alfavit.Length; j++)
                        {
                            if (massage[i] == alfavit[j])
                            {
                                break;
                            }
                        }

                        if (j != 33) 
                        {
                            nomer = j; 
                            d = nomer - q; 

                           
                            if (d < 0)
                            {
                                d = d + 33;
                            }

                            massage[i] = alfavit[d]; 
                        }
                    }

                    s = new string(massage); // Собираем символы обратно в строку.
                    textBox2.Text = s;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reference_Form_2 newForm = new Reference_Form_2();
            newForm.Owner = this;
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reference_Form_1 newForm = new Reference_Form_1();
            newForm.Owner = this;
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text;
            textBox2.Text = "";
        }
    }
}
