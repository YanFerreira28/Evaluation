using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;

internal class GetAllSaleProfile : Profile
{
    public GetAllSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetAllSaleResult>();
        CreateMap<Domain.Entities.SaleItem, GetAllSaleItemResult>();
    }
}