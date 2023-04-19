using AutoMapper;
using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces.Integration;

namespace PickItEasy.Application.Integration.WhsOrdersOut
{
    public class PostWhsOrderOutRequestHandler : IRequestHandler<PostWhsOrderOutRequest, string>
    {
        private readonly IMapper _mapper;
        private readonly IClient1cUt _client1CUt;
        private readonly IHub1cUtService _hub1cUtService;

        public PostWhsOrderOutRequestHandler(IMapper mapper, IClient1cUt client1CUt, IHub1cUtService hub1cUtService)
        {
            _mapper = mapper;
            _client1CUt = client1CUt;
            _hub1cUtService = hub1cUtService;
        }

        public async Task<string> Handle(PostWhsOrderOutRequest request, CancellationToken cancellationToken)
        {
            var whsOrderOutDto = _mapper.Map<WhsOrderOutDto>(request.WhsOrderOutVm);
            string result = "error";
            //result = await _client1CUt.PostWhsOrderOutAsync(whsOrderOutDto);
            result = await _hub1cUtService.SendWhsOrderOutAsync(whsOrderOutDto);
            return result;
        }
    }
}
