using Cmf.CandidateTest.Data.Models;
using Cmf.CandidateTest.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cmf.CandidateTest.Api.Controllers;

[ApiController]
[Authorize] //Part 2
[Route("api/[controller]")]
public class OrdersController(IOrdersRepository ordersRepository) : ControllerBase
{

    //Part 1A
    [HttpGet("{Id:int}")]
    public async Task<ActionResult<Order>> GetOrder(int Id)
    {
        Order? order = await ordersRepository.GetByIdAsync(Id);
        if (order is null) return NotFound();

        return Ok(order);
    }


    //Part 1B
    public class CreateOrderRequest
    {
        public int userId { get; set; }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        if (request.userId <= 0) return ValidationProblem("userId must be greater than 0.");

        var orderId = await ordersRepository.CreateOrderAsync(request.userId);

        if(orderId is null)
        {
            return Problem(
                detail: "Could not create order",
                statusCode: StatusCodes.Status500InternalServerError
            );
        }

        return StatusCode(StatusCodes.Status201Created, new { OrderId = orderId, Status = "OK", Message = $"Order has been successfully created with OrderId = {orderId}." });
    }

}

