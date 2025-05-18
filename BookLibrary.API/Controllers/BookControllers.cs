    using BookLibrary.Domain.Models;
    using BookLibrary.Service.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    namespace BookLibrary.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _bookService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Book book)
            => Ok(await _bookService.CreateAsync(book));

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateAsync(long id, Book book)
            => Ok(await _bookService.UpdateAsync(id, book));

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _bookService.DeleteAsync(id));
    }
