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

namespace WPFVkontakte.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)  
        {
            // Показать или скрыть второй StackPanel в зависимости от выбора RadioButton
            if (SportButton.Visibility== Visibility.Visible&&GameButton.Visibility== Visibility.Visible&&PolyticButton.Visibility== Visibility.Visible)
            {
                GameButton.Visibility = Visibility.Hidden;
                PolyticButton.Visibility = Visibility.Hidden;
                SportButton.Visibility = Visibility.Hidden;
            }
            else
            {
                GameButton.Visibility = Visibility.Visible;
                PolyticButton.Visibility = Visibility.Visible;
                SportButton.Visibility = Visibility.Visible;
            }
            
        }
    }
}
