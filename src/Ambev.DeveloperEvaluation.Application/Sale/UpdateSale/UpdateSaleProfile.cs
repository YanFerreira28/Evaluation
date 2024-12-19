using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

internal class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleItemCommand, Domain.Entities.SaleItem>();
        CreateMap<Domain.Entities.SaleItem, UpdateSaleItemResult>();
        CreateMap<UpdateSaleCommand, Domain.Entities.Sale>();
        CreateMap<Domain.Entities.Sale, UpdateSaleResult>();
    }
}
