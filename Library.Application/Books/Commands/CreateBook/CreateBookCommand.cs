using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.CreateBook;
public record CreateBookCommand
    (string ISBN,
    string Title,
    string Author,
    string Description,
    string Genre,
    DateTime TakingTime) : IRequest<Book>;
