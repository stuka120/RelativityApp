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

namespace RelativityApp.Views
{
    /// <summary>
    /// Interaction logic for LorentzContraction.xaml
    /// </summary>
    public partial class LorentzContraction : UserControl
    {
        public LorentzContraction()
        {
            InitializeComponent();
            DrawMainDots();
        }
        public void DrawMainDots()
        {
            double gamma = 1 / Math.Sqrt(1 - Math.Pow(Slider.Value, 2));
            CanvasS.Children.Clear();
            for (int x = 10; x < 200; x += 20)
            {
                for (int y = 10; y < /*Convert.ToInt32(Math.Round(Height*(239d/(80d + 239d))))*/ 200; y += 20)
                {
                    double xprime = gamma * (-1 * Slider.Value * y + x);
                    double yprime = gamma * (y - Slider.Value * x);

                    CanvasS.Children.Add(new Line()
                    {

                        X1 = xprime,
                        Y1 = yprime,
                        X2 = xprime + 2,
                        Y2 = yprime + 2,
                        StrokeThickness = 2d,
                        Stroke = new SolidColorBrush(Colors.Black)
                    });
                }
                if (x == 110)
                {
                    CanvasS.Children.Add(new Line()
                    {
                        X1 = gamma * (-1 * Slider.Value * 110 + 10),
                        Y1 = gamma * (110 - Slider.Value * 10),
                        X2 = gamma * (-1 * Slider.Value * 110 + 190),
                        Y2 = gamma * (110 - Slider.Value * 190),
                        StrokeThickness = 2,
                        Stroke = new SolidColorBrush(Colors.Blue)
                    });
                }
            }

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawMainDots();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DrawMainDots();
        }
    }
}
