using Cmf.CandidateTest.Api.Controllers;
using Cmf.CandidateTest.Data.Models;
using Cmf.CandidateTest.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Cmf.CandidateTest.Tests;

[TestClass]
public class OrdersControllerTests
{
    private readonly IOrdersRepository _repository = Substitute.For<IOrdersRepository>();
 
    //Part 3A
    // example of a test method signature for the GetOrderById endpoint
    [TestMethod]
    public async Task GetOrderById_ReturnsOkResult_WhenOrderExists()
    {
        var expectedOrder = new Order
        {
            Id = 1,
            OrderDate = DateTime.UtcNow.Date,
            UserId = 1
        };

        _repository.GetByIdAsync(1).Returns(expectedOrder);

        var controller = new OrdersController(_repository);

        var result = await controller.GetOrder(1);

        //Check we received a 200 response
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        var okResult = (OkObjectResult)result.Result!;
        var returnedOrder = (Order)okResult.Value!;

        //Check that the order properties match
        Assert.AreEqual(expectedOrder.Id, returnedOrder.Id);
        Assert.AreEqual(expectedOrder.OrderDate, returnedOrder.OrderDate);
        Assert.AreEqual(expectedOrder.UserId, returnedOrder.UserId);
    }

    //Part 3B
    [TestMethod]
    public async Task GetOrderById_ReturnsNotFound_WhenOrderNotExists()
    {
        _repository.GetByIdAsync(1).Returns((Order?) null);

        var controller = new OrdersController(_repository);

        var result = await controller.GetOrder(1);

        //Check we received a 404 response
        Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
    }
}
