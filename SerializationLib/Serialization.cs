using System;
using InfCar;

namespace SerializationLib
{
    public interface ISerialize
    {
        void Save(string filePath, List<InformationCarrier> carriers);
        List<InformationCarrier> Load(string filePath);
    }
}
