// See https://aka.ms/new-console-template for more information
using LibraryManagementSystem.Services;

Console.WriteLine("Hello, World!");
var author = new AuthorService();
var book=new BookService();

Console.WriteLine("Choose an option:");
Console.WriteLine("1. Add Author");
Console.WriteLine("2. Add Book");
Console.WriteLine("3. Get books with Author");
Console.WriteLine("4. Update Book");
Console.WriteLine("5.  Remove Book");
Console.Write("Enter your choice (1-5): ");
var choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            author.AddAuthor(); 
            break;
        case 2:
            book.AddBook();
            break;
        case 3:
            book.GetBooksWithAuthor();
            break;
        case 4:
            book.UpdateBookbyTitle();
            break;
        case 5:
            book.RemoveBook();
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }

Console.ReadKey();