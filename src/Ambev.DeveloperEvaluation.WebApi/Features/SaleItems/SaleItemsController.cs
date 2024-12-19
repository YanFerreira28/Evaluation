using Ambev.DeveloperEvaluation.Application.SaleItem.CancelledItem;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelledItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

[ApiController]
[Route("api/[controller]")]
public class SaleItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SaleItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPatch("Cancel/{saleItemId}")]
    public async Task<IActionResult> CancelItem(Guid saleItemId, CancellationToken cancellationToken)
    {
        try
        {

            var command = new CancelledItemCommand() { SaleItemId = saleItemId };
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<CancelledItemResponse>
            {
                Success = true,
                Message = "Item Cancelleded successfully",
                Data = _mapper.Map<CancelledItemResponse>(response)
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<CancelledItemResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
    }
}
