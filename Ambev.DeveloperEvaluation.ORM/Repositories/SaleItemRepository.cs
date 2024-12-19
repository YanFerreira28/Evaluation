using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new user in the database
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
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

    /// <summary>
    /// Retrieves a user by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a user from the database
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
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
