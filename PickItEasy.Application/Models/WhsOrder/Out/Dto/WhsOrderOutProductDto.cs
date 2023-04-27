using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Models.WhsOrder.Out.Dto
{
    public class WhsOrderOutProductDto
    {
        public required Guid ProductId { get; set; }
        public required float Count { get; set; }

        /// <summary>
        /// Map from WhsOrderOutProductDto to WhsOrderOutProduct
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static WhsOrderOutProduct ToWhsOrderOutProduct(WhsOrderOutProductDto source)
        {
            WhsOrderOutProduct destination = new()
            {
                ProductId = source.ProductId,
                Count = source.Count
            };

            return destination;
        }
    }
}
