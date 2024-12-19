using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItem.CancelledItem;

public class CancelledItemValidator : AbstractValidator<CancelledItemCommand>
{
    public CancelledItemValidator()
    {
        RuleFor(sale => sale.SaleItemId).NotNull();
    }
}
