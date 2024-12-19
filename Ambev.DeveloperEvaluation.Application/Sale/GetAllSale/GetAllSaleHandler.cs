using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;

public class GetAllSaleHandler : IRequestHandler<GetAllSaleCommand, IList<GetAllSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetAllSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<IList<GetAllSaleResult>> Handle(GetAllSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _saleRepository.GetAllAsync(cancellationToken);
            Console.WriteLine($"GetAllSale completed");

            if (response == null)
                throw new NullReferenceException("No sales found");

            return _mapper.Map<IList<GetAllSaleResult>>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
