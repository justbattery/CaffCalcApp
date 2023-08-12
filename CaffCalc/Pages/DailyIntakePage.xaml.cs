﻿using CaffCalc.CodeBehind;
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
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy DailyIntakePage.xaml
    /// </summary>
    public partial class DailyIntakePage : Page
    {
        public DailyIntakePage()
        {
            InitializeComponent();

            chooseDrinkBox.ItemsSource = BackendDB.drinks;
            chooseDrinkBox.DisplayMemberPath = "Name";
            chooseDrinkBox.SelectedValuePath = "Number";
        }

        private void DrinkConsumedButton_Click(object sender, RoutedEventArgs e)
        {
            Drink choosenDrink = (Drink)chooseDrinkBox.SelectedItem;
            TodaysCaffeineConsumption += choosenDrink.CaffeineMg;
            HowMuchLeft -= choosenDrink.CaffeineMg;

            foreach(var testDrink in ListOfDrinks)
            {
                if(choosenDrink.Name == testDrink.Name)
                {
                    int count = testDrink.Count + 1;
                    TodaysDrinks drink = new TodaysDrinks{ Name = choosenDrink.Name, Count =  count};
                    int index = ListOfDrinks.IndexOf(testDrink);
                    ListOfDrinks.RemoveAt(index);
                    ListOfDrinks.Insert(index, drink);
                }
                else
                {
                    int count = 1;
                    TodaysDrinks drink = new TodaysDrinks { Name = choosenDrink.Name, Count = count };
                    ListOfDrinks.Add(drink);
                }
            }
            SaveDrinksToDictionary();
            SaveStatsToFile();
            // TO JEST DO POTĘŻNEJ ZMIANY
            LimitTextBlock.Text = $"Limit: {safeDailyDose}mg";
            CaffeineIntakeTextBlock.Text = $"Ile wypiłeś: {TodaysCaffeineConsumption}mg";
            CaffeineLeftTextBlock.Text = $"Ile zostało: {HowMuchLeft}mg";
            ThisDrinkLeftTextBlock.Text = $"TEST: {HowMuchLeft / choosenDrink.CaffeineMg} {choosenDrink.Name}";
        }
    }
}