using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleItemCommand, Domain.Entities.SaleItem>();
        CreateMap<Domain.Entities.SaleItem, SaleItemResult>();
        CreateMap<CreateSaleCommand, Domain.Entities.Sale>();
        CreateMap<Domain.Entities.Sale, CreateSaleResult>();
    }
}
