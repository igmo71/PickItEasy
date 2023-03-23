using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PickItEasy.Application.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string name, Guid key) :base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
