using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract public class InformationCarrier
    {
        protected string ManufacturersName { get; set; }
        protected string Model { get; set; }
        protected double MediaCapacity { get; set; }
        protected string Name { get; set; }
        protected int Quantity { get; set; }

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
