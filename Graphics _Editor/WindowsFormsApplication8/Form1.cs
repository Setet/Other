using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Bitmap pic1;
        string mode;
        int x1, y1;
        int xclick1, yclick1;
        public Form1()
        {
            mode = "Линия";
            InitializeComponent();
            pic = new Bitmap(1000,1000);
            pic1 = new Bitmap(1000, 1000);
            SolidBrush b = new SolidBrush(Color.White);
            Graphics.FromImage(pic).FillRectangle(b,0,0,pic.Width,pic.Height);
            Graphics.FromImage(pic1).FillRectangle(b, 0, 0, pic1.Width, pic1.Height);
            x1 = y1 = 0;
            pictureBox1.Image = pic;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            button4.BackColor = b.BackColor;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName!="")
            pic.Save(saveFileDialog1.FileName);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mode = "Линия";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mode = "Прямоугольник";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mode = "Овал";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            Pen p;
            p = new Pen(button4.BackColor, trackBar1.Value);
            Graphics g;
            g = Graphics.FromImage(pic);
            if (mode == "Прямоугольник")
            {
                
                g.DrawRectangle(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
            }
            if (mode == "Овал")
            {

                g.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xclick1=e.X;
            yclick1=e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button4.BackColor,trackBar1.Value);

            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap= System.Drawing.Drawing2D.LineCap.Round;
            Graphics g;
            g = Graphics.FromImage(pic);

            Graphics g1;
            g1 = Graphics.FromImage(pic1);
            if (e.Button == MouseButtons.Left)
            {
                if (mode == "Линия")
                {
                    g.DrawLine(p, x1, y1, e.X, e.Y);
                }
                if (mode == "Прямоугольник")
                {
                    g1.Clear(Color.White);
                    int x, y;
                    x = xclick1;
                    y = yclick1;
                    if (x > e.X) x = e.X;
                    if (y > e.Y) y= e.Y;
                    g1.DrawRectangle(p,x,y,Math.Abs(e.X- xclick1), Math.Abs(e.Y- yclick1));            
                }
                if (mode == "Овал")
                {
                    g1.Clear(Color.White);
                    g1.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
                }
                g1.DrawImage(pic,0,0);


                    pictureBox1.Image = pic1;


            }
            
            x1 =e.X;
            y1=e.Y;
        }
    }
}
