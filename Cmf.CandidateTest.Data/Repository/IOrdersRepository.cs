using Cmf.CandidateTest.Data.Models;

namespace Cmf.CandidateTest.Data.Repository;

/// <summary>
/// Defines the interface for the Orders repository.
/// </summary>
public interface IOrdersRepository
{
    /// <summary>
    /// Gets an order by its ID.
    /// </summary>
    /// <param name="id">The ID of the order.</param>
    /// <returns>The order with the specified ID, or null if not found.</returns>
    Task<Order?> GetByIdAsync(int id);

    Task<int?> CreateOrderAsync(int userId);
}
