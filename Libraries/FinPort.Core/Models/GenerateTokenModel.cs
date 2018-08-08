using System.ComponentModel.DataAnnotations;

namespace FinPort.Core.Models
{
    public class GenerateTokenModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}