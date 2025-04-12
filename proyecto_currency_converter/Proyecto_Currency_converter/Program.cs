using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		// Array de monedas y sus tasas de cambio (1 unidad de la moneda base a otra moneda)
		string[] currencies = { "USD", "EUR", "PEN" };
		double[] exchangeRates = { 1.0, 0.91, 3.75 }; // USD -> USD, USD -> EUR, USD -> PEN

		while (true)
		{
			Console.WriteLine("=== Currency Converter ===");
			Console.WriteLine("1. Ver tasas de cambio");
			Console.WriteLine("2. Convertir moneda");
			Console.WriteLine("3. Salir");
			Console.Write("Seleccione una opción: ");

			string option = Console.ReadLine() ?? string.Empty;

			if (option == "1")
			{
				ShowExchangeRates(currencies, exchangeRates);
			}
			else if (option == "2")
			{
				ConvertCurrency(currencies, exchangeRates);
			}
			else if (option == "3")
			{
				Console.WriteLine("Saliendo del programa...");
				break;
			}
			else
			{
				Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
				Console.ReadKey();
			}
		}
	}

	static void ShowExchangeRates(string[] currencies, double[] exchangeRates)
	{
		Console.Clear();
		Console.WriteLine("=== Tasas de Cambio ===");
		for (int i = 0; i < currencies.Length; i++)
		{
			Console.WriteLine($"1 USD = {exchangeRates[i]} {currencies[i]}");
		}
		Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
		Console.ReadKey();
	}

	static void ConvertCurrency(string[] currencies, double[] exchangeRates)
	{
		Console.Clear();
		Console.WriteLine("=== Convertir Moneda ===");

		Console.WriteLine("Seleccione la moneda de destino:");
		for (int i = 0; i < currencies.Length; i++)
		{
			Console.WriteLine($"{i + 1}. {currencies[i]}");
		}

		Console.Write("Ingrese el número de la moneda: ");
		if (int.TryParse(Console.ReadLine(), out int currencyIndex) && currencyIndex >= 1 && currencyIndex <= currencies.Length)
		{
			Console.Write("Ingrese la cantidad en USD: ");
			if (double.TryParse(Console.ReadLine(), out double amountInUSD))
			{
				double convertedAmount = amountInUSD * exchangeRates[currencyIndex - 1];
				Console.WriteLine($"{amountInUSD} USD = {convertedAmount} {currencies[currencyIndex - 1]}");
			}
			else
			{
				Console.WriteLine("Cantidad no válida.");
			}
		}
		else
		{
			Console.WriteLine("Selección de moneda no válida.");
		}

		Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
		Console.ReadKey();
	}
}