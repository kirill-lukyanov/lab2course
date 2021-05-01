using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab17Individ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        private Point location = new Point(50, 50);
        private int R = 50;
        bool DropStarted = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
        SolidBrush solidBrush1 = new SolidBrush(Color.Red);
        SolidBrush solidBrush2 = new SolidBrush(Color.Red);
        Color FillColor1 = Color.Yellow;
        Color FillColor2 = Color.Yellow;
        float time = 0;
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            BackColor = Color.White;
            Pen pen = new Pen(Color.Blue, 1);
            float scale = 0;
            if (AnimOn)
            {
                time++;
                scale = (float)Math.Sin(time * 0.5) * 10;
            }

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (BelongsPart1(x, y))
                    {
                        gr.FillRectangle(solidBrush1, x, y, 1, 1);
                    }

                    if (BelongsPart2(x, y))
                        gr.FillRectangle(solidBrush2, x, y, 1, 1);
                }
            }
            gr.DrawEllipse(pen,-50+Width/2, -50+Height/2, 100, 100);
            gr.DrawEllipse(pen, -50+Width/2-50, -50+Height/2+50, 100, 100);
            gr.DrawEllipse(pen, -50+Width/2+50, -50+Height/2+50, 100, 100);
            gr.DrawEllipse(pen, -100+Width/2, -100+Height/2, 200, 200);

            gr.DrawLine(pen, Width / 2-100, Height / 2+100, Width / 2 +100, Height / 2 - 100);
            gr.DrawLine(pen, Width / 2, (Height / 2+ 125) + scale, Width / 2, (Height / 2 - 125) - scale);
            gr.DrawLine(pen, (Width / 2 - 125)-scale, Height / 2, (Width / 2 + 125) + scale, Height / 2);
        }

        private bool BelongsPart1(int x, int y)
        {
            return ((Math.Pow(Width / 2 - x, 2) + Math.Pow(Height / 2 - y, 2)) < Math.Pow(100, 2)) &&
                        ((Math.Pow(Width / 2 - x, 2) + Math.Pow(Height / 2 - y, 2)) > Math.Pow(50, 2)) &&
                        ((Math.Pow(Width / 2 - x - 50, 2) + Math.Pow(Height / 2 - y + 50, 2)) < Math.Pow(50, 2)) &&
                        x+ Height/2 > -y+Width/2+Height;
        }
        private bool BelongsPart2(int x, int y)
        {
            return (Math.Pow(Width / 2 - x, 2) + Math.Pow(Height / 2 - y, 2)) < Math.Pow(50, 2) &&
                (Math.Pow(Width / 2 - x+50, 2) + Math.Pow(Height / 2 - y+50, 2)) < Math.Pow(50, 2);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"X: {e.X} | Y: {e.Y}";
            if (BelongsPart1(e.X, e.Y)) solidBrush1.Color = FillColor1;
            else solidBrush1.Color = Color.Red;
            if (BelongsPart2(e.X, e.Y)) solidBrush2.Color = FillColor2;
            else solidBrush2.Color = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK) 
            {
                FillColor1 = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog2 = new ColorDialog();
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                FillColor2 = colorDialog2.Color;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int curX = e.X, curY = e.Y;
            bool InX = (curX >= location.X - R && curX <= location.X + R);
            bool InY = (curY >= location.Y - R && curY <= location.Y + R);

            if (InX && InY)
                DropStarted = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (DropStarted)
            {
                location.X = e.X + R / 2;
                location.Y = e.Y + R / 2;
                Invalidate();
            }
        }
        bool isDown;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                Control c = sender as Control;
                c.Location = this.PointToClient(Control.MousePosition);
            }

        }
        private bool AnimOn;
        private void button3_Click(object sender, EventArgs e)
        {
            AnimOn = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnimOn = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Point r = new Point()
        }
    }
}
