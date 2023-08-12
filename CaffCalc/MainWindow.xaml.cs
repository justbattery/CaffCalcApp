using CaffCalc.CodeBehind;
using CaffCalc.Pages;
using CaffCalc.Windows;
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

namespace CaffCalc
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    // NOTATKI DO PROJEKTU
    // - Zmiana UI dailyintake
    // - Zrób statystyki
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (File.Exists(@"Resources\Data\UserData.xml"))
            {
                BackendDB.UserFromFile();
            }
            else
            {
                DataCollectionWindow dataCollectionWindow = new DataCollectionWindow();
                dataCollectionWindow.ShowDialog();
            }

            BackendDB.DrinkFromFile();
            BackendDB.CalcSafeDailyDose();
            BackendDB.GetStatsFromFile();
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            Dictionary<string, Uri> menuControl = new Dictionary<string, Uri>()
            {
                {"Kofeinowy dziennik", new Uri("Pages/DailyIntakePage.xaml", UriKind.Relative)},
                {"Statystyki", new Uri("Pages/StatsPage.xaml", UriKind.Relative) },
                {"Lista napojów", new Uri("Pages/ListOfDrinksPage.xaml", UriKind.Relative) },
                {"Profil", new Uri("Pages/ProfilePage.xaml", UriKind.Relative) },
                {"Informacje", new Uri("Pages/InfoPage.xaml", UriKind.Relative) }
            };
            string content = radioButton.Content.ToString();

            foreach (string key in menuControl.Keys)
            {
                if (content == key)
                {
                    ChoosenContent.Source = menuControl[key];
                }
            }
        }
    }
}
