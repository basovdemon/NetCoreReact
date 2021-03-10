using NetCoreReact.Core.Services;
using NetCoreReact.Data.Entities;
using NetCoreReact.Data.Intefaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Core
{
    public class EventServiceTests
    {
        [Fact]
        public async void CreateEvent_Throws_ArgumentNullException_When_EventModel_IsNull()
        {
            // Arrange
            var eventRepository = Substitute.For<IEventRepository>();
            var eventService = new EventService(eventRepository);

            // Act -> Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => eventService.CreateEventAsync(null));
        }

        [Fact]
        public async void GetEvent_Maps_Model_Correctly()
        {
            // Arrange
            var eventRepository = Substitute.For<IEventRepository>();
            var eventService = new EventService(eventRepository);

            var entity = new NetCoreReact.Data.Entities.Event
            {
                Id = Guid.NewGuid(),
                Title = "Test title",
                Description = "Test description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                AllDay = false,
                Place = "Skype"
            };

            eventRepository.FindAsync(entity.Id).Returns(entity);

            // Act 
            var eventModel = await eventService.GetEventAsync(entity.Id);

            // Assert
            Assert.Equal(entity.Id, eventModel.Id);
            Assert.Equal(entity.Title, eventModel.Title);
            Assert.Equal(entity.Description, eventModel.Description);
            Assert.Equal(entity.StartDate, eventModel.StartDate);
            Assert.Equal(entity.EndDate, eventModel.EndDate);
            Assert.Equal(entity.AllDay, eventModel.AllDay);
            Assert.Equal(entity.Place, eventModel.Place);
        }
    }
}
