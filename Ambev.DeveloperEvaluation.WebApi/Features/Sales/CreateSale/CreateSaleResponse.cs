namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid? Id { get; set; } // Identificador único da venda (usado para atualizações ou consultas)
    public string Customer { get; set; } // Nome do cliente
    public DateTime Date { get; set; } // Data da venda
    public Guid BranchId { get; set; } // ID da filial (External Identity)
    public string BranchName { get; set; } // Nome da filial (desnormalizado)
    public decimal TotalAmount { get; set; } // Valor total da venda
    public bool IsCancelled { get; set; } // Indicador se a venda foi cancelada
    public List<SaleItemResponse> Items { get; set; } // Lista de itens da venda
}


public class SaleItemResponse
{
    public string Product { get; set; } // Nome do produto (desnormalizado)
    public int Quantity { get; set; } // Quantidade do produto vendido
    public decimal UnitPrice { get; set; } // Preço unitário do produto
    public decimal Discount { get; set; } // Desconto aplicado ao item
    public decimal TotalAmount { get; set; } // Valor total do item após desconto
}



