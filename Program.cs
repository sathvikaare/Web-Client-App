// See https://aka.ms/new-console-template for more information
using LibraryManagementSystem.Services;

Console.WriteLine("Hello, World!");
//string name=Console.ReadLine();
//string email=Console.ReadLine();
//var author = new AuthorService();
//author.AddAuthor();
var book=new BookService();
//book.AddBook();
int id=Convert.ToInt32(Console.ReadLine());
book.RemoveBook(id);