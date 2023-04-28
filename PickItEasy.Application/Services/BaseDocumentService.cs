using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Interfaces.Services;
using PickItEasy.Application.Models.BaseDocuments;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services
{
    public class BaseDocumentService : IBaseDocumentService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<BaseDocumentService> _logger;

        public BaseDocumentService(IApplicationDbContext dbContext, ILogger<BaseDocumentService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<BaseDocumentDto> CreateAsync(BaseDocumentDto dto)
        {
            BaseDocument baseDocument = dto.Adapt<BaseDocument>();

            bool isBaseDocumentExists = await IsExistsByIdAsync(dto.Id);
            if (isBaseDocumentExists)
            {
                await UpdateAsync(dto);
            }
            else
            {
                await _dbContext.BaseDocuments.AddAsync(baseDocument);
                await _dbContext.SaveChangesAsync();
            }

            return dto;
        }

        public async Task CreateRangeAsync(List<BaseDocumentDto> dtoList)
        {
            foreach (BaseDocumentDto item in dtoList)
            {
                await CreateAsync(item);
            }
        }

        public async Task<bool> IsExistsByIdAsync(Guid id)
        {
            bool result = await _dbContext.BaseDocuments.AnyAsync(p => p.Id == id);
            return result;
        }

        public async Task UpdateAsync(BaseDocumentDto dto)
        {
            BaseDocument? baseDocument = await _dbContext.BaseDocuments
                .FirstOrDefaultAsync(e => e.Id == dto.Id);

            if (baseDocument is null || baseDocument.Id != dto.Id)
                throw new NotFoundException(nameof(BaseDocument), dto.Id);

            baseDocument.Name = dto.Name;

            await _dbContext.SaveChangesAsync();
        }
    }
}
