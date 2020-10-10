using CopyPayPay.Contrlos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CopyPayPay
{
    public partial class MainWindow : Window
    {

        Task Task_;
        string lastStringClipboard = "";
        public List<string> TextList = new List<string>();
        string text = "";
        NotifyIconPanel NP = new NotifyIconPanel();

        
        public Setting setting = new Setting();
        // System.Xml.Serialization.XmlSerializer formatter = new System.Xml.Serialization.XmlSerializer(typeof(Setting));

        public MainWindow()
        {
            InitializeComponent();
            Hide();
            Data.Wind = this;
            DispatcherTimer PhysicsTimer = new DispatcherTimer();
            PhysicsTimer.Tick += PhysicsTimerTick;
            PhysicsTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            Task_ = new Task(PhysicsTimer.Start);
            Task_.Start();

            NotifyIcon ni = new NotifyIcon();
            ni.Icon = CopyPayPay.Res.CPyPyIcon;
            ni.Visible = true;
            ni.MouseDown += Ni_MouseDown;
            #region ddd
            // Data.FolderSave + @"\setting.json"
            //if (File.Exists(Data.FolderSave + @"\setting.xml"))
            //{ 
            //    var mySerializer = new XmlSerializer(typeof(Setting));
            //    // To read the file, create a FileStream.
            //    var myFileStream = new FileStream(Data.FolderSave + "\\setting.xml", FileMode.Open);
            //    // Call the Deserialize method and cast to the object type.
            //    setting = (Setting)mySerializer.Deserialize(myFileStream);
            //}
            //if (File.Exists(Data.FolderSave + @"\setting.json") == true)
            //{
            //    DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Setting));
            //    using (FileStream fs = new FileStream(, FileMode.OpenOrCreate))
            //    {

            //        setting = (Setting)formatter.ReadObject(fs);
            //    }
            //    Data.Wind.SettingPanelW.SetValue(setting.BackgroundColor_wind);

            //}
            //else
            //{

            //    Data.Wind.SettingPanelW.SetValue(setting.BackgroundColor_wind = Data.Wind.BackgroundPR.Color);

            //    Directory.CreateDirectory(Data.FolderSave);
            //    using (FileStream fs = new FileStream(Data.FolderSave + @"\setting.json", FileMode.OpenOrCreate))
            //    {
            //        DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Setting));
            //        formatter.WriteObject(fs, setting);
            //    }
            //}



            //if (File.Exists(Data.FolderSave + @"\setting.dat") && File.ReadAllText(Data.FolderSave + @"\setting.dat").Length > 10)
            //{//}
            #endregion
            Data.Wind.SettingPanelW.SetValue(Color.FromArgb(100, 255, 255, 255));
        }
        private void PhysicsTimerTick(object sender, EventArgs e)
        {
            if (!System.Windows.Clipboard.ContainsText())
                return;
            try
            {

                text = System.Windows.Clipboard.GetText();
            }
            catch (Exception) { }
            if (lastStringClipboard != text)
            {
                
                #region Remove
                //PC.Title = "CopyPayPay" + TextList.siz;
                //Label NewB = new Label();
                //NewB.Content = string.Format("{0} \n {1}", Time_, text.Length > ProgramInfo.MaxLenText ? text.Substring(0, ProgramInfo.MaxLenText) : text);
                //NewB.VerticalAlignment = VerticalAlignment.Top;
                //NewB.Foreground = new SolidColorBrush(ProgramInfo.ForegroundColor);
                //NewB.Background = new SolidColorBrush(ProgramInfo.BackgroundColor);
                //NewB.FontSize = ProgramInfo.SizeText;
                //NewB.FontFamily = new FontFamily("Tahoma");
                //NewB.MouseDown += NewB_MouseDown;               
                //Listpanel.Items.Add(NewB);
                //TextList.Add(text);
                //TimeList.Add(Time_);
                //lastStringClipboard = text;
                #endregion
                NewTextBox nb = new NewTextBox();
                nb.Text = text;
                nb.Width = Listpanel.Width;
                nb.IDpanel = Listpanel.Items.Count;
                Listpanel.Items.Add(nb);
                TextList.Add(text);
                lastStringClipboard = text;
            }
        }

        private void Ni_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    this.Show();
                    this.WindowState = WindowState.Normal;
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    if (NP == null)
                    {
                        NP = new NotifyIconPanel();
                    }
                    else
                    {
                        NP.SetPos();
                        NP.Show();
                    }

                    break;
            }
        }

        private void PanelControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }


        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            Data.Wind.SettingPanelW.BorderSettingPanel.Visibility = Visibility.Hidden;
            Data.Wind.SettingPanelW.SliderSettingPanel.Value = Data.Wind.BackgroundPR.Opacity * 100;
        }
    }
}
