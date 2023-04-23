using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OrderService.Controllers;

namespace OrderService.Tests.UnitTests
{
    [TestFixture]
    public class WelcomeControllerTests
    {
        [Test]
        public void Greet_ReturnsWelcomeMessage()
        {
            // Arrange
            var controller = new WelcomeController();

            // Act
            var result = controller.Greet() as ActionResult<string>;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.EqualTo("Welcome to the new world of AI"));
        }
    }
}