using AutoMapper;
using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class PostWhsOrderOutRequestHandler : IRequestHandler<PostWhsOrderOutRequest, HttpStatusCode>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IClient1cUt _client1CUt;

        public PostWhsOrderOutRequestHandler(IApplicationDbContext dbContext, IMapper mapper, IClient1cUt client1CUt)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _client1CUt = client1CUt;
        }

        public async Task<HttpStatusCode> Handle(PostWhsOrderOutRequest request, CancellationToken cancellationToken)
        {
            var whsOrderOutDto = _mapper.Map<WhsOrderOutDto>(request.WhsOrderOutVm);
            var httpStatusCode = await _client1CUt.PostWhsOrderOutAsync(whsOrderOutDto);
            return httpStatusCode;
        }
    }
}
