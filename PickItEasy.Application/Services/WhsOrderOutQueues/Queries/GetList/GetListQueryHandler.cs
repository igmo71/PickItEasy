using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Models.WhsOrder.Out.Vm;

namespace PickItEasy.Application.Services.WhsOrderOutQueues.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, WhsOrderOutQueueListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhsOrderOutQueueListVm> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var queues = await _dbContext.WhsOrderOutQueues
                .AsNoTracking()
                .Where(e => e.Active)
                .OrderBy(e => e.Value)
                .ProjectTo<WhsOrderOutQueueVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            var response = new WhsOrderOutQueueListVm() { Queues = queues };
            return response;
        }
    }
}
