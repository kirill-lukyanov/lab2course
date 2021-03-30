using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Пример строки состояния";
            CenterToScreen();
            BackColor = Color.CadetBlue;
            currentCheckedItem = toolStripMenuItemTime;
            currentCheckedItem.Checked = true;
            currentCheckedItemPrimer = primer1ToolStripMenuItem;
            currentCheckedItemPrimer.Checked = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.Text)
            {
                case "белый": BackColor = Color.White; break;
                case "красный": BackColor = Color.Red; break;
                case "черный": BackColor = Color.Black; break;
                case "синий": BackColor = Color.Blue; break;
                case "желтый": BackColor = Color.Yellow; break;
                default: BackColor = SystemColors.Control; break;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BackColor = Color.FromArgb(
                    Convert.ToInt32(toolStripTextBox1.Text),
                    Convert.ToInt32(toolStripTextBox2.Text),
                    Convert.ToInt32(toolStripTextBox3.Text));
            }
            catch { MessageBox.Show("Необходимо ввести целое число от 0 до 255", "Ошибка в задании цвета"); }
        }

        private void toolStripTextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BackColor = Color.FromArgb(
                    Convert.ToInt32(toolStripTextBox4.Text),
                    Convert.ToInt32(toolStripTextBox5.Text),
                    Convert.ToInt32(toolStripTextBox6.Text));
            }
            catch { MessageBox.Show("Необходимо ввести целое число от 0 до 255", "Ошибка в задании цвета"); }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox2.Text)
            {
                case "белый": BackColor = Color.White; break;
                case "красный": BackColor = Color.Red; break;
                case "черный": BackColor = Color.Black; break;
                case "синий": BackColor = Color.Blue; break;
                case "желтый": BackColor = Color.Yellow; break;
                default: BackColor = SystemColors.Control; break;
            }
        }

        DateTimeFormat dtFormat = DateTimeFormat.ShowTime;
        ToolStripMenuItem currentCheckedItem;
        public enum DateTimeFormat
        {
            ShowTime,
            ShowDate,
            ShowMouse
        }

        private void timerDateTimeUpdate_Tick(object sender, EventArgs e)
        {
            string info = "";
            if (dtFormat == DateTimeFormat.ShowTime)
                info = DateTime.Now.ToLongTimeString();
            else if (dtFormat == DateTimeFormat.ShowDate)
                info = DateTime.Now.ToLongDateString();

            toolStripStatusLabelState.Text = info;
        }

        private void toolStripMenuItemDate_Click(object sender, EventArgs e)
        {
            currentCheckedItem.Checked = false;
            dtFormat = DateTimeFormat.ShowDate;
            currentCheckedItem = toolStripMenuItemDate;
            currentCheckedItem.Checked = true;
        }

        private void toolStripMenuItemTime_Click(object sender, EventArgs e)
        {
            currentCheckedItem.Checked = false;
            dtFormat = DateTimeFormat.ShowTime;
            currentCheckedItem = toolStripMenuItemTime;
            currentCheckedItem.Checked = true;
        }

        private void курсорМышиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentCheckedItem.Checked = false;
            dtFormat = DateTimeFormat.ShowMouse;
            currentCheckedItem = toolStripMenuItemMouse;
            currentCheckedItem.Checked = true;
        }
        int X = 0, Y = 0;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            X = MousePosition.X;
            Y = MousePosition.Y;
            if (dtFormat == DateTimeFormat.ShowMouse)
                toolStripStatusLabelState.Text = $"X: {X} | Y: {Y}";
            toolStripStatusLabel1.Text = Calculate2();
        }

        public string Calculate()
        {
            try
            {
                float answer = 0;
                float x = Convert.ToInt32(toolStripTextBox7.Text);
                float y = Convert.ToInt32(toolStripTextBox8.Text);
                float z = Convert.ToInt32(toolStripTextBox9.Text);
                float a = Convert.ToInt32(toolStripComboBox3.Text);
                float b = Convert.ToInt32(toolStripComboBox4.Text);

                answer = (float)(a * x * (b * y) / Math.Log10(z) + Math.Sin(z) / Math.Cos(y));
                return $"Ответ: {answer}";
            } catch { return "Значения ненормальные"; }

        }

        private void CalculatePrimer(object sender, EventArgs e)
        {
            Text = Calculate();
        }
        public enum PrimerType
        {
            Primer1,
            Primer2
        }
        PrimerType primerType = PrimerType.Primer1;
        ToolStripMenuItem currentCheckedItemPrimer;
        private void primer2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentCheckedItemPrimer.Checked = false;
            primerType = PrimerType.Primer2;
            currentCheckedItemPrimer = primer2ToolStripMenuItem;
            currentCheckedItemPrimer.Checked = true;
        }

        private void primer1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            currentCheckedItemPrimer.Checked = false;
            primerType = PrimerType.Primer1;
            currentCheckedItemPrimer = primer1ToolStripMenuItem;
            currentCheckedItemPrimer.Checked = true;
        }

        public string Calculate2()
        {
            try
            {
                float answer = 0, answer2 = 0;
                if (primerType == PrimerType.Primer1)
                {
                    answer = X / Math.Abs(Y-X*X);
                    answer2 = (float)Math.Sqrt(Math.Abs(X - Math.Sqrt(Y)));
                    return $"z = {answer} | f = {answer2}";
                }
                else
                {
                    answer = (float)(Math.Cos(X) + Math.Sin(Y));
                    return $"z = {answer}";
                }

            }
            catch { return "Значения ненормальные"; }

        }


    }
}