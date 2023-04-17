using PickItEasy.Domain.Entities.Interfaces;

namespace PickItEasy.Domain.Entities
{
    public class Product : Item, IHasIsActive
    {
        public required bool Active { get; set; }
    }
}
