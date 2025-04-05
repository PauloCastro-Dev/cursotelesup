namespace AppCalculadora
{
    public class Calculadora
    {
        public void Iniciar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Calculadora en .NET 9.0");
                Console.WriteLine("Seleccione una operación:");
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicación");
                Console.WriteLine("4. División");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                string opcion = Console.ReadLine();

                if (opcion == "5")
                {
                    break;
                }

                Console.Write("Ingrese el primer número: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese el segundo número: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double resultado = 0;

                switch (opcion)
                {
                    case "1":
                        resultado = Sumar(num1, num2);
                        Console.WriteLine($"Resultado: {num1} + {num2} = {resultado}");
                        break;
                    case "2":
                        resultado = Restar(num1, num2);
                        Console.WriteLine($"Resultado: {num1} - {num2} = {resultado}");
                        break;
                    case "3":
                        resultado = Multiplicar(num1, num2);
                        Console.WriteLine($"Resultado: {num1} * {num2} = {resultado}");
                        break;
                    case "4":
                        if (num2 != 0)
                        {
                            resultado = Dividir(num1, num2);
                            Console.WriteLine($"Resultado: {num1} / {num2} = {resultado}");
                        }
                        else
                        {
                            Console.WriteLine("Error: División por cero no permitida.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private double Sumar(double a, double b)
        {
            return a + b;
        }

        private double Restar(double a, double b)
        {
            return a - b;
        }

        private double Multiplicar(double a, double b)
        {
            return a * b;
        }

        private double Dividir(double a, double b)
        {
            return a / b;
        }
    }

}
