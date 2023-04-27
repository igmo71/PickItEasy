using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class Warehouse : Catalog, IHasActive
    {
        public bool Active { get; set; }
    }
}
