using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string answer = "";
            try
            {
                double X = Convert.ToDouble(XTextBox.Text);
                double Y = Convert.ToDouble(YTextBox.Text);
                double N = Convert.ToDouble(NComboBox.Text);
                double K = Convert.ToDouble(KComboBox.Text);
                double ans = 0;
                for (int i = 1; i <= N; i++)
                    for (int j = 1; j <= K; j++)
                    {
                        ans += (Math.Cos(Math.Pow(Y, i)) + j * X) / (i * j);
                    }
                answer = ans.ToString();
            }
            catch { answer = "ERROR"; }

            AnsTextBox.Text = answer;
        }
    }
}
