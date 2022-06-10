using HolidayProjectAPI.Models;
using HolidayProjectAPI.Services;

namespace HolidayProjectApi.Tests.MockServices
{
    public class MockHolidayService : IHolidayService
    {
        private readonly List<Holiday> _holidays;
        public MockHolidayService()
        {
            _holidays = new List<Holiday>()
            {
                new Holiday()
                {
                    Name = "New Years Day",
                    Description = "New Year's Day is a festival observed in most of the world on 1 January...",
                    Date = DateTime.Parse("2021-01-01"),
                    IsFloatingDate = false
                },
                new Holiday()
                {
                    Name = "Independence Day",
                    Description = "Celebrates the adoption of the Declaration of Independence from British rule...",
                    Date = DateTime.Parse("2021-07-04"),
                    IsFloatingDate = false
                }
            };
        }

        public async Task<Holiday> Get(object[] keys)
        {
            return await Task.FromResult(_holidays[0]);
        }

        public async Task<IEnumerable<Holiday>> GetMany(object[] keys)
        {
            return await Task.FromResult(_holidays);
        }
    }
}