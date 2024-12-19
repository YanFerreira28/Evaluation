

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

public class GetSaleResult
{
    public Guid Id { get; set; } 
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; } 
    public string Customer { get; set; }

    public decimal TotalAmount { get; private set; }
    public bool IsCancelled { get; set; }
    public string Branch { get; set; }
    public ICollection<GetSaleItemResult> Items { get; set; }
}

public class GetSaleItemResult
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
