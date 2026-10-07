using System;
using System.Collections.Generic;

namespace lab1
{
    public class GiModel
    {
        private readonly Dictionary<string, int> _database = new(StringComparer.OrdinalIgnoreCase) {
            { "Яблоко", 35 },
            { "Банан", 60 },
            { "Белый хлеб", 70 },
            { "Гречка", 40 }
        };

        public string LastProduct { get; private set; } = "";
        public int CurrentGi { get; private set; }

        public event Action OnDataChanged;
        public event Action<string> OnError;

        public void SearchProduct(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                OnError?.Invoke("Название продукта не может быть пустым!");
                return;
            }

            string cleanName = name.Trim();
            if (_database.TryGetValue(cleanName, out int gi))
            {
                LastProduct = cleanName;
                CurrentGi = gi;
                OnDataChanged?.Invoke();
            }
            else
            {
                OnError?.Invoke($"Продукт \"{cleanName}\" не найден в базе.");
            }
        }
    }
}