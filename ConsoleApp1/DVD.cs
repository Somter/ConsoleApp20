using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InfCar
{
    [DataContract]
    public class DVD : InformationCarrier
    {
        [DataMember]
        public double WriteSpeed { get; set; }

        public DVD(string manufacturer, string model, string name, double capacity, int quantity, double writeSpeed)
            : base(manufacturer, model, name, capacity, quantity)
        {
            WriteSpeed = writeSpeed;
        }

        public override void Report()
        {
            Console.WriteLine($"--- Отчёт для DVD-диска ---");
            Console.WriteLine($"Производитель: {ManufacturersName}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Ёмкость: {MediaCapacity} Гб");
            Console.WriteLine($"Количество: {Quantity}");
            Console.WriteLine($"Скорость записи: {WriteSpeed} МБ/с");
        }

        public override void LoadData()
        {
            Console.WriteLine($"Данные загружаются на DVD-диск {Name} со скоростью {WriteSpeed} МБ/с");
        }

        public override void SaveData()
        {
            Console.WriteLine($"Данные сохраняются на DVD-диск {Name}");
        }
    }
}
