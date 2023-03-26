using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookById;
public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly IApplicationContext _context;

    public GetBookByIdQueryHandler(IApplicationContext context)
    {
        _context = context;
    }
    public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

        if (book is null)
            throw new ArgumentNullException(nameof(book), "Book is null");

        return book;
    }
}
