using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.Products
{
    public class ProductDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
