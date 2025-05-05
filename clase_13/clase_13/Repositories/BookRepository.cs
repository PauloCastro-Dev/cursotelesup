using clase_13.Models;
using clase_13.Models.Interfaces;

namespace clase_13.Repositories;

// Single Responsibility Principle: Esta clase tiene una única responsabilidad, que es manejar las operaciones CRUD para los libros.
// Dependency Inversion Principle: Depende de la abstracción IRepository en lugar de una implementación concreta.
// Liskov Substitution Principle: Puede ser sustituida por cualquier otra implementación de IRepository<Book> sin alterar el comportamiento del sistema.
public class BookRepository : IRepository<Book>
{
	private readonly List<Book> _books = [];

	public IEnumerable<Book> GetAll() => _books;

	public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

	public void Add(Book book) => _books.Add(book);

	public void Update(Book book)
	{
		var existingBook = GetById(book.Id);
		if (existingBook != null)
		{
			existingBook.Title = book.Title;
			existingBook.Author = book.Author;
			existingBook.Genre = book.Genre;
			existingBook.Year = book.Year;
		}
	}

	public void Delete(int id) => _books.RemoveAll(b => b.Id == id);
}