using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PickItEasy.Integration.Proxy.SignalRHubClient;

namespace PickItEasy.Integration.Proxy
{
    public interface ISignalRHubClient
    {
        string State { get; }
        Task SendMessageAsync(string message);
    }
}
