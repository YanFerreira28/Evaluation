
namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Sale
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string Customer { get; set; }

    public decimal TotalAmount { get; private set; }
    public bool IsCancelled { get; set; }
    public string Branch { get; set; } 
    public  ICollection<SaleItem> Items { get; set; } = new List<SaleItem>();

    

    public void CalculateTotalAmuntSale()
    {
        TotalAmount = Items.Sum(c => c.TotalAmount);
    }

    public void CalculateDiscountAndTotalAmountItems()
    {
        foreach(var item in Items)
        {
            item.DiscountCalculate();
            item.TotalAmountCalculate();
        }
    }
}
