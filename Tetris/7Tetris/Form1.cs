using System;
using System.Drawing;
using System.Windows.Forms;

namespace _7Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //byte DX = 10, DY = 20;
        Brush[] COLR = { Brushes.Aqua, Brushes.Orange, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Azure, Brushes.Violet, Brushes.Tomato, Brushes.SteelBlue, Brushes.PapayaWhip };
        Bitmap[] Cirpich;
        Graphics c; 
        Bitmap POLE = new Bitmap(212, 422);
        Figura fig; Figura[] mfig = new Figura[7];
        byte[,] Area = new byte[10, 21];
        Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            c = Graphics.FromImage(POLE);
            c.FillRectangle(new SolidBrush(Color.FromArgb(0, 45, 45)), 0, 0, 210+ 4, 420 + 4);
            for (int x = 0; x < 11; x++) { c.DrawLine(new Pen(Color.FromArgb(0, 70, 70)), x * 21 + 1, 1, x * 21, 420 + 3); }
            for (int x = 0; x < 21; x++) { c.DrawLine(new Pen(Color.FromArgb(0, 70, 70)), 1, x * 21 + 1, 210 + 3, x * 21); }
            Cirpich = new Bitmap[COLR.Length];
            for (int i = 0; i < COLR.Length; i++)
            {
                Cirpich[i] = new Bitmap(21, 21);
                c = Graphics.FromImage(Cirpich[i]);
                c.FillRectangle(COLR[i], 0, 0, 21, 21);
                c.DrawLine(new Pen(Color.FromArgb(70, Color.Black), 2), new Point(1, 20), new Point(20, 20));
                c.DrawLine(new Pen(Color.FromArgb(70, Color.Black), 2), new Point(20, 20), new Point(20, 1));
            }
            string[] figuri = { "3840", "3712", "1632", "17952", "3648", "3616", "9792" };
            for (int i = 0; i < figuri.Length; i++)
                mfig[i] = new Figura(figuri[i]);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(POLE, 0, 0);
            if (fig != null)
            {
                for (int x = 0; x < 4; x++)
                    for (int y = 0; y < 4; y++)
                    {
                        if (fig.pic[x, y])
                            e.Graphics.DrawImage(Cirpich[fig.Col], (fig.x + x) * 21 + 1, (fig.y + y) * 21 + 1);
                    }
            }
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 20; y++)
                {
                    if (Area[x, y] > 0)
                    {
                         e.Graphics.DrawImage(Cirpich[Area[x, y]], x * 21 + 1, y * 21 + 1);
                    }
                }

        }
        private bool figure_ok()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (fig.y + y > -1)
                        if (fig.pic[x, y])
                            if (x + fig.x < 0 | x + fig.x == 10) return false;
                            else if (Area[x + fig.x, y + fig.y] > 0 | fig.y + y == 20)
                                return false;
                }
            }
            return true;
        }
        private void Stop_figur()
        {
            byte numLine = 0;
            int[] DLine = new int[4];
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (fig.y + y > -1)
                        if (fig.pic[x, y])
                        {
                            Area[fig.x + x, fig.y + y] = fig.Col;
                            DLine[numLine] = fig.y + y;
                            bool DL = true;
                            for (int i = 0; i < 10; i++)
                            {
                                if (Area[i, DLine[numLine]] == 0) { DL = false; DLine[numLine] = 0; }
                            }
                            if (DL) numLine += 1;
                        }
                }
            }
            if (DLine[0] > 0) DelLine(DLine);
        }
        private void DelLine(int[] d)
        {
            int score = 0;
            double iL = 0;
            for (int i = 0; i < 4; i++)
            {
                int y1 = d[i];
                if (d[i] == 0)
                {
                    break;
                }
                iL += 1;
                for (int x = 0; x < 10; x++)
                {
                    for (int y = y1; y > 0; y--)
                    {
                        Area[x, y] = Area[x, y - 1];
                    }
                }
            }
            label1.Text = Convert.ToString(score + 100);
            this.Refresh();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fig == null)
            {
                fig = new Figura(); fig.pic = mfig[rnd.Next(0, 7)].pic;
                if (!figure_ok())
                {
                    Stop_figur();
                    fig = null; timer1.Enabled = false;
                    return;
                }
            }
            fig.y++;
            if (!figure_ok())
            {
                fig.y--; Stop_figur();
                fig = null;
            } this.Refresh(); 

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (fig == null) return;
            switch (e.KeyValue)
            {
                case 37:
                    fig.x -= 1; if (!figure_ok()) fig.x += 1;
                    break;
                case 32:
                    if (timer1.Enabled) timer1.Enabled = false;
                    else timer1.Enabled = true;
                    break;
                case 39:
                    fig.x += 1; if (!figure_ok()) fig.x -= 1;
                    break;
                case 38:
                     fig.rotate(); if (!figure_ok()) fig.urotate(); 
                    break;
                case 40:
                    fig.y += 1;
                    if (!figure_ok())
                        fig.y -= 1;
                    break;
            }
            this.Refresh();
        }

    }
}
public class Figura
{
    public sbyte x, y;
    public byte Col;
    public bool[,] pic;
    public Figura()
    {
        Random rnd = new Random();
        x = 3; y = -2;
        Col = Convert.ToByte(rnd.Next(1, 9));
    }
    public Figura(string f)
    {
        pic = new bool[4, 4];
        for (int x = 0; x < 4; x++)
            for (int y = 0; y < 4; y++)
            {
                string h9 = Convert.ToString((Convert.ToInt32(f) >> y * 4 + x) & 1, 2);
                if (h9 == "1") pic[x, y] = true;
                else pic[x, y] = false;
            }
    }
    public void rotate()
    {
        bool[,] p2 = new bool[4, 4];
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
                p2[3 - y, x] = pic[x, y];
        }
        pic = p2;
    }
    public void urotate()
    {
        bool[,] p2 = new bool[4, 4];
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                p2[x, y] = pic[3 - y, x];
            }
        }
        pic = p2;
    }
}
