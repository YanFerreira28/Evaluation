using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddAsync(saleItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return saleItem;
    }

    public async Task CancelSaleItemAsync(Guid saleItemId, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems
            .Where(c => c.Id == saleItemId)
            .ExecuteUpdateAsync(saleItem => saleItem.SetProperty(c => c.IsCancelled, true));

    }

    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var saleItems = await GetByIdAsync(id, cancellationToken);
        if (saleItems == null)
            return false;

        _context.SaleItems.Remove(saleItems);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
