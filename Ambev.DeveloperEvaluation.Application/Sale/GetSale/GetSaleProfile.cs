using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

internal class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetSaleResult>();
        CreateMap<Domain.Entities.SaleItem, GetSaleItemResult>();
    }
}