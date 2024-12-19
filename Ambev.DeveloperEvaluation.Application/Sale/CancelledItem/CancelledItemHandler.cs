using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CancelledItem;

public class CancelledItemHandler : IRequestHandler<CancelledItemCommand, CancelledItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CancelledItemHandler(ISaleItemRepository saleItemRepository, ISaleRepository saleRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<CancelledItemResult> Handle(CancelledItemCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CancelledItemValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var item = await _saleItemRepository.GetByIdAsync(command.SaleItemId, cancellationToken);

            if (item == null)
                throw new NullReferenceException("Not found item");

            //Cancel Sale Item
            await _saleItemRepository.CancelSaleItemAsync(command.SaleItemId, cancellationToken);
            Console.WriteLine($"ItemCancelled: SaleItem ID {command.SaleItemId}");

            //Update total amount sale
            var sale = await _saleRepository.GetByIdAsync(item.SaleId, cancellationToken);
            sale.UpdateTotalAmount(sale.TotalAmount - item.TotalAmount);
            await _saleRepository.UpdateAsync(sale);
            Console.WriteLine($"SaleModified: Sale ID {command.SaleItemId}");


            return new CancelledItemResult() { SaleItemId = command.SaleItemId };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
