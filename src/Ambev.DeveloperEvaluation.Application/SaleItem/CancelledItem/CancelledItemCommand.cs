using MediatR;


namespace Ambev.DeveloperEvaluation.Application.SaleItem.CancelledItem;

public class CancelledItemCommand : IRequest<CancelledItemResult>
{
    public Guid SaleItemId { get; set; }
}