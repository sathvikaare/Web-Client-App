using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        public void AddBook()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    //Console.WriteLine("enetr Book Id");
                    //int BookId = Convert.ToInt32(Console.ReadLine());
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
        public void RemoveBook(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
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
        public void GetBooksWithAuthor()
        {
            try
            {

                using (var context = new AppDbContext())
                {
                    var bookobj = context.Books.Include(a=>a.Author).ToList();
                    if (bookobj != null)
                    {
                        Console.WriteLine(bookobj);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}
