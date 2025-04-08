class Program
{
    static void Main(string[] args)
    {
        int[] calificaciones = new int[10];
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("=== Menú ===");
            Console.WriteLine("1. Ingresar calificaciones");
            Console.WriteLine("2. Calcular promedio");
            Console.WriteLine("3. Encontrar calificación más alta");
            Console.WriteLine("4. Encontrar calificación más baja");
            Console.WriteLine("5. Contar estudiantes aprobados");
            Console.WriteLine("6. Mostrar calificaciones en orden ascendente");
            Console.WriteLine("7. Mostrar distribución de calificaciones por rango");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    IngresarCalificaciones(calificaciones);
                    break;
                case "2":
                    Console.WriteLine($"El promedio de las calificaciones es: {CalcularPromedio(calificaciones):F2}\n");
                    break;
                case "3":
                    Console.WriteLine($"La calificación más alta es: {EncontrarCalificacionMasAlta(calificaciones)}\n");
                    break;
                case "4":
                    Console.WriteLine($"La calificación más baja es: {EncontrarCalificacionMasBaja(calificaciones)}\n");
                    break;
                case "5":
                    Console.WriteLine($"El número de estudiantes aprobados es: {ContarAprobados(calificaciones)}\n");
                    break;
                case "6":
                    MostrarCalificacionesOrdenadas(calificaciones);
                    break;
                case "7":
                    MostrarDistribucionPorRango(calificaciones);
                    break;
                case "8":
                    salir = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                    break;
            }
        }
    }

    static void IngresarCalificaciones(int[] calificaciones)
    {
        for (int i = 0; i < calificaciones.Length; i++)
        {
            Console.Write($"Ingrese la calificación del estudiante {i + 1} (0-100): ");
            while (!int.TryParse(Console.ReadLine(), out calificaciones[i]) || calificaciones[i] < 0 || calificaciones[i] > 100)
            {
                Console.Write("Entrada inválida. Ingrese un número entre 0 y 100: ");
            }
        }
        Console.WriteLine("Calificaciones ingresadas correctamente.\n");
    }

    static double CalcularPromedio(int[] calificaciones)
    {
        return calificaciones.Average();
    }

    static int EncontrarCalificacionMasAlta(int[] calificaciones)
    {
        return calificaciones.Max();
    }

    static int EncontrarCalificacionMasBaja(int[] calificaciones)
    {
        return calificaciones.Min();
    }

    static int ContarAprobados(int[] calificaciones)
    {
        return calificaciones.Count(c => c >= 60);
    }

    static void MostrarCalificacionesOrdenadas(int[] calificaciones)
    {
        var ordenadas = calificaciones.OrderBy(c => c).ToArray();
        Console.WriteLine("Calificaciones en orden ascendente:");
        foreach (var calificacion in ordenadas)
        {
            Console.WriteLine(calificacion);
        }
        Console.WriteLine();
    }

    static void MostrarDistribucionPorRango(int[] calificaciones)
    {
        int reprobado = calificaciones.Count(c => c >= 0 && c <= 59);
        int suficiente = calificaciones.Count(c => c >= 60 && c <= 69);
        int bien = calificaciones.Count(c => c >= 70 && c <= 79);
        int notable = calificaciones.Count(c => c >= 80 && c <= 89);
        int excelente = calificaciones.Count(c => c >= 90 && c <= 100);

        Console.WriteLine("Distribución de calificaciones por rango:");
        Console.WriteLine($"0-59 (Reprobado): {reprobado}");
        Console.WriteLine($"60-69 (Suficiente): {suficiente}");
        Console.WriteLine($"70-79 (Bien): {bien}");
        Console.WriteLine($"80-89 (Notable): {notable}");
        Console.WriteLine($"90-100 (Excelente): {excelente}\n");
    }
}
