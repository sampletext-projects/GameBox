using System.Threading.Tasks;
using GameBox.Data;
using GameBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameBox.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly GameDbContext _context;

        public CommentsController(GameDbContext context)
        {
            _context = context;
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create([FromForm] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return Ok("Created");
            }

            return new BadRequestResult();
        }
    }
}