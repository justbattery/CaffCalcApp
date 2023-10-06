using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.Pages
{
    // DODAJ FUNKCJĘ SPRAWDZAJĄCĄ ISTNIENIE PLIKU !!!
    public class StatsAssignment
    {
        public (int, string) AssignMaxValue(int sumConsumption)
        {
            int maxConsumption;
            string dayMaxConsumption;

            if (File.Exists(@"Resources\Data\StatsDrinks.xml"))
            {
                maxConsumption = dailyConsumption.Max(max => max.Value.HowMuchConsumedThatDay);
                dayMaxConsumption = dailyConsumption.OrderByDescending(max => max.Value.HowMuchConsumedThatDay).First().Key;

                return (maxConsumption, dayMaxConsumption);
            }
            else
            {
                maxConsumption = 0;
                dayMaxConsumption = "0";

                return (maxConsumption, dayMaxConsumption);
            }
        }
        public (int, string) AssignMinValue(int sumConsumption)
        {
            int minConsumption;
            string dayMinConsumption;

            if (File.Exists(@"Resources\Data\StatsDrinks.xml"))
            {
                minConsumption = dailyConsumption.Min(min => min.Value.HowMuchConsumedThatDay);
                dayMinConsumption = dailyConsumption.OrderByDescending(min => min.Value.HowMuchConsumedThatDay).Last().Key;

                return (minConsumption, dayMinConsumption);
            }
            else
            {
                minConsumption = 0;
                dayMinConsumption = "0";

                return (minConsumption, dayMinConsumption);
            }
        }
        public int CalcAverageValue(int sumConsumption)
        {
            int avgConsumption;
            if (File.Exists(@"Resources\Data\StatsDrinks.xml"))
            {
                avgConsumption = sumConsumption / dailyConsumption.Count();

                return avgConsumption;
            }
            else
            {
                avgConsumption = 0;

                return avgConsumption;
            }
        }
    }
}
