using InfCar;
using LoggingLib;
using PriceListLib;
using SerializationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    public class Menu
    {
         PriceList priceList = new PriceList();
         ILog log = new ConsoleLog();

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавление носителя информации в список");
                Console.WriteLine("2. Удаление носителя информации из списка по критерию");
                Console.WriteLine("3. Печать списка всех носителей информации");
                Console.WriteLine("4. Изменение данных носителя информации");
                Console.WriteLine("5. Поиск носителя информации по критерию");
                Console.WriteLine("6. Сохранение данных в файл");
                Console.WriteLine("7. Загрузка данных из файла");
                Console.WriteLine("8. Выход");

                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCarrier();
                        break;
                    case "2":
                        RemoveCarrier();
                        break;
                    case "3":
                        PrintAll();
                        break;
                    case "4":
                        UpdateCarrier();
                        break;
                    case "5":
                        SearchCarrier();
                        break;
                    case "6":
                        SaveData();
                        break;
                    case "7":
                        LoadData();
                        break;
                    case "8":
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }

        private void AddCarrier()
        {
            Console.WriteLine("Добавление носителя информации.");
            Console.Write("Введите тип носителя (Flash, DVD, HDD): ");
            var type = Console.ReadLine();

            Console.Write("Введите имя производителя: ");
            var manufacturer = Console.ReadLine();
            Console.Write("Введите модель: ");
            var model = Console.ReadLine();
            Console.Write("Введите наименование: ");
            var name = Console.ReadLine();
            Console.Write("Введите ёмкость: ");
            double.TryParse(Console.ReadLine(), out var capacity);
            Console.Write("Введите количество: ");
            int.TryParse(Console.ReadLine(), out var quantity);

            InformationCarrier carrier = null;

            if (type.Equals("Flash", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите скорость USB: ");
                double.TryParse(Console.ReadLine(), out var usbSpeed);
                carrier = new Flash(manufacturer, model, name, capacity, quantity, usbSpeed);
            }
            else if (type.Equals("DVD", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите скорость записи: ");
                double.TryParse(Console.ReadLine(), out var writeSpeed);
                carrier = new DVD(manufacturer, model, name, capacity, quantity, writeSpeed);
            }
            else if (type.Equals("HDD", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите скорость вращения шпинделя: ");
                int.TryParse(Console.ReadLine(), out var spindleSpeed);
                carrier = new HDD(manufacturer, model, name, capacity, quantity, spindleSpeed);
            }
            else
            {
                Console.WriteLine("Неверный тип носителя.");
                return;
            }

            priceList.AddCarrier(carrier);
            Console.WriteLine("Носитель информации успешно добавлен.");
        }

        private void RemoveCarrier()
        {
            Console.WriteLine("Удаление носителя информации по критерию.");
            Console.Write("Введите критерий для удаления (имя производителя, модель, наименование, ёмкость носителя, количество): ");
            var criteria = Console.ReadLine();
            priceList.RemoveCarrier(c =>
                c.ManufacturersName.Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.Model.Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.Name.Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.MediaCapacity.ToString().Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.Quantity.ToString().Equals(criteria, StringComparison.OrdinalIgnoreCase)
            );
        }

        private void PrintAll()
        {
            priceList.PrintAll(log);
        }

        private void UpdateCarrier()
        {
            Console.WriteLine("Редактирование данных носителя информации.");

            Console.Write("Введите имя накопителя, который хотите отредактировать: ");
            var nameToEdit = Console.ReadLine();

            var foundCarrier = priceList.GetAllCarriers().FirstOrDefault(c => c.Name.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase));

            if (foundCarrier == null)
            {
                Console.WriteLine($"Носитель информации с именем '{nameToEdit}' не найден.");
                return;
            }

            Console.WriteLine($"Найден носитель информации: {foundCarrier.Name}");

            while (true)
            {
                Console.WriteLine("\nВыберите характеристику для редактирования:");
                Console.WriteLine("1. Ёмкость носителя");
                Console.WriteLine("2. Количество");
                Console.WriteLine("3. Скорость записи (DVD)");
                Console.WriteLine("4. Скорость вращения шпинделя (HDD)");
                Console.WriteLine("5. Завершить редактирование");

                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите новую ёмкость носителя: ");
                        if (double.TryParse(Console.ReadLine(), out var newCapacity))
                        {
                            foundCarrier.MediaCapacity = newCapacity;
                            Console.WriteLine($"Ёмкость носителя успешно обновлена: {newCapacity} ГБ.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод. Пожалуйста, введите корректное число.");
                        }
                        break;
                    case "2":
                        Console.Write("Введите новое количество: ");
                        if (int.TryParse(Console.ReadLine(), out var newQuantity))
                        {
                            foundCarrier.Quantity = newQuantity;
                            Console.WriteLine($"Количество успешно обновлено: {newQuantity}.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод. Пожалуйста, введите корректное число.");
                        }
                        break;
                    case "3":
                        if (foundCarrier is DVD dvdCarrier)
                        {
                            Console.Write("Введите новую скорость записи: ");
                            if (double.TryParse(Console.ReadLine(), out var newWriteSpeed))
                            {
                                dvdCarrier.WriteSpeed = newWriteSpeed;
                                Console.WriteLine($"Скорость записи успешно обновлена: {newWriteSpeed}.");
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод. Пожалуйста, введите корректное число.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Выбранный носитель не поддерживает редактирование скорости записи.");
                        }
                        break;
                    case "4":
                        if (foundCarrier is HDD hddCarrier)
                        {
                            Console.Write("Введите новую скорость вращения шпинделя: ");
                            if (int.TryParse(Console.ReadLine(), out var newSpindleSpeed))
                            {
                                hddCarrier.SpindleSpeed = newSpindleSpeed;
                                Console.WriteLine($"Скорость вращения шпинделя успешно обновлена: {newSpindleSpeed}.");
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод. Пожалуйста, введите корректное число.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Выбранный носитель не поддерживает редактирование скорости вращения шпинделя.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Завершение редактирования.");
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        private void SearchCarrier()
        {
            Console.WriteLine("Поиск носителя информации по критерию.");
            Console.Write("Введите критерий для поиска (имя производителя, модель, наименование, ёмкость носителя, количество): ");
            var criteria = Console.ReadLine();
            priceList.SearchCarrier(c =>
                c.ManufacturersName.Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.Model.Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.Name.Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.MediaCapacity.ToString().Equals(criteria, StringComparison.OrdinalIgnoreCase) ||
                c.Quantity.ToString().Equals(criteria, StringComparison.OrdinalIgnoreCase)
            );
        }

        private void SaveData()
        {
            Console.WriteLine("Сохранение данных в файл.");
            Console.WriteLine("Выберите формат: json, xml, soap");
            var format = Console.ReadLine().ToLower();
            ISerialize serializer = format switch
            {
                "json" => new JSONSerialize(),
                "xml" => new XmlSerialize(),
                "soap" => new SoapSerialize(),
                _ => throw new ArgumentException("Неверный формат")
            };

            Console.Write("Введите путь для сохранения данных: ");
            var path = Console.ReadLine();
            priceList.SaveToFile(serializer, path);
        }

        private void LoadData()
        {
            Console.WriteLine("Загрузка данных из файла.");
            Console.WriteLine("Выберите формат: json, xml, soap");
            var format = Console.ReadLine().ToLower();
            ISerialize serializer = format switch
            {
                "json" => new JSONSerialize(),
                "xml" => new XmlSerialize(),
                "soap" => new SoapSerialize(),
                _ => throw new ArgumentException("Неверный формат")
            };

            Console.Write("Введите путь для загрузки данных: ");
            var path = Console.ReadLine();
            priceList.LoadFromFile(serializer, path);
        }
    }
}
