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
public class UsersRepository(IConfiguration configuration) : IUsersRepository
{
    private readonly string _defaultConnection = configuration.GetConnectionString("DefaultConnection")
                                                 ?? throw new InvalidOperationException("DefaultConnection is not configured.");

    public async Task<IEnumerable<User>> UsersWithNoOrders()
    {
        await using var connection = new SqliteConnection(_defaultConnection);
        return await connection.QueryAsync<User>(Users.GetWithNoOrders);
    }
}
