using LibraryManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class AuthorService
    {
        public void AddAuthor()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    Console.WriteLine("enetr author Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("enetr author Email Id");
                    string email = Console.ReadLine();
                    context.Authors.Add(new Models.Author { Name = name, Email = email});
                    context.SaveChanges();
                    Console.WriteLine("Author inserted Successfully");
                }
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
