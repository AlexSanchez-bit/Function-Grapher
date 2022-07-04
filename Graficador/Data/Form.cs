
using System.ComponentModel.DataAnnotations;
namespace Graficador.Data
{
    

    public class Form
    {
        [Required]
        [StringLength(20, ErrorMessage = "Identifier too long (20 character limit).")]
        public string? Function { get; set; }

        [Required]

        [Range(1, 100, ErrorMessage = "Accommodation invalid (1-100).")]
        public double Intervale_a { get; set; }

        [Range(1, 100, ErrorMessage = "Accommodation invalid (1-100).")]
        public double Intervale_b { get; set; }

    }
}
