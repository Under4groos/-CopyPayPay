using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class NotifyIconPanel : Window
    {
        public NotifyIconPanel()
        {
            InitializeComponent();
            
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            //this.Close();
            this.Hide();
        }
        public void SetPos()
        {
            System.Drawing.Point CurPos = User32.GetCursorPosition();
            this.Top = (CurPos.Y - this.Width) + 40;
            this.Left = CurPos.X - 10;
        }
        

        private void border_Click(object sender, RoutedEventArgs e)
        {
            Data.Wind.Show();
            this.Hide();
        }

        private void border2_Click(object sender, RoutedEventArgs e)
        {
            
            Process.GetCurrentProcess().Kill();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Data.Wind.TextList.Clear();
            Data.Wind.Listpanel.Items.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {   
            Data.Wind.Show();          
        }
    }
}
