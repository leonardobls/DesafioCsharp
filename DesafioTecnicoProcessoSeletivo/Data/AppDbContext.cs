using DesafioTecnicoProcessoSeletivo.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnicoProcessoSeletivo.Data
{
    public class AppDbContext(IConfiguration configuration) : DbContext
    {

        public required DbSet<Movie> Movie { get; set; }
        public required DbSet<MoviesCategory> MoviesCategory { get; set; }
        public required DbSet<Streaming> Streaming { get; set; }
        private readonly IConfiguration _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}