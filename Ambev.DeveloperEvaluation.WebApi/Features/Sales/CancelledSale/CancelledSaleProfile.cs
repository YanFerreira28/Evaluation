using Ambev.DeveloperEvaluation.Application.Sale.CancelledSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelledSale;

public class CancelledSaleProfile : Profile
{
    public CancelledSaleProfile()
    {

        CreateMap<CancelledSaleResult, CancelledSaleResponse>();
    }
}