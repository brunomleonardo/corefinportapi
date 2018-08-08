using System.ComponentModel.DataAnnotations;

namespace FinPort.Entities.Models
{
    public class GenerateTokenModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}