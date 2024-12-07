using LoggingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InfCar
{
    [DataContract]
    [KnownType(typeof(Flash))]
    [KnownType(typeof(DVD))]
    [KnownType(typeof(HDD))]
    public abstract class InformationCarrier
    {
        [DataMember]
        public string ManufacturersName { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public double MediaCapacity { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        protected InformationCarrier(string manufacturer, string model, string name, double capacity, int quantity)
        {
            ManufacturersName = manufacturer;
            Model = model;
            Name = name;
            MediaCapacity = capacity;
            Quantity = quantity;
        }

        public virtual void Report()
        {
            Console.WriteLine($"Отчёт для {Name}: ");
            Console.WriteLine($"Производитель: {ManufacturersName}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Ёмкость: {MediaCapacity} Гб");
            Console.WriteLine($"Количество: {Quantity}");
        }

        public abstract void LoadData();
        public abstract void SaveData();
    }
}
