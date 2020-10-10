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

namespace CopyPayPay.Contrlos
{
    /// <summary>
    /// Логика взаимодействия для ExpanderControl.xaml
    /// </summary>
    public partial class ExpanderControl : Window
    {
        public ExpanderControl()
        {
            InitializeComponent();
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void border_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
