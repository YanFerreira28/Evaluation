

namespace Ambev.DeveloperEvaluation.Domain.Events;
public class SaleCreated
{
    public Guid SaleId { get; set; }
    public DateTime CreatedAt { get; set; }
}
