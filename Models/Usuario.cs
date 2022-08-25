using System.ComponentModel.DataAnnotations;

namespace ADOAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
