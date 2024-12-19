
namespace Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;

public class GetAllSaleResult
{
    public Guid Id { get; set; } 
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; } 
    public string Customer { get; set; }

    public decimal TotalAmount { get;  set; }
    public bool IsCancelled { get; set; }
    public string Branch { get; set; }
    public ICollection<GetAllSaleItemResult> Items { get; set; }
}

public class GetAllSaleItemResult
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public string Product { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get;  set; }
    public bool IsCancelled { get; set; }
    public decimal TotalAmount { get;  set; }
}
