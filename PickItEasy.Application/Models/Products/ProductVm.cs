using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.Products
{
    public class ProductVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        /// <summary>
        /// Map from Product to ProductVm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductVm Map(Product product)
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