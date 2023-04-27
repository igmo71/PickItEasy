using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.Products
{
    public class ProductVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}