using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Products
{
    public class ProductMapper
    {
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

        internal static ProductVm Map(Product product)
        {
            ProductVm destination = new()
            {
                Id = product.Id,
                Name = product.Name
            };

            return destination;
        }
    }
}
