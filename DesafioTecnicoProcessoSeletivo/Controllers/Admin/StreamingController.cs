using DesafioTecnicoProcessoSeletivo.Data;
using DesafioTecnicoProcessoSeletivo.DataTransferObjects;
using DesafioTecnicoProcessoSeletivo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> List([FromQuery] int? page, [FromQuery] string? searchTerm)
        {
            int pageSize = 10;
            int currentPage = page ?? 1;

            IQueryable<StreamingModel> query = _context.Streaming;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.Trim().Equals(searchTerm.Trim()));
            }

            ViewBag.Streamings = await query
            .OrderBy(x => x.Id)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            int totalItems = await _context.Streaming.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.CurrentPage = currentPage;
            ViewBag.NextPage = currentPage < totalPages ? currentPage + 1 : currentPage;
            ViewBag.PreviousPage = currentPage > 1 ? currentPage - 1 : currentPage;
            ViewBag.TotalPages = totalPages;

            return View();
        }

        [Route("/gerenciador/streaming/edit/{Id?}")]
        public async Task<IActionResult> Edit(int? Id)
        {

            if (Id != null)
                ViewBag.Streaming = _context.Streaming.First((s) => s.Id == Id);
            else
                ViewBag.Streaming = null;

            return View("/Views/Admin/Streaming/Edit.cshtml");
        }

        [Route("/gerenciador/streaming/save/{Id?}")]
        public async Task<IActionResult> Save([FromForm] StreamingDTO streamingForm, int? Id)
        {
            try
            {
                if (Id != null)
                {
                    Console.WriteLine("Atualizando...");
                    StreamingModel streaming = await _context.Streaming.FirstAsync((s) => s.Id == Id);
                    streaming.Name = streamingForm.Name;

                    _context.Streaming.Update(streaming);
                    await _context.SaveChangesAsync();
                    return Redirect("/gerenciador/streaming?message=success");
                }
                else
                {
                    Console.WriteLine("Criando...");

                    // Criar novo registro
                    var newStreaming = new StreamingModel
                    {
                        Name = streamingForm.Name
                    };

                    _context.Streaming.Add(newStreaming);
                    await _context.SaveChangesAsync();

                    return Redirect("/gerenciador/streaming?message=created");
                }
            }
            catch (Exception)
            {
                return Redirect("/gerenciador/streaming?message=error");
            }
        }

        [Route("/gerenciador/streaming/delete/{streamingId}")]
        public async Task<IActionResult> Delete(int streamingId)
        {
            try
            {
                StreamingModel streamingToDelete = _context.Streaming.First((s) => s.Id == streamingId);
                _context.Streaming.Remove(streamingToDelete);
                await _context.SaveChangesAsync();
                return Redirect("/gerenciador/streaming?message=delete-success");
            }
            catch (Exception)
            {
                return Redirect("/gerenciador/streaming?message=delete-fail");
            }
        }
    }
}