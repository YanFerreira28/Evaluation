namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
public class CreateSaleRequest
{
    public string Customer { get; set; } // Nome do cliente
    public string Branch { get; set; } // Nome da filial (desnormalizado)
    public List<SaleItemRequest> Items { get; set; } // Lista de itens da venda
}


public class SaleItemRequest
{
    public string Product { get; set; } // Nome do produto (desnormalizado)
    public int Quantity { get; set; } // Quantidade do produto vendido
    public decimal UnitPrice { get; set; } // Preço unitário do produto
}

