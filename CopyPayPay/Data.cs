using System;
using System.Windows.Media;

namespace CopyPayPay
{
    class Data
    {       
        public static MainWindow Wind
        {
            get; set;
        }
        public static string FolderSave = AppDomain.CurrentDomain.BaseDirectory + @"\save";


    }
    [Serializable]
     public class Setting
     {
        
        public  Color BackgroundColor_wind
        {
            get;set;
        }
     }
    
}
