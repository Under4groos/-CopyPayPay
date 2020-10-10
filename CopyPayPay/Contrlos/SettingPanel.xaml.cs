using CopyPayPay.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
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
    /// Логика взаимодействия для SettingPanel.xaml
    /// </summary>
    public partial class SettingPanel : UserControl
    {
        public SettingPanel()
        {
            InitializeComponent();
           
        }
        private void BorderSettingPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            Data.Wind.PC.ActiveWindSetting = false;
            Data.Wind.SettingPanelW.BorderSettingPanel.Visibility = Visibility.Hidden;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
                Data.Wind.Background = new SolidColorBrush(
                    Data.Wind.setting.BackgroundColor_wind =
                Color.FromArgb(
                   Convert.ToByte(Data.Wind.SettingPanelW.SliderSettingPanel.Value),
                   Convert.ToByte(ColorR.Value),
                   Convert.ToByte(ColorG.Value),
                   Convert.ToByte(ColorB.Value)
                   )
                );

        }
        public void SetValue( Color c)
        {
            ColorR.Value = c.R;
            ColorG.Value = c.G;
            ColorB.Value = c.B;
            SliderSettingPanel.Value = c.A;
        }
    }
}
