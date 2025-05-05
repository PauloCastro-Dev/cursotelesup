using clase_13.Models;
using clase_13.Models.Enums;
using clase_13.Services;

namespace clase_13.Ui;

// Single Responsibility Principle: Esta clase se encarga únicamente de la interacción con el usuario.
// Open/Closed Principle: Puede extenderse para agregar más opciones de menú sin modificar el código existente.
public class Menu
{
	private readonly BookService _bookService;

	public Menu(BookService bookService)
	{
		_bookService = bookService;
	}

	public void Show()
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("Sistema de Librería");
			Console.WriteLine("1. Listar libros");
			Console.WriteLine("2. Agregar libro");
			Console.WriteLine("3. Editar libro");
			Console.WriteLine("4. Eliminar libro");
			Console.WriteLine("5. Salir");
			Console.Write("Seleccione una opción: ");

			var option = Console.ReadLine();

			switch (option)
			{
				case "1":
					ListBooks();
					break;
				case "2":
					AddBook();
					break;
				case "3":
					EditBook();
					break;
				case "4":
					DeleteBook();
					break;
				case "5":
					return;
				default:
					Console.WriteLine("Opción no válida.");
					break;
			}
		}
	}

	private void ListBooks()
	{
		var books = _bookService.GetAllBooks();
		Console.WriteLine("\nLista de libros:");
		foreach (var book in books)
		{
			Console.WriteLine($"ID: {book.Id}, Título: {book.Title}, Autor: {book.Author}, Género: {book.Genre}, Año: {book.Year}");
		}
		Console.WriteLine("\nPresione cualquier tecla para continuar...");
		Console.ReadKey();
	}

	private void AddBook()
	{
		Console.Write("Ingrese el título: ");
		string? title = Console.ReadLine() ?? string.Empty;
		if (string.IsNullOrEmpty(title))
		{
			Console.WriteLine("El título no puede estar vacío.");
			return;
		}
		Console.Write("Ingrese el autor: ");
		string? author = Console.ReadLine() ?? string.Empty;
		if (string.IsNullOrEmpty(author))
		{
			Console.WriteLine("El autor no puede estar vacío.");
			return;
		}
		Console.Write("Ingrese el género (Fiction, NonFiction, Mystery, Fantasy, Biography, Science): ");
		BookGenre genre = Enum.Parse<BookGenre>(Console.ReadLine() ?? "Fiction");
		Console.Write("Ingrese el año: ");
		int year = int.Parse(Console.ReadLine() ?? "0");

		Book? book = new() { Title = title, Author = author, Genre = genre, Year = year };
		_bookService.AddBook(book);
		Console.WriteLine("Libro agregado exitosamente.");
		Console.WriteLine("\nPresione cualquier tecla para continuar...");
		Console.ReadKey();
	}

	private void EditBook()
	{
		Console.Write("Ingrese el ID del libro a editar: ");
		int id = int.Parse(Console.ReadLine() ?? "0");
		Book? book = _bookService.GetBookById(id);
		if (book == null)
		{
			Console.WriteLine("Libro no encontrado.");
			Console.ReadKey();
			return;
		}

		Console.Write("Ingrese el nuevo título: ");
		book.Title = Console.ReadLine() ?? string.Empty;
		if (string.IsNullOrEmpty(book.Title))
		{
			Console.WriteLine("El título no puede estar vacío.");
			return;
		}
		Console.Write("Ingrese el nuevo autor: ");
		book.Author = Console.ReadLine() ?? string.Empty;
		if (string.IsNullOrEmpty(book.Author))
		{
			Console.WriteLine("El autor no puede estar vacío.");
			return;
		}
		Console.Write("Ingrese el nuevo género (Fiction, NonFiction, Mystery, Fantasy, Biography, Science): ");
		book.Genre = Enum.Parse<BookGenre>(Console.ReadLine() ?? "Fiction");
		Console.Write("Ingrese el nuevo año: ");
		book.Year = int.Parse(Console.ReadLine() ?? "0");

		_bookService.UpdateBook(book);
		Console.WriteLine("Libro actualizado exitosamente.");
		Console.WriteLine("\nPresione cualquier tecla para continuar...");
		Console.ReadKey();
	}

	private void DeleteBook()
	{
		Console.Write("Ingrese el ID del libro a eliminar: ");
		int id = int.Parse(Console.ReadLine() ?? "0");
		_bookService.DeleteBook(id);
		Console.WriteLine("Libro eliminado exitosamente.");
		Console.WriteLine("\nPresione cualquier tecla para continuar...");
		Console.ReadKey();
	}
}