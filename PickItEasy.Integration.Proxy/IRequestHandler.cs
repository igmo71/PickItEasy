using PickItEasy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Integration.Proxy
{
    public interface IRequestHandler
    {
        Task<string> Handle<T>(T request);
    }
}
