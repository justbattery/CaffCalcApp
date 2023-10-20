using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CaffCalc.CodeBehind
{
    [DataContract]
    public struct Drink
    {
        [DataMember] public int Number { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public int CaffeineMg { get; set; }
        [DataMember] public int CapacityMl { get; set; }
    }
}
