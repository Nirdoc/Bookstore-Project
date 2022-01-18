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
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDBContext ctx;

        public AuthorsController(ApplicationDBContext ctx)
        {
            this.ctx = ctx;
        }

        [Route("/getAuthors")]
        [HttpGet]
        public async Task<IActionResult> findAll(){
            var authors = await ctx.authors.ToListAsync();

            if (authors == null || authors.Count == 0)
                return NotFound("No authors found");

            return Ok(authors);
        }
    }
}
