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
                    Description = "",
                    Date = DateTime.Parse("2021-01-01"),
                    IsFloatingDate = false
                }
            };
        }

        public async Task<Holiday> Get(object[] keys)
        {
            return await Task.FromResult(_holidays[0]);
        }
    }
}