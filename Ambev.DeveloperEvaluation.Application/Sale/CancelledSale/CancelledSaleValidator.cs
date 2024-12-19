using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CancelledSale;

public class CancelledSaleValidator : AbstractValidator<CancelledSaleCommand>
{
    public CancelledSaleValidator()
    {
        RuleFor(sale => sale.SaleId).NotNull();
    }
}
