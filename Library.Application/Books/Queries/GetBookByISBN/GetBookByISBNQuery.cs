using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookByISBN;
public record GetBookByISBNQuery(string ISBN) : IRequest<Book>;
