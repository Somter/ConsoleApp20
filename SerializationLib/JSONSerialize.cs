using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using InfCar;

namespace SerializationLib
{
    public class JSONSerialize : ISerialize
    {
        public void Save(string filePath, List<InformationCarrier> carriers)
        {
            var serializer = new DataContractJsonSerializer(
                typeof(List<InformationCarrier>),
                new DataContractJsonSerializerSettings
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
            var serializer = new DataContractJsonSerializer(
                typeof(List<InformationCarrier>),
                new DataContractJsonSerializerSettings
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
