using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnicoProcessoSeletivo.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public required string Resume { get; set; }

        [Required]
        public required string Director { get; set; }

        [Required]
        public required string Image { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public virtual MoviesCategoryModel? Category { get; set; }
    }
}