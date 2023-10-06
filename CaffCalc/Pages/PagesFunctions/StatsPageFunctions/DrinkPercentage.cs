using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffCalc.Pages.PagesFunctions.StatsPageFunctions
{
    public class DrinkPercentage
    {
        public string DrinkList(IEnumerable<object> everyDrink)
        {
            int totalDrinksSum = 0;
            foreach (var drinkSum in everyDrink)
            {
                totalDrinksSum += drinkSum.Count; /// SUMA WSZYSTKICH NAPOJÓW
            }
            string drinkList = "Procentowy udział: ";
            foreach (var drink in everyDrink)
            {
                float drinkPercentage = (float)Math.Round((double)100 * drink.Count) / totalDrinksSum;
                drinkList += $"\n{drink.Name} - {drinkPercentage}%";
            }
            return drinkList;
        }
    }
}
