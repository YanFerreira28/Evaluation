namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;


public class CreateSaleResult
{
    public Guid? Id { get; set; } 
    public string Customer { get; set; } 
    public DateTime Date { get; set; } 
    public string Branch { get; set; }
    public decimal TotalAmount { get; set; } 
    public bool IsCancelled { get; set; } 
    public List<SaleItemResult> Items { get; set; } 
}


public class SaleItemResult
{
    public string Product { get; set; } 
    public int Quantity { get; set; } 
    public decimal UnitPrice { get; set; } 
    public decimal Discount { get; set; } 
    public decimal TotalAmount { get; set; }
}
