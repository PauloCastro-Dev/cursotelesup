using clase_13.Models.Enums;

namespace clase_13.Models;

public class Book
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Author { get; set; } = string.Empty;
	public BookGenre Genre { get; set; }
	public int Year { get; set; }
}