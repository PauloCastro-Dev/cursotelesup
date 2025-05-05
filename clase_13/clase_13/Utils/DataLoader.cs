using clase_13.Models;
using clase_13.Models.Enums;
using clase_13.Repositories;

namespace clase_13.Utils;

public static class DataLoader
{
	public static void LoadInitialData(BookRepository repository)
	{
		repository.Add(new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = BookGenre.Fiction, Year = 1949 });
		repository.Add(new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = BookGenre.Fiction, Year = 1960 });
		repository.Add(new Book { Id = 3, Title = "A Brief History of Time", Author = "Stephen Hawking", Genre = BookGenre.Science, Year = 1988 });
	}
}