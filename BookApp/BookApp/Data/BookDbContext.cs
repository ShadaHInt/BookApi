using BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data
{
    public class BookDbContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>()
                .HasKey(x=>x.BookId);
            modelBuilder.Entity<BookModel>()
                .Property(x=>x.BookName);
            modelBuilder.Entity<BookModel>()
                .Property(x=>x.AuthorName);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BookList");
        }
    }
}
