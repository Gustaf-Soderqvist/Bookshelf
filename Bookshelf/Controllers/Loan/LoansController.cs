using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Bookshelf.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Bookshelf.Infrastructure.Data.Entities;
using System.Threading.Tasks;
using Bookshelf.Core.Domain.Entities;
using Bookshelf.Core.Interfaces.Gateways.Repositories;

namespace Bookshelf.Web.Controllers
{
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private readonly IDataRepository<Loan> _repo;
        public LoansController(ApplicationDbContext context, IMapper mapper, IDataRepository<Loan> repo)
        {
            _context = context;
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("Hello from LoansController");
        }

        [HttpGet]
        public IEnumerable<Loan> GetLoans()
        {
            var result = _context.Loans.ToList();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookModel bookModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Book>(bookModel);
            var loan = new Loan
            {
                DateTimeOut = DateTime.Today,
                DateDue = DateTime.Today.AddMonths(6),
                UserId = 1,
                BookId = bookModel.Id,
            };

            _context.Add(loan);
            await _repo.SaveAsync(loan);


            var dateDueConverted = loan.DateDue.ToShortDateString();
            return Ok(dateDueConverted);
        }

        [HttpPut("{id}")]
        public IActionResult ReturnBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLoan = _context.Loans.FirstOrDefault(loan => loan.BookId.Equals(id) && !loan.DateReturned.HasValue);
            if (userLoan == null)
            {
                return NotFound();
            }

            userLoan.DateReturned = DateTime.Now;
            _context.Loans.Update(userLoan);
            _context.SaveChanges();
            return Ok(userLoan);

        }

        [HttpGet("{id}")]
        public IActionResult GetUserLoans([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLoans = _context.Loans.Where(l => l.UserId.Equals(userId)).ToList();

            if (userLoans.Any())
            {
                return NotFound();
            }

            return Ok(userLoans);
        }
    }
}