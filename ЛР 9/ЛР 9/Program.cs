using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_9
{
	public class Money
	{
		private int first; // Номинал купюры
		private int second; // Количество купюр

		// Конструктор для создания экземпляра класса с заданными значениями полей
		public Money(int nominal, int count)
		{
			first = nominal;
			second = count;
		}

		// Свойство для чтения и установки значений полей
		public int Nominal
		{
			get { return first; }
			set { first = value; }
		}

		public int Count
		{
			get { return second; }
			set { second = value; }
		}

		// Свойство для расчета суммы денег
		public int TotalValue
		{
			get { return first * second; }
		}

		// Метод для вывода номинала и количества купюр
		public void Display()
		{
			Console.WriteLine($"Номинал: {first} рублей, Количество купюр: {second}");
		}

		// Метод для определения, хватит ли денег на покупку товара на сумму N рублей
		public bool CanPurchase(int price)
		{
			return TotalValue >= price;
		}

		// Метод для определения, сколько товара стоимости n рублей можно купить
		public int CalculatePurchaseCount(int price)
		{
			return TotalValue / price;
		}

		// Индексатор
		public int this[int index]
		{
			get
			{
				if (index == 0) return first;
				else if (index == 1) return second;
				else throw new IndexOutOfRangeException("Недопустимый индекс.");
			}
		}

		// Перегрузка операторов
		public static Money operator ++(Money banknote)
		{
			banknote.first++;
			banknote.second++;
			return banknote;
		}

		public static Money operator --(Money banknote)
		{
			if (banknote.first > 0 && banknote.second > 0)
			{
				banknote.first--;
				banknote.second--;
			}
			return banknote;
		}

		public static bool operator !(Money banknote)
		{
			return banknote.second != 0;
		}

		public static Money operator +(Money banknote, int value)
		{
			banknote.second += value;
			return banknote;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			// Создаем экземпляр класса Money
			Money banknote = new Money(100, 5);

			// Выводим номинал и количество купюр
			banknote.Display();

			// Рассчитываем сумму денег
			Console.WriteLine($"Сумма: {banknote.TotalValue} рублей");

			// Проверяем, хватит ли денег на покупку товара на 300 рублей
			int price = 300;
			bool canPurchase = banknote.CanPurchase(price);
			Console.WriteLine($"Достаточно средств для покупки товара на {price} рублей: {canPurchase}");

			// Рассчитываем, сколько товара стоимости 50 рублей можно купить
			int itemPrice = 50;
			int purchaseCount = banknote.CalculatePurchaseCount(itemPrice);
			Console.WriteLine($"Можно купить {purchaseCount} товаров по {itemPrice} рублей");

			// Используем индексаторы
			Console.WriteLine($"Номинал купюры: {banknote[0]} рублей");
			Console.WriteLine($"Количество купюр: {banknote[1]}");

			// Перегрузка операторов
			banknote++;
			Console.WriteLine($"После увеличения номинала и количества купюр:");
			banknote.Display();

			banknote--;
			Console.WriteLine($"После уменьшения номинала и количества купюр:");
			banknote.Display();

			bool hasMoney = !banknote;
			Console.WriteLine($"Есть ли деньги: {hasMoney}");

			banknote += 3;
			Console.WriteLine($"После добавления 3 купюр:");
			banknote.Display();
		}
	}
}
