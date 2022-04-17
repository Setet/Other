using System;
using System.Windows.Forms;

namespace Diffie_Hellman_algorithm
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
            button7.Visible = true;
            Reference_Form_1 newForm = new Reference_Form_1();
            newForm.Owner = this;
            newForm.Show();
        }
        //Значения Y и P для общей односторонней функции
        int Alice_Y = 0;
        int Bob_P = 0;
        //Случайные серетные числа
        int Alice_A = 0;
        int Bob_B = 0;
        //Подстановка в общую функцию
        int a=0;
        int b=0;
        //Меняемся значениями
        int Alice_b = 0;
        int Bob_a = 0;

        void Spidrun()//функция которое пробегает все этапы нечего не выводя
        {
            string massage= "Алгоритм завершил свою работу\nСеансовый ключ =";
            Random rnd = new Random();
            Alice_Y = rnd.Next(1, 20);
            Bob_P = rnd.Next(1, 20);

            textBox1.Text = Convert.ToString(Alice_Y);
            textBox2.Text = Convert.ToString(Bob_P);

            Alice_A = rnd.Next(1, 10);
            Bob_B = rnd.Next(1, 10);

            a = (int)Math.Pow(Alice_Y, Alice_A) % Bob_P;
            b = (int)Math.Pow(Alice_Y, Bob_B) % Bob_P;

            Bob_a = a;
            Alice_b = b;

            a = (int)Math.Pow(Alice_b, Alice_A) % Bob_P;
            b = (int)Math.Pow(Bob_a, Bob_B) % Bob_P;

            if (a == b)
            {
                massage = massage+Convert.ToString(a);
                MessageBox.Show(massage, "Конец", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Alice_Y = rnd.Next(1, 20);
            Bob_P = rnd.Next(1,20);
            textBox1.Text = Convert.ToString(Alice_Y);
            textBox2.Text = Convert.ToString(Bob_P);

            if (radioButton1.Checked == false)
            {
                textBox4.Visible = true;
                textBox5.Visible = true;
            }

            button2.Visible = true;
            button1.Visible = false;

            richTextBox1.Text += "\nЭтап 2:\n" +
                "Алиса выбирает случайное число,например 3,хранит его в секрете,и обозначает как A\n" +
                "Боб выбирает случайное число,например 6,хранит его в секрете,и обозначает как B\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Alice_A = rnd.Next(1, 10);
            Bob_B = rnd.Next(1, 10);

            textBox5.Text = Convert.ToString(Alice_A);
            textBox4.Text = Convert.ToString(Bob_B);

            if (radioButton1.Checked == false)
            {
                textBox6.Visible = true;
                textBox7.Visible = true;
            }

            button3.Visible = true;
            button2.Visible = false;

            richTextBox1.Text += "Этап 3:\n" +
                "Алиса подставляет число в общую функцию вместо x и вычисляет результат\n" +
                "7^3(mod 11) = 343(mod 11) = 2,обозначает результат этого вычисления как число a\n" +
                "Боб подставляет число в общую функцию вместо x и вычисляет результат\n" +
                "7^6(mod 11) = 117649(mod 11) = 4,обозначает результат этого вычисления как число b\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = (int)Math.Pow(Alice_Y, Alice_A) % Bob_P;

            b = (int)Math.Pow(Alice_Y, Bob_B) % Bob_P;

            textBox7.Text = Convert.ToString(a);
            textBox6.Text = Convert.ToString(b);

            if (radioButton1.Checked == false)
            {
                textBox8.Visible = true;
                textBox9.Visible = true;
            }

            button4.Visible = true;
            button3.Visible = false;

            richTextBox1.Text += "Этап 4:\n" +
                "Алиса передаёт число a Бобу\n" +
                "Боб передаёт число b Алисе\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bob_a = a;
            Alice_b = b;


            button5.Visible = true;
            button4.Visible = false;

            richTextBox1.Text += "Этап 5:\n" +
                "Алиса получает b от Боба,и вычисляет значение b^A(mod 11) = 4^3(mod 11)=64(mod 11)=9\n" +
                "Боб получает a от Алисы,и вычисляет значение a^B(mod 11) = 2^6(mod 11)=64(mod 11)=9\n";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            a = (int)Math.Pow(Alice_b, Alice_A) % Bob_P;

            b = (int)Math.Pow(Bob_a, Bob_B) % Bob_P;

            if (radioButton1.Checked == false)
            {
                textBox9.Text = Convert.ToString(a);
                textBox8.Text = Convert.ToString(b);
            }

            textBox3.Visible = true;
            button6.Visible = true;
            button5.Visible = false;

            richTextBox1.Text += "Этап 6:\n" +
            "Оба участника в итоге получили число 9.\nЭто и будет являться секретным(сеансовым ключом)";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (a == b)
            {
                textBox3.Text = Convert.ToString(a);
            }
            button6.Visible = false;
            button7.Visible = true;
            MessageBox.Show("Алгоритм завершил свою работу", "Конец", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked || radioButton2.Checked) == false)
            {
                MessageBox.Show("Вы не выбрали режим работы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((radioButton3.Checked || radioButton4.Checked) == false)
            {
                MessageBox.Show("Вы не выбрали режим демонстрации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (radioButton4.Checked == true)
            {
                groupBox3.Visible = true;

                label1.Visible = true;
                label2.Visible = true;

                button1.Visible = true;

                textBox1.Visible = true;
                textBox2.Visible = true;

                button7.Visible = false;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;


                textBox1.Visible = true;
                textBox2.Visible = true;

                Spidrun();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reference_Form_1 newForm = new Reference_Form_1();
            newForm.Owner = this;
            newForm.Show();
        }
    }
}
