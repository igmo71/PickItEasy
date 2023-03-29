namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
