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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CopyPayPay.Contrlos
{
    /// <summary>
    /// Логика взаимодействия для PanelControl.xaml
    /// </summary>
    public partial class PanelControl : System.Windows.Controls.UserControl
    {
    


        public string Title
        {
            get { return (string)GetValue(V); }
            set { SetValue(V, value); }
        }
        public static readonly DependencyProperty V =
         DependencyProperty.Register(
             "Title", typeof(string), typeof(PanelControl),
             new PropertyMetadata("", (o, args) => ((PanelControl)o).Update()));
        public double Alpha
        {
            get { return (double)GetValue(A); }
            set { SetValue(A, value); }
        }

        public static readonly DependencyProperty A =
          DependencyProperty.Register(
              "Alpha", typeof(double), typeof(PanelControl),
              new PropertyMetadata(0.0, (o, args) => ((PanelControl)o).Update()));

        public double FSize
        {
            get { return (double)GetValue(FontSize_); }
            set { SetValue(FontSize_, value); }
        }
        public static readonly DependencyProperty FontSize_ =
         DependencyProperty.Register(
             "FSize", typeof(double), typeof(PanelControl),
             new PropertyMetadata(0.0, (o, args) => ((PanelControl)o).Update()));



        public void Update()
        {
            Panel.Opacity = Alpha;
            Title_text.Content = Title;
            Title_text.FontSize = FSize;
        }


        public PanelControl()
        {
            InitializeComponent();
            FSize = 12.0;
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.RightButton == MouseButtonState.Pressed)           
                Process.GetCurrentProcess().Kill();
            
            
            
        }


        private void Canvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (Data.Wind.WindowState != WindowState.Minimized)
                Data.Wind.Hide();
            //ProgramInfo.Wind.WindowState = WindowState.Minimized;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (Data.Wind.WindowState)
            {
                //case WindowState.Normal:
                //    ProgramInfo.Wind.WindowState = WindowState.Maximized;                    
                //    break;
                case WindowState.Maximized:
                    Data.Wind.WindowState = WindowState.Normal;                
                    break;
                default:
                    break;
            }
        }

    }
}
