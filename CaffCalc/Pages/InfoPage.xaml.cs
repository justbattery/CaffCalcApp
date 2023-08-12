using System;
using System.Collections.Generic;
using System.IO;
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

namespace CaffCalc.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();

            if (File.Exists("Resources/Text/Informator.txt"))
            {
                string informationContent = File.ReadAllText("Resources/Text/Informator.txt");
                Info.Text = informationContent;
            }
            else Info.Text = "UWAGA BRAK PLIKU \"Informator.txt\"";
        }
    }
}
