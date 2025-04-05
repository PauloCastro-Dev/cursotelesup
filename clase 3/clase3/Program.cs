namespace Repaso_Week1_Bootcamp_Csharp;

internal class Program
{
    static void Main(string[] args)
    {
        /*int dni = 2233333;
        int edad = 8;
        double numeroDecimal = 10.00;
        char caracter = '1';
        bool esMayordeEdad = true;
        string nombre = "Andre"; 

        if (dni != 2233333 || !esMayordeEdad)
        {
            Console.WriteLine("No es mi numero de dni");
            if (esMayordeEdad)
            {
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("Si es mi numero de dni");
        }


        Console.WriteLine("=============================");
        Console.WriteLine("Dias de la semana");
        String diaSemana = "Lunes";

        switch (diaSemana)
        {
            case "Lunes":
                Console.WriteLine("El dia es lunes");
                break;
            case "Martes":
                Console.WriteLine("El dia es martes");
                break;
            default:
                Console.WriteLine("No es un dia de la semana");
                break;
        }

        Console.WriteLine("Saliendo de la aplicacion");


        int numeroAComprobar;
        Console.WriteLine("");
        Console.WriteLine("============================");
        Console.WriteLine("Ingresa el valor a comprobar: ");
        Console.WriteLine("============================");
        numeroAComprobar = Convert.ToInt32(Console.ReadLine());

        if (numeroAComprobar % 2 == 0)
        {
            Console.WriteLine("El numero es par");
        }
        else
        {
            Console.WriteLine("El numero es impar");
        }*/

        int primerNumero;
        int segundoNumero;
        int tercerNumero;
        Console.WriteLine("");
        Console.WriteLine("============================");
        Console.WriteLine("Cual es el numero mayor de 3 numeros ");
        Console.WriteLine("============================");
        primerNumero = Convert.ToInt32(Console.ReadLine());
        segundoNumero = Convert.ToInt32(Console.ReadLine());
        tercerNumero = Convert.ToInt32(Console.ReadLine());

        string mayorNumeroString = "Primer";
        int mayorNumero = primerNumero;

        if (segundoNumero > mayorNumero)
        {
            mayorNumeroString = "Segundo";
            mayorNumero = segundoNumero;
        }

        if (tercerNumero > mayorNumero)
        {
            mayorNumeroString = "Tercer";
            mayorNumero = tercerNumero;
        }

        Console.WriteLine($"El numero mayor es el {mayorNumeroString} numero: {mayorNumero}");

        // Escribir la logica del programa

        Console.WriteLine("============================");
        Console.WriteLine("Dame la opcion de que area es para comprobar (circulo/cuadrado): ");
        Console.WriteLine("============================");
        string opcion = Console.ReadLine().ToLower();

        switch (opcion)
        {
            case "circulo":
                Console.WriteLine("Ingresa el radio del circulo: ");
                double radio = Convert.ToDouble(Console.ReadLine());
                double areaCirculo = Math.PI * Math.Pow(radio, 2);
                Console.WriteLine("El area del circulo es: " + areaCirculo);
                break;

            case "cuadrado":
                Console.WriteLine("Ingresa el largo del cuadrado: ");
                double largo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingresa el ancho del cuadrado: ");
                double ancho = Convert.ToDouble(Console.ReadLine());
                double areaCuadrado = largo * ancho;
                Console.WriteLine("El area del cuadrado es: " + areaCuadrado);
                break;

            default:
                Console.WriteLine("Opcion no valida");
                break;
        }


    }
}