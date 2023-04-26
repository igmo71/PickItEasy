namespace PickItEasy.Application.Models.Products
{
    public class ProductDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required bool Active { get; set; }
    }
}
