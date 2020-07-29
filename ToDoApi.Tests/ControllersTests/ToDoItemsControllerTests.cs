using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoApi.Controllers;
using ToDoApi.Interfaces;
using ToDoApi.Models;
using Xunit;

namespace ToDoApi.Tests
{
    public class ToDoItemsControllerTests
    {
        [Fact]
        public void Find_ReturnsOkResult_WhenExistingIdIsPassed()
        {
            // Arrange
            String testId = "123";
            var mockRepo = new Mock<IToDoRepository>();
            mockRepo.Setup(repo => repo.Find(testId)).Returns(GetTestItem());
            var controller = new ToDoItemsController(mockRepo.Object);

            // Act
            var result = controller.Find(testId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Find_ReturnsNotFoundResult_WhenNonExistingIdIsPassed()
        {
            // Arrange
            String testId = "123";
            var mockRepo = new Mock<IToDoRepository>();
            mockRepo.Setup(repo => repo.Find(testId)).Returns((ToDoItem) null);
            var controller = new ToDoItemsController(mockRepo.Object);

            // Act
            var result = controller.Find(testId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        private ToDoItem GetTestItem()
        {
            return new ToDoItem()
            {
                ID = "123",
                Name = "Test item",
                Notes = "Test item notes",
                Done = false
            };
        }
    }
}
