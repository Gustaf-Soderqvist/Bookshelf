using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookshelf.Core.Domain.Entities;
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
            return Ok("Hello from libaryController");
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            var result = _context.Books.Include(x => x.Author).OrderByDescending(r => r.Id).ToList();

            List<BookModel> books = _mapper.Map<List<Book>, List<BookModel>>(result);
            books.Select(x => x.Genre.ToString());
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(bookModel);
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