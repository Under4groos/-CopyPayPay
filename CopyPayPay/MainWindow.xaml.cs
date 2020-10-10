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

namespace CopyPayPay
{
    public partial class MainWindow : Window
    {

        Task Task_;
        string lastStringClipboard = "";
        public List<string> TextList = new List<string>();
        string text = "";
        NotifyIconPanel NP = new NotifyIconPanel();
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
                default:

                    break;
            }

        }

        private void PanelControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            //PointCollection PC = new PointCollection();
            //PC.Add(new Point(0, 0));
            //PC.Add(new Point(0, this.Height-3));
            //PC.Add(new Point(this.Width-3, this.Height));
            //PC.Add(new Point(this.Width, 0));
            //Polyline_.Points = PC;
        }
    }
}
