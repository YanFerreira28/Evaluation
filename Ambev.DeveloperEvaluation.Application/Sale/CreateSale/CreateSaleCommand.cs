using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string Customer { get; set; } // Nome do cliente
    public string Branch { get; set; } // Nome da filial (desnormalizado)
    public List<CreateSaleItemCommand> Items { get; set; } // Lista de itens da venda
}

public class CreateSaleItemCommand
{
    public string Product { get; set; } // Nome do produto (desnormalizado)
    public int Quantity { get; set; } // Quantidade do produto vendido
    public decimal UnitPrice { get; set; } // Preço unitário do produto
}