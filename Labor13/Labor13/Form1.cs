using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labor13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float X, Y, I, c, N, R;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string Z;

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) Z = CalculateFirst();
            else if (radioButton2.Checked) Z = CalculateSecond();

            textBox6.Text = Z;
        }

        private string CalculateFirst()
        {
            try
            {
                X = Convert.ToSingle(textBox1.Text);
                Y = Convert.ToSingle(textBox2.Text);
                I = Convert.ToSingle(textBox3.Text);
                double sum = 0;
                float lastMult = 1;
                for (int iter = 1; iter <= I; iter++)
                {
                    if (iter % 2 == 0) sum += Math.Pow(Y, iter) / lastMult * (iter + 1);
                    else sum -= Math.Pow(X, iter) / lastMult * (iter + 1);
                    lastMult *= iter + 1;
                }
                return Math.Round((1 - sum), 2).ToString();
            }
            catch { return "ERROR"; }
        }

        private string CalculateSecond()
        {
            try
            {
                c = Convert.ToSingle(comboBox3.Text);
                N = Convert.ToSingle(comboBox2.Text);
                R = Convert.ToSingle(comboBox1.Text);
                double sum = 0;
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= R; j++)
                    {
                        sum += (3 + j) / (c * j);
                    }
                }
                return Math.Round(sum, 2).ToString();
            }
            catch { return "ERROR"; }
        }
    }
}
