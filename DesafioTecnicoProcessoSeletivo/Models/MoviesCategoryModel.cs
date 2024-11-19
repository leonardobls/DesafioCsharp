using System.ComponentModel.DataAnnotations;

namespace DesafioTecnicoProcessoSeletivo.Models
{
    public class MoviesCategory
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}