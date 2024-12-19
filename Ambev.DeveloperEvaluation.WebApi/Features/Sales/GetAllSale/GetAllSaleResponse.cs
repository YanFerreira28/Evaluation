
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSale;

public class GetAllSaleResponse
{
    public Guid Id { get; set; } 
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; } 
    public string Customer { get; set; }

    public decimal TotalAmount { get; private set; }
    public bool IsCancelled { get; set; }
    public string Branch { get; set; }
    public ICollection<GetAllSaleItemResponse> Items { get; set; }
}


public class GetAllSaleItemResponse
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

