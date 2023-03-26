using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookByISBN;
public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, Book>
{
    private readonly IApplicationContext _context;

    public GetBookByISBNQueryHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<Book> Handle(GetBookByISBNQuery query, CancellationToken cancellationToken)
    {
        var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.ISBN == query.ISBN, cancellationToken);

        return book;
    }
}
