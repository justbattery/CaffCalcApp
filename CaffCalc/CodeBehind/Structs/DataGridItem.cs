using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffCalc.CodeBehind
{
    public class DataGridItem
    {
        public string Key { get; set; }
        public DailyConsumption Value { get; set; }
        public int HowMuchLeftThatDay => Value.HowMuchLeftThatDay;
        public int HowMuchConsumedThatDay => Value.HowMuchConsumedThatDay;
        public List<TodaysDrinks> DrinksConsumedThatDay => Value.drinksConsumedThatDay;
    }
}
