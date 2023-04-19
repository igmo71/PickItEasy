using AutoMapper;
using PickItEasy.Domain.Entities;

namespace PickItEasy.Application.Dtos.Mapping
{
    public class WhsOrderOutMappingProfile : Profile
    {
        public WhsOrderOutMappingProfile()
        {
            // WhsOrderOutDto => WhsOrderOut
            CreateMap<WhsOrderOutDto, WhsOrderOut>()
                .ForMember(order => order.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(order => order.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(order => order.Number, opt => opt.MapFrom(dto => dto.Number))
                .ForMember(order => order.DateTime, opt => opt.MapFrom(dto => dto.DateTime))
                .ForMember(order => order.Active, opt => opt.MapFrom(dto => dto.Active))
                .ForMember(order => order.Comment, opt => opt.MapFrom(dto => dto.Comment))
                .ForMember(order => order.WarehouseId, opt => opt.MapFrom(dto => dto.WarehouseId))
                .ForMember(order => order.Status, opt => opt.Ignore())
                .ForMember(order => order.Queue, opt => opt.Ignore())
                .ForMember(order => order.QueueNumber, opt => opt.MapFrom(dto => dto.QueueNumber))
                .ForMember(order => order.ShipDateTime, opt => opt.MapFrom(dto => dto.ShipDateTime))
                .ForMember(order => order.WhsOrderOutProducts, opt => opt.MapFrom(dto => dto.Products))
                .ForMember(order => order.WhsOrderOutBaseDocuments, opt => opt.MapFrom(dto => dto.BaseDocuments))
                .ForMember(order => order.Products, opt => opt.Ignore())
                .ForMember(order => order.BaseDocuments, opt => opt.Ignore());

            CreateMap<WhsOrderOutProductDto, WhsOrderOutProduct>()
                .ForMember(product => product.ProductId, opt => opt.MapFrom(dto => dto.ProductId))
                .ForMember(product => product.Count, opt => opt.MapFrom(dto => dto.Count))
                .ForMember(product => product.Product, opt => opt.Ignore())
                .ForMember(product => product.WhsOrderOut, opt => opt.Ignore());

            CreateMap<WhsOrderOutBaseDocumentDto, WhsOrderOutBaseDocument>()
                .ForMember(baseDocument => baseDocument.BaseDocumentId, opt => opt.MapFrom(dto => dto.DocumentId))
                .ForMember(baseDocument => baseDocument.BaseDocument, opt => opt.Ignore())
                .ForMember(baseDocument => baseDocument.WhsOrderOut, opt => opt.Ignore());

            // WhsOrderOut => WhsOrderOutVm
            CreateMap<WhsOrderOut, WhsOrderOutVm>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(order => order.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(order => order.Name))
                .ForMember(vm => vm.Number, opt => opt.MapFrom(order => order.Number))
                .ForMember(vm => vm.DateTime, opt => opt.MapFrom(order => order.DateTime))
                .ForMember(vm => vm.Active, opt => opt.MapFrom(order => order.Active))
                .ForMember(vm => vm.Comment, opt => opt.MapFrom(order => order.Comment))
                .ForMember(vm => vm.Warehouse, opt => opt.MapFrom(order => order.Warehouse))
                .ForMember(vm => vm.Status, opt => opt.MapFrom(order => order.Status))
                .ForMember(vm => vm.Queue, opt => opt.MapFrom(order => order.Queue))
                .ForMember(vm => vm.QueueNumber, opt => opt.MapFrom(order => order.QueueNumber))
                .ForMember(vm => vm.ShipDateTime, opt => opt.MapFrom(order => order.ShipDateTime))
                .ForMember(vm => vm.Products, opt => opt.MapFrom(order => order.WhsOrderOutProducts))
                .ForMember(vm => vm.BaseDocuments, opt => opt.MapFrom(order => order.WhsOrderOutBaseDocuments));

            CreateMap<WhsOrderOutProduct, WhsOrderOutProductVm>()
                .ForMember(vm => vm.ProductId, opt => opt.MapFrom(orderProduct => orderProduct.Id))
                .ForMember(vm => vm.Count, opt => opt.MapFrom(orderProduct => orderProduct.Count))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(orderProduct =>
                    orderProduct.Product != null ? orderProduct.Product.Name : string.Empty));

            CreateMap<WhsOrderOutBaseDocument, WhsOrderOutBaseDocumentVm>()
                .ForMember(vm => vm.BaseDocumentId, opt => opt.MapFrom(orderBaseDocument => orderBaseDocument.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(orderBaseDocument =>
                    orderBaseDocument.BaseDocument != null ? orderBaseDocument.BaseDocument.Name : string.Empty));

            // WhsOrderOutVm => WhsOrderOutDto
            CreateMap<WhsOrderOutVm, WhsOrderOutDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(dto => dto.Number, opt => opt.MapFrom(vm => vm.Number))
                .ForMember(dto => dto.DateTime, opt => opt.MapFrom(vm => vm.DateTime))
                .ForMember(dto => dto.Active, opt => opt.MapFrom(vm => vm.Active))
                .ForMember(dto => dto.Comment, opt => opt.MapFrom(vm => vm.Comment))
                .ForMember(dto => dto.WarehouseId, opt => opt.MapFrom(vm => vm.Warehouse != null ? vm.Warehouse.Id : Guid.Empty))
                .ForMember(dto => dto.Status, opt => opt.MapFrom(vm =>
                    vm.Status != null ? vm.Status.Value : -1)) // TODO: кастыль
                .ForMember(dto => dto.Queue, opt => opt.MapFrom(vm =>
                    vm.Queue != null ? vm.Queue.Value : -1)) // TODO: кастыль
                .ForMember(dto => dto.QueueNumber, opt => opt.MapFrom(vm => vm.QueueNumber))
                .ForMember(dto => dto.ShipDateTime, opt => opt.MapFrom(vm => vm.ShipDateTime))
                .ForMember(dto => dto.Products, opt => opt.MapFrom(vm => vm.Products))
                .ForMember(dto => dto.BaseDocuments, opt => opt.MapFrom(vm => vm.BaseDocuments));

            CreateMap<WhsOrderOutProductVm, WhsOrderOutProductDto>()
                .ForMember(dto => dto.ProductId, opt => opt.MapFrom(vm => vm.ProductId))
                .ForMember(dto => dto.Count, opt => opt.MapFrom(vm => vm.Count));

            CreateMap<WhsOrderOutBaseDocumentVm, WhsOrderOutBaseDocumentDto>()
                .ForMember(dto => dto.DocumentId, opt => opt.MapFrom(vm => vm.BaseDocumentId))
                .ForMember(dto => dto.DocumentName, opt => opt.MapFrom(vm => vm.Name));

            // WhsOrderOut => WhsOrderOutLookupVm
            CreateMap<WhsOrderOut, WhsOrderOutLookupVm>()
                .ForMember(lookup => lookup.Id, opt => opt.MapFrom(order => order.Id))
                .ForMember(lookup => lookup.Name, opt => opt.MapFrom(order => order.Name))
                .ForMember(lookup => lookup.Number, opt => opt.MapFrom(order => order.Number))
                .ForMember(lookup => lookup.DateTime, opt => opt.MapFrom(order => order.DateTime))
                .ForMember(lookup => lookup.Active, opt => opt.MapFrom(order => order.Active))
                .ForMember(lookup => lookup.Comment, opt => opt.MapFrom(order => order.Comment))
                .ForMember(lookup => lookup.Warehouse, opt => opt.MapFrom(order => order.Warehouse))
                .ForMember(lookup => lookup.Status, opt => opt.MapFrom(order => order.Status))
                .ForMember(lookup => lookup.Queue, opt => opt.MapFrom(order => order.Queue))
                .ForMember(lookup => lookup.QueueNumber, opt => opt.MapFrom(order => order.QueueNumber))
                .ForMember(lookup => lookup.ShipDateTime, opt => opt.MapFrom(order => order.ShipDateTime));
        }
    }
}
