namespace PickItEasy.Domain.Entities
{
    public abstract class WhsOrder : Document
    {
        public List<Product>? Products { get; set; }
    }
}
