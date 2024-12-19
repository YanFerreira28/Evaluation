
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string Customer { get; set; }

    public decimal TotalAmount { get; private set; }
    public bool IsCancelled { get; set; }
    public string Branch { get; set; }
    public ICollection<GetSaleItemResponse> Items { get; set; }
}

public class GetSaleItemResponse
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public string Product { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; private set; }
    public bool IsCancelled { get; set; }
    public decimal TotalAmount { get; private set; }
}
