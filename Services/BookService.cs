using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        public void AddBook()//1. add book
        {
            try
            {
                using (var context = new AppDbContext())
                {

                    Console.WriteLine("enetr Book Title ");
                    string title = Console.ReadLine();
                    Console.WriteLine("enetr Book yearpublished");
                    int yearpublished = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enetr Book Author Id ");
                    int authorid = Convert.ToInt32(Console.ReadLine());
                    context.Books.Add(new Models.Book {Title = title ,YearPublished=yearpublished,AuthorId=authorid});
                    context.SaveChanges();
                    Console.WriteLine("Book inserted Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        //returns the book and current author
        public void GetBooksWithAuthor()
        {
            try
            {

                using (var context = new AppDbContext())
                {
                    var bookobj = context.Books.Include(a => a.Author).ToList();

                    foreach (var book in bookobj)
                    {
                        Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, YearPublished: {book.YearPublished}, AuthorName:{book.Author.Name}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //update book title
        public void UpdateBookbyTitle()
        {
            try
            {

                using (var context = new AppDbContext())
                {
                    Console.WriteLine("enter the id to change the title");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter the new title to change");
                    string title = Console.ReadLine();
                    var bookobj = context.Books.Find(id);
                    if (bookobj != null)
                    {
                        bookobj.Title = title;
                        context.SaveChanges();
                        Console.WriteLine("book title updated");
                    }
                    else
                    {
                        Console.WriteLine("book not found");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //remove book
        public void RemoveBook()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    Console.WriteLine("enter the book id to remove the book");
                    int id=Convert.ToInt32(Console.ReadLine());
                    var bookobj = context.Books.Find(id);
                    if (bookobj != null) {
                        context.Books.Remove(bookobj);
                        context.SaveChanges();
                    }
                }
            }
            catch(Exception ex) 
            {
                    Console.WriteLine($"{ex.Message}");
            }
        }

    }
}
