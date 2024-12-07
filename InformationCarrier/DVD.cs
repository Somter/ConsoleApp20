using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationCarrier
{
    class DVD : InformationCarrier
    {
        public double WriteSpeed { get; set; } 
        public DVD(string manufacturer, string model, string name, double capacity, int quantity, double writeSpeed)
            : base(manufacturer, model, name, capacity, quantity)
        {
            WriteSpeed = writeSpeed;
        }
        public override void Report()
        {
            Console.WriteLine($"--- Отчёт для DVD-диска ---");
            base.Report();
            Console.WriteLine($"Скорость записи: {WriteSpeed} МБ/с");
        }
        public override void LoadData()
        {
            Console.WriteLine($"Данные загружаются на DVD-диск {Name}...");
        }
        public override void SaveData()
        {
            Console.WriteLine($"Данные записываются на DVD-диск {Name} со скоростью {WriteSpeed} МБ/с...");
        }
    }
}
