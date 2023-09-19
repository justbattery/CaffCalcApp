using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.DailyIntakeFunctions
{
    internal class AddDrinkToList
    {
        public static void AddDrink(Drink choosenDrink)
        {
            System.Diagnostics.Debug.WriteLine($"Test started");

            TodaysDrinks drink3 = new TodaysDrinks { Name = "TEST", Count = 3 };
            TodaysDrinksList.Add(drink3);

            foreach (TodaysDrinks testDrink in TodaysDrinksList)
            {
                System.Diagnostics.Debug.WriteLine($"Test stage 1");
                if (choosenDrink.Name == testDrink.Name) // CO JEŚLI NAZWA TA SAMA
                {
                    System.Diagnostics.Debug.WriteLine($"Route 1");
                    int count = testDrink.Count + 1;
                    TodaysDrinks drink = new TodaysDrinks { Name = choosenDrink.Name, Count = count };
                    int index = TodaysDrinksList.IndexOf(testDrink);
                    TodaysDrinksList.RemoveAt(index);
                    TodaysDrinksList.Insert(index, drink);
                    break;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Route 2");
                    int count = 1;
                    TodaysDrinks drink = new TodaysDrinks { Name = choosenDrink.Name, Count = count };
                    TodaysDrinksList.Add(drink);
                    break;
                }
            }

            System.Diagnostics.Debug.WriteLine($"Test ended");
            SaveStatsToDictionary();
            SaveStatsToFile();
        }
    }
}
