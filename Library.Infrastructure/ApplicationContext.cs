using Library.Application.Abstractions;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure;
public class ApplicationContext: IdentityDbContext<User>, IApplicationContext 
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        :base(options)
    { }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(b =>
        {
            b.HasKey(b => b.Id);
            b.HasIndex(b => b.ISBN).IsUnique();
            b.Property(b => b.ISBN).HasMaxLength(17).IsRequired();
            b.Property(b => b.Description).IsRequired();
            b.Property(b => b.Author).IsRequired();
            b.Property(b => b.Title).HasMaxLength(100).IsRequired();
            b.Property(b => b.Title).HasMaxLength(100).IsRequired();
        });
    }
}
