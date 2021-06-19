using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Снеговик
{
	public partial class Form1 : Form
	{
		bool a = false;
		Timer myTimer = new System.Windows.Forms.Timer();
		public Form1()
		{
			InitializeComponent();
			myTimer.Tick += new EventHandler(TimerEventProcessor);
			myTimer.Interval = 500;
			myTimer.Start();
		}

		public void TimerEventProcessor(Object myObject,EventArgs myEventArgs)
		{
			Render();
		}

		public void Render()
		{
			Image img = new Bitmap(500, 500);
			Graphics g = Graphics.FromImage(img);
			Pen bluePen = new Pen(Color.CadetBlue, 5);
			SolidBrush redPen = new SolidBrush(Color.Yellow);
			Pen brownPen = new Pen(Color.SaddleBrown, 5);
			SolidBrush brownBrush = new SolidBrush(Color.SaddleBrown);
			SolidBrush greenBrush = new SolidBrush(Color.Green);
			SolidBrush blackBrush = new SolidBrush(Color.Black);
			SolidBrush grayBrush = new SolidBrush(Color.Gray);
			SolidBrush whiteBrush = new SolidBrush(Color.White);
			SolidBrush purpleBrush = new SolidBrush(Color.LightGreen);
			Pen purplePen = new Pen(Color.Green, 5);
			SolidBrush orangeBrush = new SolidBrush(Color.Orange);

			//Градиент
			var ellipsePath = new GraphicsPath();
			ellipsePath.AddEllipse(160, 250, 200, 180);
			var brush = new PathGradientBrush(ellipsePath);
			brush.CenterPoint = new PointF(200, 300);
			brush.CenterColor = Color.White;
			brush.SurroundColors = new[] { Color.AliceBlue };
			brush.FocusScales = new PointF(0, 0);

			//Палка
			PointF[] palki2 = new PointF[] {new PointF(300,230), new PointF(400, 180), new PointF(430, 190), new PointF(430, 180), new PointF(410, 170),
				new PointF(450, 150),new PointF(450, 145), new PointF(450, 140),
			new PointF(370, 180), new PointF(380, 160), new PointF(370, 160),
				new PointF(360, 190), new PointF(410, 160), new PointF(300,220), new PointF(300,230)};
			g.FillClosedCurve(brownBrush, palki2);
			g.DrawCurve(brownPen, palki2);

			//Шары
			g.FillEllipse(brush, 160, 250, 200, 180);
			g.DrawEllipse(bluePen, 160, 250, 200, 180);
			//
			ellipsePath = new GraphicsPath();
			ellipsePath.AddEllipse(175, 150, 150, 140);
			brush = new PathGradientBrush(ellipsePath);
			brush.CenterPoint = new PointF(200, 200);
			brush.CenterColor = Color.White;
			brush.SurroundColors = new[] { Color.AliceBlue };
			brush.FocusScales = new PointF(0, 0);
			//
			g.FillEllipse(brush, 175, 150, 150, 140);
			g.DrawEllipse(bluePen, 175, 150, 150, 140);
			//

			ellipsePath = new GraphicsPath();
			ellipsePath.AddEllipse(190, 75, 100, 95);
			brush = new PathGradientBrush(ellipsePath);
			brush.CenterPoint = new PointF(200, 100);
			brush.CenterColor = Color.White;
			brush.SurroundColors = new[] { Color.AliceBlue };
			brush.FocusScales = new PointF(0, 0);
			//
			g.FillEllipse(brush, 190, 75, 100, 95);
			g.DrawEllipse(bluePen, 190, 75, 100, 95);
			//
			//Палка
			PointF[] palki1 = new PointF[] {new PointF(200,230), new PointF(100, 180), new PointF(70, 190), new PointF(70, 180), new PointF(90, 170),
				new PointF(50, 150),new PointF(50, 145), new PointF(50, 140),
			new PointF(130, 180), new PointF(120, 160), new PointF(130, 160),
				new PointF(140, 190), new PointF(90, 160), new PointF(200,220), new PointF(200,230)};
			g.FillClosedCurve(brownBrush, palki1);
			g.DrawCurve(brownPen, palki1);

			//Пуговки
			g.FillEllipse(orangeBrush, 270, 200, 20, 20);
			g.DrawEllipse(brownPen, 270, 200, 20, 20);
			g.FillEllipse(orangeBrush, 280, 240, 20, 20);
			g.DrawEllipse(brownPen, 280, 240, 20, 20);

			//Nose
			PointF[] nose = new PointF[] { new PointF(270, 125), new PointF(360, 135), new PointF(270, 145), new PointF(270, 125) };
			g.FillClosedCurve(orangeBrush, nose);
			//g.DrawCurve(brownPen, nose);

			//Eyes
			g.FillEllipse(blackBrush, 240, 100, 20, 20);
			g.FillEllipse(whiteBrush, 247, 103, 9, 9);
			//Bucket

			PointF[] bucket = new PointF[] { new PointF(200, 90), new PointF(215, 30), new PointF(220, 25), new PointF(270, 25), new PointF(275, 30), new PointF(285, 85), new PointF(290, 90), new PointF(200, 90) };
			g.FillClosedCurve(purpleBrush, bucket);
			g.DrawCurve(purplePen, bucket);
			//BucketH

			PointF[] bucketHand = new PointF[] { new PointF(200, 90), new PointF(245, 120), new PointF(290, 90), new PointF(290, 95), new PointF(245, 125), new PointF(200, 95), new PointF(200, 90) };
			g.FillClosedCurve(grayBrush, bucketHand);
			bucketHand = new PointF[] { new PointF(230, 115), new PointF(260, 115), new PointF(260, 125), new PointF(230, 125), new PointF(230, 115) };
			g.FillClosedCurve(redPen, bucketHand);

			//Flower
			g.FillEllipse(orangeBrush, 235, 40, 20, 20);
			g.FillEllipse(orangeBrush, 245, 45, 20, 20);
			g.FillEllipse(orangeBrush, 225, 45, 20, 20);
			g.FillEllipse(orangeBrush, 235, 65, 20, 20);
			g.FillEllipse(orangeBrush, 245, 60, 20, 20);
			g.FillEllipse(orangeBrush, 225, 60, 20, 20);
			g.FillEllipse(redPen, 235, 55, 20, 20);

			//Leaf
			bucketHand = new PointF[] { new PointF(225, 65), new PointF(220, 55), new PointF(215, 50), new PointF(220, 45), new PointF(225, 65) };
			g.FillClosedCurve(greenBrush, bucketHand);
			bucketHand = new PointF[] { new PointF(225, 65), new PointF(220, 75), new PointF(215, 70), new PointF(220, 85), new PointF(225, 65) };
			g.FillClosedCurve(greenBrush, bucketHand);
			if (a)
				img.RotateFlip(RotateFlipType.Rotate180FlipY);
			a = !a;

			pictureBox1.Image = img;
		}
	}
}
