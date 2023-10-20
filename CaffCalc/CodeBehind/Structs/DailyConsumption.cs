using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CaffCalc.CodeBehind
{
    [DataContract]
    public struct DailyConsumption
    {
        [DataMember] public int HowMuchLeftThatDay;
        [DataMember] public int HowMuchConsumedThatDay;
        [DataMember] public List<TodaysDrinks> drinksConsumedThatDay;
    }
}
