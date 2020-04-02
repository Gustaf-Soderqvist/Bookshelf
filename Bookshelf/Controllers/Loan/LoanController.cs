using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bookshelf.Infrastructure.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Bookshelf.Infrastructure.Data.Entities;

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
        public LoansController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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
    }
}