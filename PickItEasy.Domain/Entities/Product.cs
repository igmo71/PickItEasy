using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class Product : Catalog, IHasActive
    {
        public bool Active { get; set; }
    }
}
