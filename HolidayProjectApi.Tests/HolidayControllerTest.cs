using HolidayProjectApi.Tests.MockServices;
using HolidayProjectAPI.Controllers;
using HolidayProjectAPI.Models;
using HolidayProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

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
            var okResult = result as OkObjectResult;
            Assert.IsType<OkObjectResult>(okResult);

            string jsonReturn = okResult.Value as string;
            Holiday holiday = JsonConvert.DeserializeObject<Holiday>(jsonReturn);
            string expectedName = "New Years Day";
            Assert.Equal(expectedName, holiday.Name);
        }

        [Fact]
        public async void GetHolidaysByYear_ReturnsOK()
        {
            var result = await _controller.GetHolidaysByYear("2022");
            var okResult = result as OkObjectResult;
            Assert.IsType<OkObjectResult>(okResult);

            string jsonReturn = okResult.Value as string;
            List<Holiday> holidays = JsonConvert.DeserializeObject<List<Holiday>>(jsonReturn);
            int expectedCount = 2;
            Assert.Equal(expectedCount, holidays.Count);
        }
    }
}
