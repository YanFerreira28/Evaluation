using Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSale;

public class GetAllSaleProfile : Profile
{
    public GetAllSaleProfile()
    {

        CreateMap<GetAllSaleResult, GetAllSaleResponse>();
        CreateMap<GetAllSaleItemResult, GetAllSaleItemResponse>();
    }
}