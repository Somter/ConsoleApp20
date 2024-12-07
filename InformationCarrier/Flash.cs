using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationCarrier
{
    class Flash : InformationCarrier
    {
        public double UsbSpeed { get; set; }
        public Flash(string manufacturer, string model, string name, double capacity, int quantity)
           : base(manufacturer, model, name, capacity, quantity) { }

        public override void Report()
        {
            Console.WriteLine($"--- Отчёт для Flash-памяти ---");
            base.Report();
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
