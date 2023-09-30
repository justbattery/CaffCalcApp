using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.Pages
{
    internal class SumUpCaffeine
    {
        public static (int sumConsuption, int sumLeft) SumUpCaffeineFunction(int sumConsumption, int sumLeft)
        {
            foreach (var stats in dailyConsumption)
            {
                sumConsumption += stats.Value.HowMuchConsumedThatDay;
                sumLeft += stats.Value.HowMuchLeftThatDay;
            }
            return (sumConsumption, sumLeft);
        }
    }
}
