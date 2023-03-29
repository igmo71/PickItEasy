using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces.EventBus;
using PickItEasy.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Domain.Entities;
using PickItEasy.Application.Services.Products.Queries.IsExistsById;
using PickItEasy.Application.Services.Products.Commands.Update;
using PickItEasy.Application.Services.Products.Queries.GetById;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.CreateProductDto);

            var isProductExists = await _mediator.Send(new IsExistsByIdProductQuery { Id = product.Id }, cancellationToken);
            if (!isProductExists)
            {
                await _dbContext.Products.AddAsync(product, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                await _mediator.Send(new UpdateProductCommand
                {
                    Id = product.Id,
                    UpdateProductDto = new UpdateProductDto
                    {
                        Name = product.Name
                    }
                }, cancellationToken);
            }

            var response = _mapper.Map<CreateProductVm>(product);

            return response;
        }
    }
}
