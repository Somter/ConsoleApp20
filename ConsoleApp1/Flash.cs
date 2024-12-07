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
    public class Flash : InformationCarrier
    {
        [DataMember]
        public double UsbSpeed { get; set; }

        public Flash(string manufacturer, string model, string name, double capacity, int quantity, double usbSpeed)
            : base(manufacturer, model, name, capacity, quantity)
        {
            UsbSpeed = usbSpeed;
        }

        public override void Report()
        {
            Console.WriteLine($"--- Отчёт для Flash-памяти ---");
            Console.WriteLine($"Производитель: {ManufacturersName}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Ёмкость: {MediaCapacity} Гб");
            Console.WriteLine($"Количество: {Quantity}");
            Console.WriteLine($"Скорость USB: {UsbSpeed} МБ/с");
        }

        public override void LoadData()
        {
            Console.WriteLine($"Данные загружаются на Flash-память {Name} со скоростью {UsbSpeed} МБ/с");
        }

        public override void SaveData()
        {
            Console.WriteLine($"Данные сохраняются на Flash-память {Name}");
        }
    }
}
