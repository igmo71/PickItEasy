using System.ComponentModel.DataAnnotations;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutProductDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public float Count { get; set; }               
    }
}
