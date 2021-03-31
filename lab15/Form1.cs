using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.ShowHelp = true;
            dlg.Color = panel1.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                panel1.BackColor = dlg.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.ShowColor = true;
            dlg.ShowHelp = true;
            dlg.Font = textBox1.Font;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = dlg.Font;
                textBox1.ForeColor = dlg.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Application.StartupPath;
            dlg.Filter = "txt files (*.txt)|*.txt | " +
                "Мои файлы (расширения не придумал)|*.xxx|" +
                "Сборки (*.exe)|*.exe";
            dlg.FilterIndex = 3;
            dlg.Title = "Выбор моего файла";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Выбеите папку для демонстрации работы диалога";
            dlg.ShowNewFolderButton = true;
            dlg.SelectedPath = Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = dlg.SelectedPath;
            }
        }

        public string Calculate()
        {
            try
            {
                float h = 0;
                int n = Convert.ToInt32(textBox7.Text);
                float x = Convert.ToSingle(textBox4.Text);
                float y = Convert.ToSingle(textBox5.Text);
                for (int i = 0, j = 1; i < n; i++, j += 2)
                {
                    int negate = i % 2 == 0 ? 1 : -1;
                    h += (float)((Math.Pow(y, j + 2) + Math.Pow(x, j + 1)) / (j * j + 2)) * negate;
                }
                return h.ToString();
            }
            catch { return "Ошибка"; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.ShowHelp = true;
            dlg.Color = panel1.BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                textBox4.BackColor = textBox5.BackColor = textBox6.BackColor = textBox7.BackColor = dlg.Color;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.ShowColor = true;
            dlg.ShowHelp = true;
            dlg.Font = textBox1.Font;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox4.Font = textBox5.Font = textBox6.Font = dlg.Font;
                textBox4.ForeColor = textBox5.ForeColor = textBox6.ForeColor = textBox7.BackColor = dlg.Color;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.DefaultExt = "txt";
            dlg.FileName = "Без названия";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.InitialDirectory + dlg.FileName, $"x: {textBox4.Text}\n" +
                    $"y: {textBox5.Text}\n" +
                    $"n: {textBox7.Text}\n" +
                    $"h: {textBox6.Text}");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = Calculate();
        }
    }
}
