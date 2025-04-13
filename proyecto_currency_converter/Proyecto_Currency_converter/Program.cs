using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		// Array de monedas y sus tasas de cambio (1 unidad de la moneda base a otra moneda)
		List<string> currencies = ["USD", "EUR", "PEN"];
		List<double> exchangeRates = [1.0, 0.91, 3.75]; // USD -> USD, USD -> EUR, USD -> PEN

		while (true)
		{
			Console.WriteLine("=== Currency Converter ===");
			Console.WriteLine("1. Ver tasas de cambio");
			Console.WriteLine("2. Convertir moneda");
			Console.WriteLine("3. Agregar Moneda");
			Console.WriteLine("4. Actualizar Moneda");
			Console.WriteLine("5. Eliminar Moneda");
			Console.WriteLine("6. Actualizar tasa de cambio");
			Console.WriteLine("7. Buscar por moneda");
			Console.WriteLine("8. Buscar por tasa de cambio");
			Console.WriteLine("9. Salir");
			Console.Write("Seleccione una opción: ");

			string option = Console.ReadLine() ?? string.Empty;

			switch (option)
			{
				case "1":
					ShowExchangeRates(currencies, exchangeRates);
					break;
				case "2":
					ConvertCurrency(currencies, exchangeRates);
					break;
				case "3":
					AddCurrency(currencies, exchangeRates);
					break;
				case "4":
					UpdateCurrency(currencies, exchangeRates);
					break;
				case "5":
					RemoveCurrency(currencies, exchangeRates);
					break;
				case "6":
					UpdateExchangeRate(exchangeRates);
					break;
				case "7":
					SearchByCurrency(currencies, exchangeRates);
					break;
				case "8":
					SearchByExchangeRate(currencies, exchangeRates);
					break;
				case "9":
					Console.WriteLine("Saliendo del programa...");
					break;
				default:
					Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
					Console.ReadKey();
					break;
			}
		}
	}

	static void ShowExchangeRates(List<string> currencies, List<double> exchangeRates)
	{
		Console.Clear();
		Console.WriteLine("=== Tasas de Cambio ===");
		for (int i = 0; i < currencies.Count; i++)
		{
			Console.WriteLine($"1 USD = {exchangeRates[i]} {currencies[i]}");
		}
		Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
		Console.ReadKey();
	}

	static void ConvertCurrency(List<string> currencies, List<double> exchangeRates)
	{
		Console.Clear();
		Console.WriteLine("=== Convertir Moneda ===");

		Console.WriteLine("Seleccione la moneda de destino:");
		for (int i = 0; i < currencies.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {currencies[i]}");
		}

		Console.Write("Ingrese el número de la moneda: ");
		if (int.TryParse(Console.ReadLine(), out int currencyIndex) && currencyIndex >= 1 && currencyIndex <= currencies.Count)
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

	static void AddCurrency(List<string> currencies, List<double> exchangeRates)
	{
		Console.Clear();
		Console.WriteLine("=== Agregar Moneda ===");
		Console.Write("Ingrese el código de la nueva moneda: ");
		string nuevaMoneda = Console.ReadLine() ?? string.Empty;
		if (String.IsNullOrWhiteSpace(nuevaMoneda))
		{
			Console.WriteLine("El código de la moneda no puede estar vacío.");
			return;
		}
		Console.Write("Ingrese el nuevo tipo de cambio:");
		double nuevaTasaCambio = double.TryParse(Console.ReadLine(), out double tasaCambio) ? tasaCambio : 0.0;
		if (tasaCambio < 0.0)
		{
			Console.WriteLine("La tasa de cambio no puede ser negativa.");
			return;
		}
		currencies.Add(nuevaMoneda);
		exchangeRates.Add(nuevaTasaCambio);
		Console.WriteLine("Nueva moneda agregada.");
		Console.WriteLine("Presione cualquier tecla para volver al menu principal");
		Console.ReadKey();

	}

	static void UpdateCurrency(List<string> currencies, List<double> exchangeRates)
	{
		Console.Clear();
		Console.WriteLine("=== Actualizar Tasa de Cambio ===");
		Console.WriteLine("Selecciona la moneda a actualizar");
		foreach (string currency in currencies)
		{
			Console.WriteLine(currency);
		}
		Console.WriteLine("Elija la moneda a actualizar");
		int index = int.TryParse(Console.ReadLine(), out int monedaElegida) ? monedaElegida - 1 : -1;
		if (index < 0 || index >= exchangeRates.Count)
		{
			Console.WriteLine("Selección de moneda no válida.");
			return;
		}
		Console.WriteLine("Ingrese el nuevo simbolo de la moneda");
		string simbolo = Console.ReadLine() ?? string.Empty;
		if (String.IsNullOrWhiteSpace(simbolo))
		{
			Console.WriteLine("El simbolo de la moneda no puede estar vacio.");
			return;
		}
		for (int i = 0; i < currencies.Count; i++)
		{
			if (i == index)
			{
				currencies[i] = simbolo;
				Console.WriteLine("Moneda actualizada");
				Console.WriteLine("Presione cualquier tecla para volver al menu principal");
				Console.ReadKey();
			}
		}
	}

	static void RemoveCurrency(List<string> currencies, List<double> exchangeRates)
	{
		Console.Clear();
		Console.WriteLine("=== Eliminar Moneda ===");
		Console.WriteLine("Seleccione la moneda a eliminar:");
		for (int i = 0; i < currencies.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {currencies[i]}");
		}
		Console.Write("Ingrese el número de la moneda: ");
		int index = int.TryParse(Console.ReadLine(), out int monedaElegida) ? monedaElegida - 1 : -1;
		if (index < 0 || index >= currencies.Count)
		{
			Console.WriteLine("Selección de moneda no válida.");
			return;
		}
		currencies.RemoveAt(index);
		exchangeRates.RemoveAt(index);
		Console.WriteLine("Moneda eliminada.");
		Console.WriteLine("Presione cualquier tecla para volver al menú principal ...");
		Console.ReadKey();
	}

	static void UpdateExchangeRate(List<double> exchangeRates){
		Console.Clear();
		Console.WriteLine("=== Actualizar Tasa de Cambio ===");
		Console.WriteLine("Seleccione la tasa de cambio a actualizar:");
		for (int i = 0; i < exchangeRates.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {exchangeRates[i]}");
		}
		Console.Write("Ingrese el nuevo valor: ");
		int index = int.TryParse(Console.ReadLine(), out int monedaElegida) ? monedaElegida - 1 : -1;
		if (index < 0 || index >= exchangeRates.Count)
		{
			Console.WriteLine("Selección de tasa de cambio no válida.");
			return;
		}
		Console.Write("Ingrese la nueva tasa de cambio: ");
		if (double.TryParse(Console.ReadLine(), out double nuevaTasaCambio))
		{
			exchangeRates[index] = nuevaTasaCambio;
			Console.WriteLine("Tasa de cambio actualizada.");
		}
		else
		{
			Console.WriteLine("Tasa de cambio no válida.");
		}
		Console.WriteLine("Presione cualquier tecla para volver al menú principal ...");
		Console.ReadKey();

	}

	static void SearchByCurrency(List<string> currencies,List<double> exchangeRates){
		Console.Clear();
		Console.WriteLine("=== Buscar por Moneda ===");
		Console.Write("Ingrese el simbolo de la moneda:");
		string simbolo = Console.ReadLine() ?? string.Empty;
		if(String.IsNullOrWhiteSpace(simbolo)){
			Console.WriteLine("El simbolo de la moneda no puede estar vacio.");
			return;
		}
		int indexMoneda = currencies.IndexOf(simbolo);
		if(indexMoneda < 0 || indexMoneda >= currencies.Count){
			Console.WriteLine("Moneda no encontrada.");
			return;
		}
		Console.WriteLine($"La tasa de cambio para {simbolo} es: {exchangeRates[indexMoneda]}");
		Console.WriteLine("Presione cualquier tecla para volver al menú principal ...");
		Console.ReadKey();
	}

	static void SearchByExchangeRate(List<string> currencies, List<double> exchangeRates){
		Console.Clear();
		Console.WriteLine("=== Buscar por Tasa de Cambio ===");
		Console.Write("Ingrese la tasa de cambio:");
		if (double.TryParse(Console.ReadLine(), out double tasaCambio))
		{
			int indexTasaCambio = exchangeRates.IndexOf(tasaCambio);
			if (indexTasaCambio < 0 || indexTasaCambio >= exchangeRates.Count)
			{
				Console.WriteLine("Tasa de cambio no encontrada.");
				return;
			}
			Console.WriteLine($"La moneda para la tasa de cambio {tasaCambio} es: {currencies[indexTasaCambio]}");
		}
		else
		{
			Console.WriteLine("Tasa de cambio no válida.");
		}
		Console.WriteLine("Presione cualquier tecla para volver al menú principal ...");
		Console.ReadKey();
	}
}