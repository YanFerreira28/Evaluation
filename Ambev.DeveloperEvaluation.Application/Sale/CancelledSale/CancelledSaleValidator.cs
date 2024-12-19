using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.CancelledSale;

public class CancelledSaleValidator : AbstractValidator<CancelledSaleCommand>
{
    public CancelledSaleValidator()
    {
        RuleFor(sale => sale.SaleId).NotEmpty()
            .WithMessage("SaleId must not be empty.");
    }
}
