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
    public class PublishersController : ControllerBase
    {
        private readonly ApplicationDBContext ctx;

        public PublishersController(ApplicationDBContext ctx)
        {
            this.ctx = ctx;
        }

        [Route("/getPublishers")]
        [HttpGet]
        public async Task<IActionResult> findAll(){
            var publishers = await ctx.publishers.ToListAsync();

            if (publishers == null || publishers.Count == 0)
                return NotFound("No publishers found");

            return Ok(publishers);
        }
    }
}
