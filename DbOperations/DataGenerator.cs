using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace WebApiNet.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Books.AddRange(
                     new Book {
                        //Id = 1,
                        Title = "Mucize Sabah",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book {
                        //Id = 2,
                        Title = "Kürk Mantolu Madonna",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2021, 02, 10)
                    },
                    new Book {
                        //Id = 3,
                        Title = "What Men Live By",
                        GenreId = 2,
                        PageCount = 96,
                        PublishDate = new DateTime(2020, 01, 01)
                    }
                );

                context.SaveChanges();
            }
        }

   
    }
}