using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookshelf.Core.Domain.Entities;
using Bookshelf.Core.Enums;
using Bookshelf.Infrastructure.Data;
using Bookshelf.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Web.Controllers
{
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("Hello from BooksController");
        }

        [HttpGet]
        public IEnumerable<BookModel> GetBooks()
        {

            var bookResult = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Loans)
                .OrderBy(r => r.Title).ToList();

            List<BookModel> books = _mapper.Map<List<Book>, List<BookModel>>(bookResult);

            books
                .Where(b => 
                b.Loans.Any() && 
                !b.Loans.All(loan => loan.DateReturned.HasValue))
                .Select(b => b.Loaned = true)
                .ToList();
            return books;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Book>(bookModel);

            _context.Add(book);
            var save = await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = bookModel.Id }, bookModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}