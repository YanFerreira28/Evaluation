namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class SaleItem
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public string Product { get; set; } 
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get;private set; }
    public decimal TotalAmount { get; private set; }

    public void DiscountCalculate()
    {
        if (Quantity == 4)
            Discount = 10;

        if (Quantity >= 10 && Quantity <= 20)
            Discount = 20;

        if (Quantity > 20)
            throw new ArgumentException("It's not possible to sell above 20 identical items");

    }

    public void TotalAmountCalculate()
    {
        var TotalWithoutDiscount = UnitPrice * Quantity;
        TotalAmount = TotalWithoutDiscount * (1 - (Discount / 100));
    }
}