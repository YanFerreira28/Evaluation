using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sale.CancelledItem;

public class CancelledItemCommand : IRequest<CancelledItemResult>
{
    public Guid SaleItemId { get; set; }
}