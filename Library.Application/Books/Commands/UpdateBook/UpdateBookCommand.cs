using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.UpdateBook;
public record UpdateBookCommand(
    int Id,
    string ISBN,
    string Title,
    string Description,
    string Author,
    string Genre,
    DateTime TakingTime) : IRequest;
