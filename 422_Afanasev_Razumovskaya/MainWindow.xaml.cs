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

namespace _422_Afanasev_Razumovskaya
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
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtX.Text, out double x) || !double.TryParse(txtY.Text, out double y))
            {
                MessageBox.Show("Введите корректные числа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double fx = 0;
            if (rbSinh.IsChecked == true)
                fx = Math.Sinh(x);
            else if (rbSquare.IsChecked == true)
                fx = Math.Pow(x, 2);
            else if (rbExp.IsChecked == true)
                fx = Math.Exp(x);

            double result = 0; 
            if (x - y == 0)
                result = Math.Pow(fx, 2) + Math.Pow(y, 2) + Math.Sin(y);
            else if (x - y > 0)
                result = Math.Pow(fx - y, 2) + Math.Cos(y);
            else
                result = Math.Pow(y - fx, 2) + Math.Tan(y);

            txtResult.Text = result.ToString("F4");
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtResult.Clear();
            rbSinh.IsChecked = false;
            rbSquare.IsChecked = false;
            rbExp.IsChecked = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
