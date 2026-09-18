using Cmf.CandidateTest.Data.Models;
using Cmf.CandidateTest.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cmf.CandidateTest.Api.Controllers;

[ApiController]
[Authorize] //Part 2
[Route("api/[controller]")]
public class UsersController(IUsersRepository usersRepository) : ControllerBase
{

    //Part 1C - Get users with no orders.
    [HttpGet("without-orders")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersWithNoOrder()
    {
        IEnumerable<User> users = await usersRepository.UsersWithNoOrders();
        return Ok(users);
    }
}
