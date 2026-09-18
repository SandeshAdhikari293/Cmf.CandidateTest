using System;
using System.Collections.Generic;
using System.Text;

namespace Cmf.CandidateTest.Data.Query;

public static class Users
{
    public const string GetWithNoOrders = "SELECT * FROM Users u WHERE NOT EXISTS ( SELECT 1 FROM Orders o WHERE o.UserId = u.Id );";

}

