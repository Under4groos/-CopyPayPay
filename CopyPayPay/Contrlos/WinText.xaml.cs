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
using System.Windows.Shapes;

namespace CopyPayPay.Contrlos
{
    /// <summary>
    /// Логика взаимодействия для WinText.xaml
    /// </summary>
    public partial class WinText : Window
    {
        public WinText()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return (string)GetValue(V); }
            set { SetValue(V, value); }
        }
        public static readonly DependencyProperty V =
         DependencyProperty.Register(
             "Text", typeof(string), typeof(WinText),
             new PropertyMetadata("", (o, args) => ((WinText)o).Update()));
        void Update()
        {
            RichTextBox_.Document = new FlowDocument(new Paragraph(new Run(Text)));
        }
    }
}
