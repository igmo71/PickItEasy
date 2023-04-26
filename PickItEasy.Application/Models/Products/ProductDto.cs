using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.Products
{
    public class ProductDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool Active { get; set; }

        /// <summary>
        /// Map from ProductDto to Product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Product Map(ProductDto dto)
        {
            Product destination = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Active = dto.Active
            };

            return destination;
        }
    }
}
