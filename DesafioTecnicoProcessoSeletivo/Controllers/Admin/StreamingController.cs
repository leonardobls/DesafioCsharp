using DesafioTecnicoProcessoSeletivo.Data;
using DesafioTecnicoProcessoSeletivo.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoProcessoSeletivo.Admin.Controllers
{

    [Route("/gerenciador/streaming")]
    public class StreamingController : Controller
    {

        private readonly AppDbContext _context;

        public StreamingController(AppDbContext context)
        {
            _context = context;
        }

        [Route("/gerenciador/streaming")]
        public async Task<IActionResult> List()
        {
            ViewBag.Streaming = _context.Streaming.Take(10).ToList();
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] StreamingDTO streamingForm)
        {
            Console.WriteLine("Criando...");
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] StreamingDTO streamingForm)
        {
            Console.WriteLine("Atualizando...");
            return Ok();
        }

        [HttpDelete("delete/{streamingId}")]
        public async Task<IActionResult> Delete(int streamingId)
        {
            Console.WriteLine("Excluindo...");
            return Ok();
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine("Listando todos...");
            return Ok();
        }
    }
}