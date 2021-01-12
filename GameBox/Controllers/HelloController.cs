using Microsoft.AspNetCore.Mvc;

namespace GameBox.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class HelloController : Controller
    {
        [HttpGet(nameof(Index))]
        public IActionResult Index()
        {
            return Ok("Hello Index");
        }

        [HttpGet(nameof(Maybe))]
        public IActionResult Maybe(int? id)
        {
            return Ok($"Maybe called id={id}");
        }
    }
}