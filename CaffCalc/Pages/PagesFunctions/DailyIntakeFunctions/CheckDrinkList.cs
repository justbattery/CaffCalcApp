using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CaffCalc.CodeBehind.Drink;
using static CaffCalc.CodeBehind.BackendDB;
using CaffCalc.CodeBehind;

namespace CaffCalc.DailyIntakeFunctions
{
    internal class CheckDrinkList
    {
        public static void DrinkForEach(Drink choosenDrink)
        {
            foreach (TodaysDrinks testDrink in TodaysDrinksList)
            {
                if (choosenDrink.Name == testDrink.Name) // CO JEŚLI NAZWA TA SAMA
                {
                    int count = testDrink.Count + 1;
                    TodaysDrinks drink = new TodaysDrinks { Name = choosenDrink.Name, Count = count };
                    int index = TodaysDrinksList.IndexOf(testDrink);
                    TodaysDrinksList.RemoveAt(index);
                    TodaysDrinksList.Insert(index, drink);
                    break;
                }
                else
                {
                    int count = 1;
                    TodaysDrinks drink = new TodaysDrinks { Name = choosenDrink.Name, Count = count };
                    TodaysDrinksList.Add(drink);
                    break;
                }
            }
        }
    }
}
