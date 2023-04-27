using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.Warehouses
{
    public class WarehouseDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
