using clase_13.Models;
using clase_13.Models.Interfaces;

namespace clase_13.Services;

// Single Responsibility Principle: Esta clase se encarga únicamente de la lógica de negocio relacionada con los libros.
// Dependency Inversion Principle: Depende de la abstracción IRepository en lugar de una implementación concreta.
// Open/Closed Principle: Puede extenderse para agregar más lógica de negocio sin modificar su código existente.
public class BookService
{
	private readonly IRepository<Book> _repository;

	public BookService(IRepository<Book> repository)
	{
		_repository = repository;
	}

	public IEnumerable<Book> GetAllBooks() => _repository.GetAll();

	public Book? GetBookById(int id) => _repository.GetById(id);

	public void AddBook(Book book) => _repository.Add(book);

	public void UpdateBook(Book book) => _repository.Update(book);

	public void DeleteBook(int id) => _repository.Delete(id);
}