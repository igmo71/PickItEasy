using AutoMapper;
using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.Integration;
using System.Net;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class PostWhsOrderOutRequestHandler : IRequestHandler<PostWhsOrderOutRequest, HttpStatusCode>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IClient1cUt _client1CUt;
        private readonly IHub1cUtService _hub1cUtService;

        public PostWhsOrderOutRequestHandler(IApplicationDbContext dbContext, IMapper mapper, IClient1cUt client1CUt, IHub1cUtService hub1cUtService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _client1CUt = client1CUt;
            _hub1cUtService = hub1cUtService;
        }

        public async Task<HttpStatusCode> Handle(PostWhsOrderOutRequest request, CancellationToken cancellationToken)
        {
            var whsOrderOutDto = _mapper.Map<WhsOrderOutDto>(request.WhsOrderOutVm);
            var httpStatusCode = await _client1CUt.PostWhsOrderOutAsync(whsOrderOutDto);
            await _hub1cUtService.SendWhsOrderOutAsync(whsOrderOutDto);
            return httpStatusCode;
        }
    }
}
