using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OrderService.Controllers;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Tests.UnitTests
{
    [TestFixture]
    public class OrderControllerTests
    {
        private Mock<IOrderService> _mockOrderService;
        private OrderController _orderController;

        [SetUp]
        public void Setup()
        {
            _mockOrderService = new Mock<IOrderService>();
            _orderController = new OrderController(_mockOrderService.Object);
        }

        [Test]
        public void GetOrderById_ReturnsNotFound_WhenOrderIsNull()
        {
            // Arrange
            int id = 1;
            Order order = null;
            _mockOrderService.Setup(service => service.GetOrderById(id)).Returns(order);

            // Act
            ActionResult<Order> result = _orderController.GetOrderById(id);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void GetOrderById_ReturnsOrder_WhenOrderIsNotNull()
        {
            // Arrange
            int id = 1;
            Order order = new Order { Id = id, CustomerName = "John Doe" };
            _mockOrderService.Setup(service => service.GetOrderById(id)).Returns(order);

            // Act
            ActionResult<Order> result = _orderController.GetOrderById(id);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Order returnedOrder = (result.Result as OkObjectResult).Value as Order;
            Assert.That(returnedOrder.Id, Is.EqualTo(order.Id));
            Assert.That(returnedOrder.CustomerName, Is.EqualTo(order.CustomerName));
        }
    }
}
