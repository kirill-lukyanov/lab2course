using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Application.StartupPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                ShowData(openFileDialog1.FileName);
        }

        private void ShowData(string datapath)
        {
            //try
            {
                DataStorage data = DataStorage.DataCreator(datapath);
                dgvRaw.DataSource = data.GetRawData();
                dgvRaw.ReadOnly = true;
                dgvSummary.DataSource = data.GetSummaryData();
                dgvSummary.ReadOnly = true;
            }
            //catch { MessageBox.Show("не получилось загрузить данные("); }
        }
    }
}
