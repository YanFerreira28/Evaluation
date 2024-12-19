namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleResponse
{
    public Guid? Id { get; set; }
    public string Customer { get; set; }
    public DateTime Date { get; set; }
    public string Branch { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }
    public List<UpdateSaleItemResponse> Items { get; set; }
}


public class UpdateSaleItemResponse
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
