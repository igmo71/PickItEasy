using PickItEasy.Application.Services.WhsOrders.Out;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.BaseDocuments
{
    public class BaseDocumentMapper
    {
        public static BaseDocument Map(BaseDocumentDto dto)
        {
            BaseDocument destination = new()
            {
                Id = dto.Id,
                Name = dto.Name
            };
            return destination;
        }

        public static BaseDocumentDto Map(WhsOrderOutBaseDocumentDto dto)
        {
            BaseDocumentDto destination = new()
            {
                Id = dto.DocumentId,
                Name = dto.DocumentName
            };

            return destination;
        }
    }
}
