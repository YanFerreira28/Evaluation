
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequest
{
    public Guid? Id { get; set; }
    public string Customer { get; set; }
    public DateTime Date { get; set; }
    public string Branch { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }
    public List<UpdateSaleItemRequest> Items { get; set; }
}

public class UpdateSaleItemRequest
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public bool IsCancelled { get; set; }
    public decimal TotalAmount { get; set; }
}
