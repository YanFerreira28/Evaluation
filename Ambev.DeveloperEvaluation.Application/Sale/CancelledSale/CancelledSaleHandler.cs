using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CancelledSale;

public class CancelledSaleHandler : IRequestHandler<CancelledSaleCommand, CancelledSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CancelledSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<CancelledSaleResult> Handle(CancelledSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CancelledSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _saleRepository.CancelSaleAsync(command.SaleId, cancellationToken);
            Console.WriteLine($"SaleCancelled: Sale ID {command.SaleId}");

            return new CancelledSaleResult() { SaleId = command.SaleId };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
