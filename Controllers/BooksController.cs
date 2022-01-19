using Bookstore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDBContext ctx;

        public BooksController(ApplicationDBContext ctx)
        {
            this.ctx = ctx;
        }

        [Route("/getBooks")]
        [HttpGet]
        public async Task<IActionResult> findAll(){
            var books = await ctx.books.Include(a => a.author).Include(p => p.publisher).ToListAsync();

            if (books == null || books.Count == 0)
                return NotFound("No books found");

            return Ok(books);
        }
    }
}
