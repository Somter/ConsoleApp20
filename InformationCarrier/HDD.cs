using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationCarrier
{
    class HDD : InformationCarrier
    {
        public int SpindleSpeed { get; set; } // Скорость вращения шпинделя в об/мин

        public HDD(string manufacturer, string model, string name, double capacity, int quantity, int spindleSpeed)
            : base(manufacturer, model, name, capacity, quantity)
        {
            SpindleSpeed = spindleSpeed;
        }

        public override void Report()
        {
            Console.WriteLine($"--- Отчёт для съемного HDD ---");
            base.Report();
            Console.WriteLine($"Скорость вращения шпинделя: {SpindleSpeed} об/мин");
        }

        public override void LoadData()
        {
            Console.WriteLine($"Данные загружаются на съемный HDD {Name} со скоростью вращения шпинделя {SpindleSpeed} об/мин...");
        }

        public override void SaveData()
        {
            Console.WriteLine($"Данные сохраняются на съемный HDD {Name}...");
        }
    }
}
