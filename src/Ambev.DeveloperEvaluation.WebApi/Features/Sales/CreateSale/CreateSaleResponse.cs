namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid? Id { get; set; } 
    public string Customer { get; set; } 
    public DateTime Date { get; set; }
    public string Branch { get; set; } 
    public decimal TotalAmount { get; set; } 
    public List<SaleItemResponse> Items { get; set; } 
}


public class SaleItemResponse
{
    public string Product { get; set; } 
    public int Quantity { get; set; } 
    public decimal UnitPrice { get; set; } 
    public decimal Discount { get; set; } 
    public decimal TotalAmount { get; set; } 
}



