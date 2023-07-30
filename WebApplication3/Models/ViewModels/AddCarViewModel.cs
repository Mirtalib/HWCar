using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModels
{
    public class AddCarViewModel
    {
        [Required]
        [MinLength(3)]
        public string Make { get; set; } = null!;

        [Required]
        [MinLength(2)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(1 , int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [Range(1900, int.MaxValue)]
        public int Year { get; set; }

        [Required]
        [MinLength(3)]
        public string Color { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue)]
        public int EngineSize { get; set; }
    }
}
