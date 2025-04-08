class Program
{
    static void Main(string[] args)
    {
        // Crear una lista de libros
        List<Libro> libros = new List<Libro>
        {
            new Libro { Nombre = "El principito", Precio = 15.99, Stock = 20 },
            new Libro { Nombre = "Cien años de soledad", Precio = 25.50, Stock = 5 },
            new Libro { Nombre = "El alquimista", Precio = 18.75, Stock = 12 },
            new Libro { Nombre = "Don Quijote de la Mancha", Precio = 30.00, Stock = 8 },
            new Libro { Nombre = "La sombra del viento", Precio = 10.50, Stock = 15 }
        };

        // Filtrar libros con stock mayor a 10
        var librosConStockMayorA10 = FiltrarPorStock(libros, 10);
        Console.WriteLine("Libros con stock mayor a 10:");
        foreach (var libro in librosConStockMayorA10)
        {
            Console.WriteLine($"- {libro.Nombre} (Stock: {libro.Stock})");
        }

        // Filtrar libros con precio mayor a 10.99
        var librosConPrecioMayorA10_99 = FiltrarPorPrecio(libros, 10.99);
        Console.WriteLine("\nLibros con precio mayor a 10.99:");
        foreach (var libro in librosConPrecioMayorA10_99)
        {
            Console.WriteLine($"- {libro.Nombre} (Precio: {libro.Precio} soles)");
        }

        // Encontrar el índice del libro que empieza con "El"
        int indiceLibroConEl = EncontrarIndicePorNombre(libros, "El");
        if (indiceLibroConEl != -1)
        {
            Console.WriteLine($"\nEl índice del primer libro que empieza con 'El' es: {indiceLibroConEl}");
        }
        else
        {
            Console.WriteLine("\nNo se encontró un libro que empiece con 'El'.");
        }
    }

    static List<Libro> FiltrarPorStock(List<Libro> libros, int stockMinimo)
    {
        return libros.Where(libro => libro.Stock > stockMinimo).ToList();
    }

    static List<Libro> FiltrarPorPrecio(List<Libro> libros, double precioMinimo)
    {
        return libros.Where(libro => libro.Precio > precioMinimo).ToList();
    }

    static int EncontrarIndicePorNombre(List<Libro> libros, string palabraInicial)
    {
        return libros.FindIndex(libro => libro.Nombre.StartsWith(palabraInicial));
    }
}
class Libro
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
}