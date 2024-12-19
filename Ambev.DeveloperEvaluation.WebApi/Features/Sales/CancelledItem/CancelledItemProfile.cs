using Ambev.DeveloperEvaluation.Application.Sale.CancelledItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelledItem;

public class CancelledItemProfile : Profile
{
    public CancelledItemProfile()
    {

        CreateMap<CancelledItemResult, CancelledItemResponse>();
    }
}