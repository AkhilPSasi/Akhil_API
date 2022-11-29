using Microsoft.EntityFrameworkCore;

namespace Akhil_API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Category 1" },
                    new Category { Id = 2, Name = "Category 2" },
                    new Category { Id = 3, Name = "Category 3" },
                    new Category { Id = 4, Name = "Category 4" },
                    new Category { Id = 5, Name = "Category 5" }
                    );

            modelBuilder.Entity<Product>()
                .HasData(

                new Product { Id = 1, Name = "Product 1", Description = "Product 1", IsAvailable = true, Price = 1, CategoyId = 1 },
                new Product { Id = 2, Name = "Product 2", Description = "Product 2", IsAvailable = false, Price = 2, CategoyId = 1 },
                new Product { Id = 3, Name = "Product 3", Description = "Product 3", IsAvailable = true, Price = 3, CategoyId = 1 },
                new Product { Id = 4, Name = "Product 4", Description = "Product 4", IsAvailable = false, Price = 4, CategoyId = 1 },
                new Product { Id = 5, Name = "Product 5", Description = "Product 5", IsAvailable = true, Price = 5, CategoyId = 1 },
                new Product { Id = 6, Name = "Product 6", Description = "Product 6", IsAvailable = false, Price = 6, CategoyId = 1 },
                new Product { Id = 7, Name = "Product 7", Description = "Product 7", IsAvailable = true, Price = 7, CategoyId = 1 },
                new Product { Id = 8, Name = "Product 8", Description = "Product 8", IsAvailable = false, Price = 8, CategoyId = 1 },
                new Product { Id = 9, Name = "Product 9", Description = "Product 9", IsAvailable = true, Price = 9, CategoyId = 1 },
                new Product { Id = 10, Name = "Product 10", Description = "Product 10", IsAvailable = false, Price = 10, CategoyId = 1 },

                new Product { Id = 11, Name = "Product 11", Description = "Product 11", IsAvailable = true, Price = 11, CategoyId = 2 },
                new Product { Id = 12, Name = "Product 12", Description = "Product 12", IsAvailable = false, Price = 12, CategoyId = 2 },
                new Product { Id = 13, Name = "Product 13", Description = "Product 13", IsAvailable = true, Price = 13, CategoyId = 2 },
                new Product { Id = 14, Name = "Product 14", Description = "Product 14", IsAvailable = false, Price = 14, CategoyId = 2 },
                new Product { Id = 15, Name = "Product 15", Description = "Product 15", IsAvailable = true, Price = 15, CategoyId = 2 },
                new Product { Id = 16, Name = "Product 16", Description = "Product 16", IsAvailable = false, Price = 16, CategoyId = 2 },
                new Product { Id = 17, Name = "Product 17", Description = "Product 17", IsAvailable = true, Price = 17, CategoyId = 2 },
                new Product { Id = 18, Name = "Product 18", Description = "Product 18", IsAvailable = false, Price = 18, CategoyId = 2 },
                new Product { Id = 19, Name = "Product 19", Description = "Product 19", IsAvailable = true, Price = 19, CategoyId = 2 },
                new Product { Id = 20, Name = "Product 20", Description = "Product 20", IsAvailable = false, Price = 20, CategoyId = 2 },

                new Product { Id = 21, Name = "Product 21", Description = "Product 21", IsAvailable = true, Price = 21, CategoyId = 3 },
                new Product { Id = 22, Name = "Product 22", Description = "Product 22", IsAvailable = false, Price = 22, CategoyId = 3 },
                new Product { Id = 23, Name = "Product 23", Description = "Product 23", IsAvailable = true, Price = 23, CategoyId = 3 },
                new Product { Id = 24, Name = "Product 24", Description = "Product 24", IsAvailable = false, Price = 24, CategoyId = 3 },
                new Product { Id = 25, Name = "Product 25", Description = "Product 25", IsAvailable = true, Price = 25, CategoyId = 3 },
                new Product { Id = 26, Name = "Product 26", Description = "Product 26", IsAvailable = false, Price = 26, CategoyId = 3 },
                new Product { Id = 27, Name = "Product 27", Description = "Product 27", IsAvailable = true, Price = 27, CategoyId = 3 },
                new Product { Id = 28, Name = "Product 28", Description = "Product 28", IsAvailable = false, Price = 28, CategoyId = 3 },
                new Product { Id = 29, Name = "Product 29", Description = "Product 29", IsAvailable = true, Price = 29, CategoyId = 3 },
                new Product { Id = 30, Name = "Product 30", Description = "Product 30", IsAvailable = false, Price = 30, CategoyId = 3 },

                new Product { Id = 31, Name = "Product 31", Description = "Product 31", IsAvailable = true, Price = 31, CategoyId = 4 },
                new Product { Id = 32, Name = "Product 32", Description = "Product 32", IsAvailable = false, Price = 32, CategoyId = 4 },
                new Product { Id = 33, Name = "Product 33", Description = "Product 33", IsAvailable = true, Price = 33, CategoyId = 4 },
                new Product { Id = 34, Name = "Product 34", Description = "Product 34", IsAvailable = false, Price = 34, CategoyId = 4 },
                new Product { Id = 35, Name = "Product 35", Description = "Product 35", IsAvailable = true, Price = 35, CategoyId = 4 },
                new Product { Id = 36, Name = "Product 36", Description = "Product 36", IsAvailable = false, Price = 36, CategoyId = 4 },
                new Product { Id = 37, Name = "Product 37", Description = "Product 37", IsAvailable = true, Price = 37, CategoyId = 4 },
                new Product { Id = 38, Name = "Product 38", Description = "Product 38", IsAvailable = false, Price = 38, CategoyId = 4 },
                new Product { Id = 39, Name = "Product 39", Description = "Product 39", IsAvailable = true, Price = 39, CategoyId = 4 },
                new Product { Id = 40, Name = "Product 40", Description = "Product 40", IsAvailable = false, Price = 40, CategoyId = 4 },

                new Product { Id = 41, Name = "Product 41", Description = "Product 41", IsAvailable = true, Price = 41, CategoyId = 5 },
                new Product { Id = 42, Name = "Product 42", Description = "Product 42", IsAvailable = false, Price = 42, CategoyId = 5 },
                new Product { Id = 43, Name = "Product 43", Description = "Product 43", IsAvailable = true, Price = 43, CategoyId = 5 },
                new Product { Id = 44, Name = "Product 44", Description = "Product 44", IsAvailable = false, Price = 44, CategoyId = 5 },
                new Product { Id = 45, Name = "Product 45", Description = "Product 45", IsAvailable = true, Price = 45, CategoyId = 5 },
                new Product { Id = 46, Name = "Product 46", Description = "Product 46", IsAvailable = false, Price = 46, CategoyId = 5 },
                new Product { Id = 47, Name = "Product 47", Description = "Product 47", IsAvailable = true, Price = 47, CategoyId = 5 },
                new Product { Id = 48, Name = "Product 48", Description = "Product 48", IsAvailable = false, Price = 48, CategoyId = 5 },
                new Product { Id = 49, Name = "Product 49", Description = "Product 49", IsAvailable = true, Price = 49, CategoyId = 5 },
                new Product { Id = 50, Name = "Product 50", Description = "Product 50", IsAvailable = false, Price = 50, CategoyId = 5 }
                );
        }
    }
}
