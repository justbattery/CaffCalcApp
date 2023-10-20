using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CaffCalc.CodeBehind
{
    [DataContract]
    public struct TodaysDrinks // DZISIAJ WYPITE NAPOJE
    {
        [DataMember] public string Name;
        [DataMember] public int Count;
    }
}
