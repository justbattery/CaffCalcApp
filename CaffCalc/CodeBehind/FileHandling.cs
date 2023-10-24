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
        public T Load<T>(string path)
        {
            if (File.Exists(path))
            {
                DataContractSerializer Serializer = new DataContractSerializer(typeof(T));
                using (FileStream Stream = new FileStream(path, FileMode.Open))
                {
                    return (T)Serializer.ReadObject(Stream);
                }
            }
            return default(T);
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
