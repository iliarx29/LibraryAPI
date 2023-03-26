using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBooks;
public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
{
    private readonly IApplicationContext _context;

    public GetBooksQueryHandler(IApplicationContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Book>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        var books = await _context.Books.AsNoTracking().ToListAsync(cancellationToken);

        if (books is null)
            throw new ArgumentNullException(nameof(books), "Books is null");

        return books;
    }
}
