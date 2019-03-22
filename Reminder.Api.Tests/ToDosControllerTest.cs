using System;
using Moq;
using Reminder.Api.Controllers;
using Reminder.BusinessLogicLayer.Services;
using Reminder.DataAccessLayer.DataModels;
using Xunit;

namespace Reminder.Api.Tests
{
    public class ToDosControllerTest
    {
        [Fact]
        public void Add_ValidObjectPassed_Ok()
        {
            // Arrange
            ToDo objectToAdd = new ToDo
            {
                Created = new DateTime(1995, 10, 10, 11, 00, 00),
                Description = "Testing",
                Name = "TestName",
                IsDone = false
            };

            var mockRepo = new Mock<IToDoService>();

            //mockRepo.Setup(repo => repo.Add(objectToAdd)).Returns(objectToAdd);
            
            var mock = new Mock<IToDoService>();

            // Act
            

            // Assert
        }
    }
}
