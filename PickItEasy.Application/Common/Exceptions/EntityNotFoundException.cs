namespace PickItEasy.Application.Common.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string name, Guid? key) : base($"Entity '{name}' ({key}) not found.") { }
        public EntityNotFoundException(string name, string? message) : base($"Entity '{name}' ({message}) not found.") { }
    }
}
