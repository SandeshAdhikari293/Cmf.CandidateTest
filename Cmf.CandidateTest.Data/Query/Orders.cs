namespace Cmf.CandidateTest.Data.Query;

/// <summary>
/// Contains the SQL queries for the Orders repository.
/// </summary>
public static class Orders
{
    public const string GetById = "SELECT * FROM Orders o WHERE o.Id = @Id;";

    public const string CreateOrder = @"
        INSERT INTO Orders (OrderDate, UserId)
        VALUES (@OrderDate, @UserId);

        SELECT last_insert_rowid();
    ";
}
