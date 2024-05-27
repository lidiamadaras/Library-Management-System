using Microsoft.EntityFrameworkCore;
using mentorp;

public class BookContext : DbContext
{
    // public BookContext(DbContextOptions<BookContext> options) : base(options)
    // {

    // }
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }

    public DbSet<People> Peoples {get; set;}

    public DbSet<Library> Libraries {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Library>()
        .HasMany(l => l.Books)
        .WithOne()
        .HasForeignKey(b => b.LibraryId);
    }
        
}

