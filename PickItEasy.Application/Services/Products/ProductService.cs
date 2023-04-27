﻿using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.Services;
using PickItEasy.Application.Models.Products;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IApplicationDbContext dbContext, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            Product product = dto.Adapt<Product>();

            bool isProductExists = await IsExistsByIdAsync(product.Id);
            if (isProductExists)
            {
                await UpdateAsync(dto);
            }
            else
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
            }

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            Product product = await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(Product), id);

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DisableAsync(Guid id)
        {
            Product product = await _dbContext.Products.FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(Product), id);

            product.Active = false;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductVm> GetByIdAsync(Guid id)
        {
            Product product = await _dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id)
                ?? throw new NotFoundException(nameof(Product), id);

            ProductVm result = product.Adapt<ProductVm>();

            return result;
        }

        public async Task<bool> IsExistsByIdAsync(Guid id)
        {
            bool result = await _dbContext.Products.AnyAsync(p => p.Id == id);

            return result;
        }

        public async Task UpdateAsync(ProductDto dto)
        {
            Product? product = await _dbContext.Products
                .FirstOrDefaultAsync(e => e.Id == dto.Id);

            if (product is null || product.Id != dto.Id)
                throw new NotFoundException(nameof(Product), dto.Id);

            product.Name = dto.Name;
            product.Active = dto.Active;

            await _dbContext.SaveChangesAsync();
        }
    }
}
