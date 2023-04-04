using AutoMapper;
using MediatR;
using PickItEasy.Application.Dtos;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.Products.Commands.Update;
using PickItEasy.Application.Services.Products.Queries.IsExistsById;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
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

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);

            var isProductExists = await _mediator.Send(new IsExistsProductByIdQuery { Id = product.Id }, cancellationToken);
            if (isProductExists)
            {
                await _mediator.Send(new UpdateProductCommand
                {
                    Id = product.Id,
                    ProductDto = new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name
                    }
                }, cancellationToken);
            }
            else
            {
                await _dbContext.Products.AddAsync(product, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return request.ProductDto;
        }
    }
}
