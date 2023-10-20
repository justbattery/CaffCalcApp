using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CaffCalc.CodeBehind
{
    public class FileHandling
    {
        public void Load<T>(string path, T type)
        {
            if (File.Exists(path))
            {
                DataContractSerializer Serializer = new DataContractSerializer(typeof(T));
                using (FileStream Stream = new FileStream(path, FileMode.Open))
                {
                    type = (T)Serializer.ReadObject(Stream);
                }
            }
        }

        public void Save<T>(string path, T type)
        {
            DataContractSerializer userSerializer = new DataContractSerializer(typeof(T));
            using (FileStream userStream = new FileStream(path, FileMode.Create))
            {
                userSerializer.WriteObject(userStream, type);
            }
        }
    }
}
