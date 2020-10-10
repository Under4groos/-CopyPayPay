using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CopyPayPay
{
    class Data
    {
        static int _SizeText = 14;
        public static MainWindow Wind
        {
            get; set;
        }
        public static int SizeText
        {
            get => _SizeText;
            set
            {
                if ((value > 0) && (value < 55))
                {
                    _SizeText = value;
                }
                else
                {
                    _SizeText = 55;
                }
            }
        }
        static Color _BackgroundColorText = Color.FromArgb(100, 255, 255, 255);
        public static Color BackgroundColor
        {
            get => _BackgroundColorText;
            set
            {
                _BackgroundColorText = value;
            }
        }
        static Color _ForegroundColorText = Color.FromArgb(255, 255, 255, 255);
        public static Color ForegroundColor
        {
            get => _ForegroundColorText;
            set
            {
                _ForegroundColorText = value;
            }
        }
        public static int MaxLenText = 250;
        public static int ActiveID
        {
            get;set;
        }
    }

}
