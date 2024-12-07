using System;
using LoggingLib;
using InfCar;
using SerializationLib;

namespace PriceListLib
{
    public class PriceList
    {
        private List<InformationCarrier> carriers = new List<InformationCarrier>(); 
        public void AddCarrier(InformationCarrier carrier)
        {
            carriers.Add(carrier);
            Console.WriteLine($"Носитель информации {carrier.Name} добавлен.");
        }
        public void RemoveCarrier(Func<InformationCarrier, bool> predicate)
        {
            var toRemove = carriers.Where(predicate).ToList();
            if (toRemove.Count == 0)
            {
                Console.WriteLine("Носители информации для удаления не найдены.");
                return;
            }

            foreach (var item in toRemove)
            {
                carriers.Remove(item);
                Console.WriteLine($"Носитель информации {item.Name} был удален.");
            }
        }
        public void PrintAll(ILog log)
        {
            if (carriers.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("--- Печать списка носителей информации ---");
            foreach (var carrier in carriers)
            {
                carrier.Report();
                log.Print("");
            }
        }

        public void SearchCarrier(Func<InformationCarrier, bool> predicate)
        {
            var found = carriers.Where(predicate).ToList();
            if (found.Count == 0)
            {
                Console.WriteLine("Носитель информации по заданному критерию не найден.");
            }
            else
            {
                Console.WriteLine("Найденные носители информации:");
                foreach (var item in found)
                {
                    item.Report();
                    Console.WriteLine();
                }
            }
        }
        public List<InformationCarrier> GetAllCarriers()
        {
            return carriers;
        }
        public void UpdateCarrier(Func<InformationCarrier, bool> predicate, Action<InformationCarrier> updateAction)
        {
            var found = carriers.Where(predicate).ToList();
            if (found.Count == 0)
            {
                Console.WriteLine("Носитель информации для обновления не найден.");
                return;
            }

            foreach (var item in found)
            {
                updateAction(item);
                Console.WriteLine($"Параметры носителя информации {item.Name} были изменены.");
            }
        }
        public void SaveToFile(ISerialize serializer, string filePath)
        {
            serializer.Save(filePath, carriers);
            Console.WriteLine($"Данные успешно сохранены в файл: {filePath}");
        }
        public void LoadFromFile(ISerialize serializer, string filePath)
        {
            carriers = serializer.Load(filePath);
            Console.WriteLine($"Данные успешно загружены из файла: {filePath}");
        }
    }
}
