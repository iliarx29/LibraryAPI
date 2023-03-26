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

    public BooksController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _mediator.Send(new GetBooksQuery());

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _mediator.Send(new GetBookByIdQuery(id));

        return Ok(book);
    }

    [HttpGet("isbn/{isbn}")]
    public async Task<IActionResult> GetBookByISBN(string isbn)
    {
        var book = await _mediator.Send(new GetBookByISBNQuery(isbn));

        return Ok(book);
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
