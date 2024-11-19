using System.ComponentModel.DataAnnotations;

namespace DesafioTecnicoProcessoSeletivo.Models
{
    public class Streaming
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}