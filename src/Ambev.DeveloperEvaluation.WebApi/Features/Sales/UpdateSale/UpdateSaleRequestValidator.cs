using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.Customer).NotEmpty().Length(3, 150);
        RuleFor(sale => sale.Branch).NotEmpty().Length(3, 150);
    }
}