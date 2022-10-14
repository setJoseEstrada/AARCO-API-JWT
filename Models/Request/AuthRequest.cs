using System.ComponentModel.DataAnnotations;

namespace AARCOAPI.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string correo { get; set; }
        [Required]
        public string contra { get; set; }
    }
}
