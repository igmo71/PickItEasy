using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Interfaces
{
    public interface IEventBusService
    {
        void SendMessage(object obj);
        void SendMessage(string message);
    }
}
