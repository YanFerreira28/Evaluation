using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sale.CancelledSale
{
    public class CancelledSaleCommand : IRequest<CancelledSaleResult>
    {
        public Guid SaleId { get; set; }
    }
}
