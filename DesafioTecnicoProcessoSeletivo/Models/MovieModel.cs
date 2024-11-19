using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnicoProcessoSeletivo.Models
{
    public class Movie
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

        public virtual MoviesCategory? Category { get; set; }
    }
}