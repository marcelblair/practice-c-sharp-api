using System;
using Microsoft.AspNetCore.Mvc;
using practice_c_sharp_api.Services;
using practice_c_sharp_api.Models;

namespace practice_c_sharp_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        this._logger = logger;
    }

    [HttpGet]
    public IEnumerable<Book> GetAll()
    {
        return BookService.GetAllBooks();
    }

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book =  BookService.GetBookById(id);

        if(book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if(book is null)
            return BadRequest();
        
        BookService.Add(book);
        return CreatedAtAction(nameof(Get), new { id = book.id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.id)
            return BadRequest();

        var existingBook = Get(id);
        if (existingBook is null)
            return NotFound();

        BookService.Update(book);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (BookService.GetBookById(id) is null)
            return NotFound();

        BookService.Delete(id);
        return NoContent();
    }
}


