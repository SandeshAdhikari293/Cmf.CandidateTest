using Cmf.CandidateTest.Data.Models;

namespace Cmf.CandidateTest.Data.Repository;

/// <summary>
/// Defines the interface for the Users repository.
/// </summary>
public interface IUsersRepository
{
    Task<IEnumerable<User>> UsersWithNoOrders();
}
