using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

public class GetSaleCommand : IRequest<GetSaleResult>
{
    public Guid SaleId { get; set; }
}