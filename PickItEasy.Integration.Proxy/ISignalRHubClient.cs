using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PickItEasy.Integration.Proxy.Hub1cUtClientService;

namespace PickItEasy.Integration.Proxy
{
    public interface ISignalRHubClient
    {
        string State { get; }
        void RegisterPostWhsOrderOutDtoHandler(OnPostWhsOrderOutDtoHandler handler);
        void UnregisterPostWhsOrderOutDtoHandler(OnPostWhsOrderOutDtoHandler handler);
    }
}
