using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CaffCalc.CodeBehind
{

    [DataContract] public struct Users
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public string Surname { get; set; }
        [DataMember] public int WeightKg { get; set; }
    }
}
