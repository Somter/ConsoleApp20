using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using InfCar;

namespace SerializationLib
{
    public class XmlSerialize : ISerialize
    {
        public void Save(string filePath, List<InformationCarrier> carriers)
        {
            var serializer = new DataContractSerializer(
                typeof(List<InformationCarrier>),
                new DataContractSerializerSettings
                {
                    KnownTypes = new[] { typeof(Flash), typeof(DVD), typeof(HDD) }
                });

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.WriteObject(stream, carriers);
            }
        }

        public List<InformationCarrier> Load(string filePath)
        {
            var serializer = new DataContractSerializer(
                typeof(List<InformationCarrier>),
                new DataContractSerializerSettings
                {
                    KnownTypes = new[] { typeof(Flash), typeof(DVD), typeof(HDD) }
                });

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return (List<InformationCarrier>)serializer.ReadObject(stream);
            }
        }
    }
}
