using AutoMapper;
using Library.API.Models;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Books.Queries.GetBookById;
using Library.Application.Books.Queries.GetBookByISBN;
using Library.Application.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public BooksController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _mediator.Send(new GetBooksQuery());

        var booksResponse = _mapper.Map<List<BookResponse>>(books);

        return Ok(booksResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id));

        var bookResponse = _mapper.Map<BookResponse>(book);

        return Ok(bookResponse);
    }

    [HttpGet("isbn/{isbn}")]
    public async Task<IActionResult> GetBookByISBN(string isbn)
    {
        var book = await _mediator.Send(new GetBookByISBNQuery(isbn));

        var bookResponse = _mapper.Map<BookResponse>(book);

        return Ok(bookResponse);
    }

    [HttpPost]
    [Authorize]

    public async Task<IActionResult> AddBook(CreateBookCommand command)
    {
        var book = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetBookById), new { Id = book.Id }, command);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _mediator.Send(new DeleteBookCommand(id));

        return NoContent();
    }
}
