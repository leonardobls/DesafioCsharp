using DesafioTecnicoProcessoSeletivo.Data;
using DesafioTecnicoProcessoSeletivo.DataTransferObjects;
using DesafioTecnicoProcessoSeletivo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoProcessoSeletivo.Admin.Controllers
{

    [Route("/gerenciador/movies-category")]
    public class MoviesCategoryController : Controller
    {

        private readonly AppDbContext _context;

        public MoviesCategoryController(AppDbContext context)
        {
            _context = context;
        }

        [Route("/gerenciador/movies-category")]
        public async Task<IActionResult> List([FromQuery] int? page, [FromQuery] string? searchTerm)
        {
            int pageSize = 10;
            int currentPage = page ?? 1;

            IQueryable<MoviesCategoryModel> query = _context.MoviesCategory;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.Trim().Equals(searchTerm.Trim()));
            }

            ViewBag.MoviesCategories = await query
            .OrderBy(x => x.Id)
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            int totalItems = await _context.MoviesCategory.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.CurrentPage = currentPage;
            ViewBag.NextPage = currentPage < totalPages ? currentPage + 1 : currentPage;
            ViewBag.PreviousPage = currentPage > 1 ? currentPage - 1 : currentPage;
            ViewBag.TotalPages = totalPages;

            return View();
        }

        [Route("/gerenciador/movies-category/edit/{Id?}")]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
                ViewBag.MoviesCategory = _context.MoviesCategory.First((s) => s.Id == Id);
            else
                ViewBag.MoviesCategory = null;

            return View("/Views/Admin/MoviesCategory/Edit.cshtml");
        }

        [Route("/gerenciador/movies-category/save/{id?}")]
        public async Task<IActionResult> Save([FromForm] MoviesCategoryDTO moviesCategoryForm, int? id)
        {
            try
            {
                if (id != null)
                {
                    Console.WriteLine("Atualizando...");
                    MoviesCategoryModel category = await _context.MoviesCategory.FirstAsync((s) => s.Id == id);
                    category.Name = moviesCategoryForm.Name;

                    _context.MoviesCategory.Update(category);
                    await _context.SaveChangesAsync();
                    return Redirect("/gerenciador/movies-category?message=success");
                }
                else
                {
                    Console.WriteLine("Criando...");

                    var newCategory = new MoviesCategoryModel
                    {
                        Name = moviesCategoryForm.Name
                    };

                    _context.MoviesCategory.Add(newCategory);
                    await _context.SaveChangesAsync();

                    return Redirect("/gerenciador/movies-category?message=created");
                }
            }
            catch (Exception)
            {
                return Redirect("/gerenciador/movies-category?message=error");
            }
        }

        [Route("/gerenciador/movies-category/delete/{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            try
            {
                MoviesCategoryModel categoryToDelete = _context.MoviesCategory.First((c) => c.Id == categoryId);
                _context.MoviesCategory.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
                return Redirect("/gerenciador/movies-category?message=delete-success");
            }
            catch (Exception)
            {
                return Redirect("/gerenciador/movies-category?message=delete-fail");
            }
        }
    }
}