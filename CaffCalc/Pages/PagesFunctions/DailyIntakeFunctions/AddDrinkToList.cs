using CaffCalc.CodeBehind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static CaffCalc.CodeBehind.BackendDB;
using static CaffCalc.CodeBehind.Drink;
using static CaffCalc.DailyIntakeFunctions.CheckDrinkList;

namespace CaffCalc.DailyIntakeFunctions
{
    internal class AddDrinkToList
    {
        public static void AddDrink(Drink choosenDrink)
        {
            if(TodaysDrinksList.Count == 0)
            {
                TodaysDrinks drink3 = new TodaysDrinks { Name = "TEST", Count = 1 }; // INACZEJ SIĘ WYKRZACZY
                TodaysDrinksList.Add(drink3);

                DrinkForEach(choosenDrink);

                TodaysDrinksList.Remove(drink3);
            }
            else
            {
                DrinkForEach(choosenDrink);
            }
            FileHandling statsHandler = new FileHandling();
            SaveStatsToDictionary();
            statsHandler.Save(@"Resources\Data\StatsDrinks.xml", dailyConsumption);
            //SaveStatsToFile();
        }
    }
}
