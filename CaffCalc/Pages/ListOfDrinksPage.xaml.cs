using CaffCalc.CodeBehind;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CaffCalc.CodeBehind.Drink;
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ListOfDrinksPage.xaml
    /// </summary>
    public partial class ListOfDrinksPage : Page
    {
        public ListOfDrinksPage()
        {
            InitializeComponent();
            dataGridOfDrinks.ItemsSource = drinks;
        }
        private void addDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            string userDrinkName = drinkName.Text;
            int.TryParse(drinkCapacity.Text, out int userCapacityMl);

            int.TryParse(drinkCaffeineContent.Text, out int userCaffeineContent);
            if (per100mlRadio.IsChecked == true)
                userCaffeineContent *= (userCapacityMl / 100);
            drinks.Add(new Drink { Number = DrinkId++, Name = userDrinkName, CaffeineMg = userCaffeineContent, CapacityMl = userCapacityMl });

            dataGridOfDrinks.Items.Refresh();

            FileHandling drinkHandler = new FileHandling();
            drinkHandler.Save(@"Resources\Data\DrinkList.xml", drinks);
            //BackendDB.DrinkToFile(); !!!!!!!!!!!!!!!!!!!!!
        }

        private void removeDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridOfDrinks.SelectedItem is Drink selectedDrink)
            {
                drinks.Remove(selectedDrink);

                dataGridOfDrinks.Items.Refresh();

                FileHandling drinkHandler = new FileHandling();
                drinkHandler.Save(@"Resources\Data\DrinkList.xml", drinks);
                //DrinkToFile(); !!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }
    }
}
