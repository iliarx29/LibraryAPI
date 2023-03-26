using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Queries.GetBookById;
public record GetBookByIdQuery(int Id) : IRequest<Book>;

