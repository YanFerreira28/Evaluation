using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string Customer { get; set; } 
    public string Branch { get; set; } 
    public List<CreateSaleItemCommand> Items { get; set; }
}

public class CreateSaleItemCommand
{
    public string Product { get; set; } 
    public int Quantity { get; set; } 
    public decimal UnitPrice { get; set; } 
}