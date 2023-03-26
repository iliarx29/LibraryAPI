using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Abstractions;
public interface IApplicationContext
{
    DbSet<Book> Books { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
