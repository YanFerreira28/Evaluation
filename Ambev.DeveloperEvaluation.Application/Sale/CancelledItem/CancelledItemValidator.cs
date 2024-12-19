using Ambev.DeveloperEvaluation.Application.Sale.CancelledSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CancelledItem;

public class CancelledItemValidator : AbstractValidator<CancelledItemCommand>
{
    public CancelledItemValidator()
    {
        RuleFor(sale => sale.SaleItemId).NotNull();
    }
}
