using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.BaseDocuments
{
    public class BaseDocumentDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }

        /// <summary>
        /// Map from BaseDocumentDto to BaseDocument
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static BaseDocument Map(BaseDocumentDto dto)
        {
            BaseDocument destination = new()
            {
                Id = dto.Id,
                Name = dto.Name
            };
            return destination;
        }
    }
}
