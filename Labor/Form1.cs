using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        float arg01, arg02, arg03, arg04, arg5;
        double RES;
        string Out = "";

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = string.Format("Координаты: {0}, {1}", e.X, e.Y);
            textBox1.Text = (e.X + e.Y).ToString();

            arg01 = e.X;
            arg02 = e.Y;
            textBox2.Text = arg01.ToString();
            textBox3.Text = arg02.ToString();

            textBox6.Text = CalculateAnswer();
        }

        private string CalculateAnswer()
        {
            try
            {
                arg03 = Convert.ToSingle(textBox4.Text);
                arg04 = Convert.ToSingle(textBox5.Text);
                arg5 = Convert.ToSingle(textBox7.Text);
                RES = (arg01 - arg02 + Math.Abs(Math.Sin(arg03) + Math.Sqrt(Math.Abs(arg04)))) / (Math.Pow(arg01, arg5) - Math.Log10(arg02));
                return RES.ToString();
            }
            catch { return "ERROR"; }
        }
    }
}
