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
    public class SumUpCaffeine
    {
        public int SumUpCaffeineFunction(int sumConsumption)
        {
            foreach (var stats in dailyConsumption)
            {
                sumConsumption += stats.Value.HowMuchConsumedThatDay;
            }
            return sumConsumption;
        }
    }
}
