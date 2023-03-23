using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.Products.Vm;
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

        public CreateProductCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.CreateProductDto);

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var response = _mapper.Map<ProductVm>(product);

            return response;
        }
    }
}
