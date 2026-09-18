using Cmf.CandidateTest.Data.Models;
using Cmf.CandidateTest.Data.Query;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Cmf.CandidateTest.Data.Repository;

/// <summary>
/// Represents the repository for managing orders in the database.
/// </summary>
/// <param name="configuration">The application configuration.</param>
public class OrdersRepository(IConfiguration configuration) : IOrdersRepository
{
    private readonly string _defaultConnection = configuration.GetConnectionString("DefaultConnection")
                                                 ?? throw new InvalidOperationException("DefaultConnection is not configured.");

    public async Task<int?> CreateOrderAsync(int userId)
    {
        await using var connection = new SqliteConnection(_defaultConnection);
        return await connection.ExecuteScalarAsync<int>(Orders.CreateOrder, new { OrderDate = DateTime.UtcNow, UserId = userId });
    }
    /// <inheritdoc />
    public async Task<Order?> GetByIdAsync(int id)
    {
        await using var connection = new SqliteConnection(_defaultConnection);
        return await connection.QuerySingleOrDefaultAsync<Order>(Orders.GetById, new { Id = id });
    }
}
