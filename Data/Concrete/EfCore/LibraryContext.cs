using Entity;
using Microsoft.EntityFrameworkCore;

namespace kutuphane.Data.Concrete.EfCore
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            :base(options)
        {
            
        }    

        public DbSet<Author> Authors { get; set; }    
        public DbSet<Book> Books { get; set; }    
        public DbSet<Type> Types { get; set; }    
        public DbSet<ReadList> ReadList { get; set; }      
        public DbSet<User> Users { get; set; }    
        public DbSet<Language> Languages { get; set; }    
        public DbSet<Publisher> Publishers { get; set; }    

    }
}