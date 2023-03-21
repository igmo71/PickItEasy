using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IEventBusPublisher _eventPublisher;

        public CreateProductCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IEventBusPublisher eventPublisher)
        {

            _dbContext = dbContext;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
        }

        public async Task<ProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.CreateProductDto);

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            var response = _mapper.Map<ProductVm>(product);

            return response;
        }
    }
}
