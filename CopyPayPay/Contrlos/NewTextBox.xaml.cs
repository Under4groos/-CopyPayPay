using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;

namespace CopyPayPay.Contrlos
{
    /// <summary>
    /// Логика взаимодействия для NewTextBox.xaml
    /// </summary>
    public partial class NewTextBox :System.Windows.Controls.UserControl
    {
        System.Drawing.Point CurPosition;
        double Height_save = 0;
        bool isOpen = true;
        public NewTextBox()
        {
            InitializeComponent();
            DateText.Content = DateTime.Now.ToString();
            Height_save = this.Height;
        }
        public int IDpanel
        {
            get;set;
        }
        public string Text
        {
            get { return (string)GetValue(V); }
            set { SetValue(V, value); }
        }
        public static readonly DependencyProperty V = DependencyProperty.Register(
            "Text", typeof(string), typeof(NewTextBox),
            new PropertyMetadata(
                "", 
                (o, args) => ((NewTextBox)o).Update())
            );
        string Date = DateTime.Now.ToString();
        void Update()
        {
            this.MaxWidth = 1200 - 12;
            this.Width = 1200 - 12;
            this.Margin = new Thickness(0, 0, 0, 0);
            int line_ = Text.Split(new char[] { '\n' }).Length;
            DateText.Content =
                Date + 
                "  Characters: " + Text.Length.ToString() + 
                "  Line: " + line_.ToString();

            RichText.Document = new FlowDocument(new Paragraph(new Run(Text)));
        }
        ExpanderControl expanderControl_l = null;
        private void DateText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton != MouseButtonState.Pressed)
            {
                isOpen = !isOpen;             
                switch (isOpen)
                {
                    case true:
                        this.Height = Height_save;
                        break;
                    case false:
                        this.Height = 26;
                        break;
                    default:
                        break;
                }
            }
            else if(e.LeftButton != MouseButtonState.Pressed)
            {
                // Панель манипуляции над выбранным елементом списка 
                ExpanderControl expanderControl = new ExpanderControl();
                CurPosition = User32.GetCursorPosition();
                expanderControl.Top = CurPosition.Y - 10;
                expanderControl.Left = CurPosition.X - 10;
                expanderControl.Removinglines.Click += SavingToFile;
                expanderControl.DeletePanel.Click += DeletePanelID;
                expanderControl.Show();
                expanderControl_l = expanderControl;
            }  
        }

        private void SavingToFile(object sender, RoutedEventArgs e)
        {
            string Fil = AppDomain.CurrentDomain.BaseDirectory;
            string SaveDir = Fil + @"\save";
            if (!Directory.Exists(SaveDir))
                Directory.CreateDirectory(SaveDir);
           
            using (FileStream FS = File.Create(SaveDir + "\\" + lib.СhangeString.MultiReplace(DateText.Content.ToString(), new char[] { ':' , '.'}, '_') + ".txt"))
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes(
                    new TextRange(RichText.Document.ContentStart, RichText.Document.ContentEnd).Text
                    );

                FS.Write(info, 0, info.Length);
            }
            expanderControl_l.Close();
        }

        private void DeletePanelID(object sender, RoutedEventArgs e)
        {
            if (Data.Wind.Listpanel.Items.Count > 0)
            {
                Data.Wind.Listpanel.Items.RemoveAt(
                    Data.Wind.Listpanel.SelectedIndex < 0 ? 0 : Data.Wind.Listpanel.SelectedIndex
                    );
                if (expanderControl_l == null)
                    return;
                expanderControl_l.Close();
            }
        }

        private void RichText_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange doc = new TextRange(RichText.Document.ContentStart, RichText.Document.ContentEnd);
            int line_ = doc.Text.Split(new char[] { '\n' }).Length;
            if(line_ > 1)
            {
                line_ -= 1;
            }
            DateText.Content =
                Date +
                "  Characters: " + doc.Text.Length.ToString() +
                "  Line: " + line_.ToString();

        }
    }
}
