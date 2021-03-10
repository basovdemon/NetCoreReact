using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using NetCoreReact.Data;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCoreReact.Data.Repositories;

namespace Tests.Data
{
    public class EventRepositoryTests
    {
        private DbContextOptions<EventsAppDbContext> _contextOptions;

        public EventRepositoryTests()
        {
            _contextOptions = new DbContextOptionsBuilder<EventsAppDbContext>().UseInMemoryDatabase("EventDb").Options;
        }

        [Fact]
        public async void Can_Add_Event()
        {
            // Arrange
            var testEvent = new NetCoreReact.Data.Entities.Event
            {
                Id = Guid.NewGuid(),
                Title = "Test title",
                Description = "Test description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                AllDay = false,
                Place = "Skype"
            };

            // Act
            using (var context = new EventsAppDbContext(_contextOptions))
            {
                var repository = new EventRepository(context);
                var evnt = await repository.AddAsync(testEvent);
            }

            // Assert
            using (var context = new EventsAppDbContext(_contextOptions))
            {
                var evnt = await context.Events.FindAsync(testEvent.Id);

                Assert.Equal(testEvent.Id, evnt.Id);
                Assert.Equal(testEvent.Title, evnt.Title);
                Assert.Equal(testEvent.Description, evnt.Description);
                Assert.Equal(testEvent.StartDate, evnt.StartDate);
                Assert.Equal(testEvent.EndDate, evnt.EndDate);
                Assert.Equal(testEvent.AllDay, evnt.AllDay);
                Assert.Equal(testEvent.Place, evnt.Place);
            }
        }

        [Fact]
        public async void Can_Update_Event()
        {
            // Arrange
            var testEvent = new NetCoreReact.Data.Entities.Event
            {
                Id = Guid.NewGuid(),
                Title = "Test title",
                Description = "Test description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1),
                AllDay = false,
                Place = "Skype"
            };

            using (var context = new EventsAppDbContext(_contextOptions))
            {
                await context.Events.AddAsync(testEvent);
                await context.SaveChangesAsync();
            }

            var updatedEvent = new NetCoreReact.Data.Entities.Event
            {
                Id = testEvent.Id,
                Title = "updated test title",
                Description = "updated test description",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(1).AddHours(1),
                AllDay = false,
                Place = "Skype"
            };


            // Act
            using (var context = new EventsAppDbContext(_contextOptions))
            {
                var repository = new EventRepository(context);
                var evnt = await repository.UpdateAsync(updatedEvent);
            }

            // Assert
            using (var context = new EventsAppDbContext(_contextOptions))
            {
                var evnt = await context.Events.FindAsync(testEvent.Id);

                Assert.Equal(testEvent.Id, evnt.Id);
                Assert.Equal(updatedEvent.Title, evnt.Title);
                Assert.Equal(updatedEvent.Description, evnt.Description);
                Assert.Equal(updatedEvent.StartDate, evnt.StartDate);
                Assert.Equal(updatedEvent.EndDate, evnt.EndDate);
                Assert.Equal(updatedEvent.AllDay, evnt.AllDay);
                Assert.Equal(updatedEvent.Place, evnt.Place);
            }
        }
    }
}
