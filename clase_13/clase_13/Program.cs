using clase_13.Repositories;
using clase_13.Services;
using clase_13.Ui;
using clase_13.Utils;

BookRepository? bookRepository = new();
DataLoader.LoadInitialData(bookRepository);
BookService? bookService = new(bookRepository);
Menu? menu = new(bookService);
menu.Show();
