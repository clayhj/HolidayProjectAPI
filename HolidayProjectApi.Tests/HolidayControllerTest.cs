using HolidayProjectApi.Tests.MockServices;
using HolidayProjectAPI.Controllers;
using HolidayProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace HolidayProjectApi.Tests
{
    public class HolidayControllerTest
    {
        private readonly HolidayController _controller;
        private readonly IHolidayService _service;

        public HolidayControllerTest()
        {
            _service = new MockHolidayService();
            _controller = new HolidayController(new NullLogger<HolidayController>(), _service);
        }

        [Fact]
        public async void GetHoliday_ReturnsOK()
        {
            var result = await _controller.GetHoliday("2021-01-01");
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
    }
}
