using Mapster;

namespace PickItEasy.Application.Models
{
    public abstract class MappedModel : IRegister
    {
        public abstract void Register(TypeAdapterConfig config);
    }
}
