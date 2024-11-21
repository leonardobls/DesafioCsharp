using System.ComponentModel.DataAnnotations;

namespace DesafioTecnicoProcessoSeletivo.Models
{
    public class MoviesCategoryModel
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}