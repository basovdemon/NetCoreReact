using Microsoft.AspNetCore.Mvc;
using NetCoreReact.Controllers;
using NetCoreReact.Core.Intefaces;
using NetCoreReact.Core.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Api
{
    public class EventControllerTests
    {
        [Fact]
        public async void GetEvent_ReturnsNotFoundResult_WhenEventIsNotFound()
        {
            // Arrange
            var eventService = Substitute.For<IEventService>();
            var eventController = new EventController(eventService);

            var eventId = Guid.NewGuid();
            eventService.GetEventAsync(eventId).Returns(Task.FromResult<EventModel>(null));

            // Act
            var result = await eventController.GetEventAsync(eventId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async void GetEvent_ReturnsOkResult_WhenEventIsFound()
        {
            // Arrange
            var eventService = Substitute.For<IEventService>();
            var eventController = new EventController(eventService);

            var evnt = new EventModel
            {
                Id = Guid.NewGuid(),
                Title = "Test title",
                Description = "Test description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                AllDay = false,
                Place = "Skype"
            };

            eventService.GetEventAsync(evnt.Id).Returns(Task.FromResult<EventModel>(evnt));

            // Act
            var result = await eventController.GetEventAsync(evnt.Id);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
