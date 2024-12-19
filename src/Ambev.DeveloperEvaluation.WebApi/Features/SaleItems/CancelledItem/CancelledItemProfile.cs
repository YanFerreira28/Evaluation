using Ambev.DeveloperEvaluation.Application.SaleItem.CancelledItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelledItem;

public class CancelledItemProfile : Profile
{
    public CancelledItemProfile()
    {

        CreateMap<CancelledItemResult, CancelledItemResponse>();
    }
}