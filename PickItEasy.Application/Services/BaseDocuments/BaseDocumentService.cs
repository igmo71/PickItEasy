using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Interfaces;
using PickItEasy.Application.Services.WhsOrders.Out;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.BaseDocuments
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
            var baseDocument = BaseDocumentMapper.Map(dto);

            var isBaseDocumentExists = await IsExistsByIdAsync(dto.Id);
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

        public async Task CreateRangeAsync(List<WhsOrderOutBaseDocumentDto> dtoList)
        {
            foreach (var item in dtoList)
            {
                BaseDocumentDto baseDocumentDto = BaseDocumentMapper.Map(item);
                await CreateAsync(baseDocumentDto);
            }
        }

        public async Task<bool> IsExistsByIdAsync(Guid id)
        {
            var result = await _dbContext.BaseDocuments.AnyAsync(p => p.Id == id);
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
