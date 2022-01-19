using Bookstore.Data;
using Bookstore.Models;
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

        [Route("/addAuthors")]
        [HttpPost]
        public async Task<IActionResult> addAuthor([FromBody] Author author)
        {
            if (string.IsNullOrEmpty(author.name) || author.yearOfBirth.Year == 1)
                return BadRequest("fields cannot be null");

            if (author.yearOfDeath < author.yearOfBirth)
                return BadRequest("author dead before birth ?");

            await ctx.authors.AddAsync(new Author
            {
                name = author.name,
                yearOfDeath = author.yearOfDeath,
                yearOfBirth = author.yearOfBirth
            });

            await ctx.SaveChangesAsync();

            return Ok("author added");
        }

        [Route("/editAuthors/{id}")]
        [HttpPut]
        public async Task<IActionResult> editAuthor(int ID, [FromBody] Author author)
        {
            if (string.IsNullOrEmpty(author.name) || author.yearOfBirth.Year == 1)
                return BadRequest("fields cannot be null");

            if (author.yearOfDeath < author.yearOfBirth)
                return BadRequest("author dead before birth ?");

            var autor = await ctx.authors.FirstOrDefaultAsync(x => x.authorId == ID);

            if (author.name != autor.name)
                autor.name = author.name;

            if (author.yearOfBirth != autor.yearOfBirth && author.yearOfBirth.Year != 1)
                autor.yearOfBirth = author.yearOfBirth;

            if (author.yearOfDeath != autor.yearOfDeath && author.yearOfDeath.Year != 1)
                autor.yearOfDeath = author.yearOfDeath;

            await ctx.SaveChangesAsync();

            return Ok($"author {ID} modified");
        }

        [Route("/deleteAuthors/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteAuthor(int ID)
        {
            var author = await ctx.authors.FirstOrDefaultAsync(x => x.authorId == ID);

            if (author == null)
                return NotFound("author doesn't exist");

            ctx.authors.Remove(author);
            await ctx.SaveChangesAsync();

            return Ok($"author {ID} deleted succesfully");
        }
    }
}
