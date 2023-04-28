using AutoMapper;
using MediatR;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Models.Products;
using PickItEasy.Application.Services.Products.Commands.Update;
using PickItEasy.Application.Services.Products.Queries.IsExistsById;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.MediatR.Services.Products.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, ProductDto>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ProductDto> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDto);

            var isProductExists = await _mediator.Send(new IsExistsByIdQuery { Id = product.Id }, cancellationToken);
            if (isProductExists)
            {
                await _mediator.Send(new UpdateCommand
                {
                    Id = product.Id,
                    ProductDto = request.ProductDto
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
