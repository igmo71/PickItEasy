using PickItEasy.Application.Services.WhsOrders.Out.Queues;
using PickItEasy.Application.Services.WhsOrders.Out.Statuses;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Services.WhsOrders.Out
{
    public class WhsOrderOutMapper
    {
        public static WhsOrderOut Map(WhsOrderOutDto source)
        {
            WhsOrderOut destination = new()
            {
                Id = source.Id,
                Name = source.Name,
                Number = source.Number,
                DateTime = source.DateTime,
                Active = source.Active,
                Comment = source.Comment,
                WarehouseId = source.WarehouseId,
                QueueNumber = source.QueueNumber,
                ShipDateTime = source.ShipDateTime
            };

            foreach (var item in source.Products)
            {
                destination.WhsOrderOutProducts.Add(Map(item));
            }

            foreach (var item in source.BaseDocuments)
            {
                destination.WhsOrderOutBaseDocuments.Add(Map(item));
            }

            return destination;
        }

        public static WhsOrderOutProduct Map(WhsOrderOutProductDto source)
        {
            WhsOrderOutProduct destination = new()
            {
                ProductId = source.ProductId,
                Count = source.Count
            };

            return destination;
        }

        public static WhsOrderOutBaseDocument Map(WhsOrderOutBaseDocumentDto source)
        {
            WhsOrderOutBaseDocument destination = new()
            {
                BaseDocumentId = source.DocumentId
            };

            return destination;
        }

        public static WhsOrderOutVm Map(WhsOrderOut source)
        {
            WhsOrderOutVm destination = new()
            {
                Active = source.Active,
                Id = source.Id,
                Name = source.Name,
                Number = source.Number,
                DateTime = source.DateTime,
                Comment = source.Comment,
                Status = Map(source.Status),
                Queue = Map(source.Queue),
                QueueNumber = source.QueueNumber,
                ShipDateTime = source.ShipDateTime
            };

            foreach (var item in source.WhsOrderOutProducts)
            {
                destination.Products.Add(Map(item));
            }

            foreach (var item in source.WhsOrderOutBaseDocuments)
            {
                destination.BaseDocuments.Add(Map(item));
            }

            return destination;
        }

        private static WhsOrderOutStatusVm? Map(WhsOrderOutStatus? source)
        {
            if (source == null) return default;

            WhsOrderOutStatusVm destination = new()
            {
                Id = source.Id,
                Value = source.Value,
                Synonym = source.Synonym
            };

            return destination;
        }

        private static WhsOrderOutQueueVm? Map(WhsOrderOutQueue? source)
        {
            if (source == null) return default;

            WhsOrderOutQueueVm destination = new()
            {
                Id = source.Id,
                Value = source.Value,
                Synonym = source.Synonym
            };

            return destination;
        }

        private static WhsOrderOutProductVm Map(WhsOrderOutProduct source)
        {
            WhsOrderOutProductVm destination = new()
            {
                ProductId = source.ProductId,
                Count = source.Count,
                Name = source.Product?.Name
            };

            return destination;
        }


        private static WhsOrderOutBaseDocumentVm Map(WhsOrderOutBaseDocument source)
        {
            WhsOrderOutBaseDocumentVm destination = new()
            {
                BaseDocumentId = source.BaseDocumentId,
                Name = source.BaseDocument?.Name
            };

            return destination;
        }

        public static List<WhsOrderOutLookupVm> Map(List<WhsOrderOut> source)
        {
            List<WhsOrderOutLookupVm> destination = new();
            foreach (var item in source)
            {
                destination.Add(MapLookup(item));
            }

            return destination;
        }

        private static WhsOrderOutLookupVm MapLookup(WhsOrderOut source)
        {
            WhsOrderOutLookupVm destination = new()
            {
                Id = source.Id,
                Name = source.Name,
                Number = source.Number,
                DateTime = source.DateTime,
                Active = source.Active,
                Comment = source.Comment,
                Warehouse = source.Warehouse,
                Status = Map(source.Status),
                Queue = Map(source.Queue),
                QueueNumber = source.QueueNumber,
                ShipDateTime = source.ShipDateTime
            };

            return destination;
        }
    }
}
