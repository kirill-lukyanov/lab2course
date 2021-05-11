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

namespace lab19
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
        int N = 10;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                N = Convert.ToInt32(ObjectsCount.Text);
            }
            catch { Title = "Только целое число!"; }
            GenerateObjects();
        }

        public void GenerateObjects()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < N; i++)
            {
                Shape currentShape;
                currentShape = new Ellipse();
                
                int shapeStyle = rnd.Next(0, 4) + 1;
                string styleName = "style" + shapeStyle.ToString();
                Style currentStyle = (Style)this.FindResource(styleName);
                currentShape.Style = currentStyle;
                currentShape.Width = currentShape.Height = rnd.Next(10, 200);
                MainCanvas.Children.Add(currentShape);
                Canvas.SetLeft(currentShape, rnd.Next(5, 750));
                Canvas.SetTop(currentShape, rnd.Next(5, 370));
            }
        }
    }
}
