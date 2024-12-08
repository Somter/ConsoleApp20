using LoggingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InfCar
{
    [DataContract]
    public class HDD : InformationCarrier
    {
        [DataMember]
        public int SpindleSpeed { get; set; }

        public HDD(string manufacturer, string model, string name, double capacity, int quantity, int spindleSpeed)
            : base(manufacturer, model, name, capacity, quantity)
        {
            SpindleSpeed = spindleSpeed;
        }

        public override void Report()
        {
            Console.WriteLine($"--- Отчёт для съемного жестко ---");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Производитель: {ManufacturersName}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Ёмкость: {MediaCapacity} Гб");
            Console.WriteLine($"Количество: {Quantity}");
            Console.WriteLine($"Скорость вращения шпинделя: {SpindleSpeed} об/мин");
        }

        public override void LoadData()
        {
            Console.WriteLine($"Данные загружаются на жесткий диск {Name} со скоростью вращения шпинделя {SpindleSpeed} об/мин");
        }

        public override void SaveData()
        {
            Console.WriteLine($"Данные сохраняются на жесткий диск {Name}");
        }
    }
}
