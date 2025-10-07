using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Threading.Channels;
using Initial_Activities;

namespace Initial_Activities
{
    public class ShowMenu
    {
        private readonly Dictionary<int, Data> catalog = new();

        public ShowMenu()
        {
            catalog.Add(101, new Data(101, "Hamburguer", 12m));
            catalog.Add(102, new Data(102, "French Fries", 7m));
            catalog.Add(103, new Data(103, "Soda", 5m));
            catalog.Add(104, new Data(104, "Lemonade", 9m));
            catalog.Add(105, new Data(105, "Mix Sauce", 3m));
            catalog.Add(106, new Data(106, "Orange Juice", 10m));
        }
        public void ShowMenuItems()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("WELCOME to the Rafa's Dinner Club");
            Console.WriteLine("*********************************");
            Console.WriteLine("\nHere is the menu of the day\n");
            foreach (Data item in catalog.Values)
            {
                Console.WriteLine($"ID {item.Id:000}, {item.Name,-15}: ${item.Value:N2}");
            }
            Console.WriteLine($"ID 000, Finish the Order!");
        }
        public void StartOrder()
        {
            List<Data> listOrder = new List<Data>();
            int idChoosed = -1;

            while (idChoosed != 0)
            {
                Console.WriteLine("\nPlease, place your choice by ID number (000 to finish): ");
                if (!int.TryParse(Console.ReadLine(), out idChoosed))
                {
                    Console.WriteLine("Invalid Enter. Please, type other number of ID.");
                    continue;
                }
                if (idChoosed == 0)
                {
                    break;
                }

                Data itemPicked;

                if (catalog.TryGetValue(idChoosed, out itemPicked))
                {
                    listOrder.Add(itemPicked);
                    Console.WriteLine($"Item {itemPicked.Name} add to the order!");
                }
                else
                {
                    Console.WriteLine($" Item with ID {idChoosed:000} not founded. Try again.");
                }
            }
            FinishOrder(listOrder);
        }
        private void FinishOrder(List<Data> order)
        {
            Console.WriteLine("\n*********************************");
            Console.WriteLine("        RESUME OF THE ORDER");
            Console.WriteLine("*********************************");

            if (order.Count == 0)
            {
                Console.WriteLine("Your order is empty!");
                return;
            }
            foreach (var item in order)
            {
                Console.WriteLine($"-> {item.Name,-15}: ${item.Value:N2}");
            }
            decimal total = order.Sum(item => (decimal)item.Value);

            Console.WriteLine("---------------------------------");
            Console.WriteLine($"TOTAL TO PAY:      ${total:N2}");
            Console.WriteLine("*********************************");
            Console.WriteLine("Thank you for yor preference!");
        }
        public class Data
        {
            public int Id { get; init; }
            public string Name { get; init; }
            public decimal Value { get; init; }

            public Data(int id, string name, decimal value)
            {
                Id = id;
                Name = name;
                Value = value;
            }
        }
    }
}
