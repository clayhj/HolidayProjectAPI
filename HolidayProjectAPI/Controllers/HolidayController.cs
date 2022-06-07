using HolidayProjectAPI.Models;
using HolidayProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace HolidayProjectAPI.Controllers
{
    [Route("holiday")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly ILogger<HolidayController> _logger;

        private readonly IHolidayService _holiday;

        public HolidayController(
            ILogger<HolidayController> logger,
            IHolidayService holidayService
            )
        {
            _logger = logger;
            _holiday = holidayService;
        }

        /// <summary>
        /// Returns Holiday if input date matches an existing US Federal Holiday
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Holiday<see cref="Holiday"/></returns>
        [HttpGet]
        public async Task<IActionResult> GetHoliday(string date)
        {
            try
            {
                _logger.LogInformation("GetHoliday start: {0}", date);
                Holiday result = await _holiday.Get(new object[] { date });
                string json = JsonConvert.SerializeObject(result);
                return Ok(json);
            }
            catch (Exception e)
            {
                _logger.LogError("GetHoliday: " + e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        //[HttpGet]
        //[Route("annualholidays")]
        //public IActionResult GetHoliday2(string year)
        //{
        //    string json = JsonConvert.SerializeObject();
        //    return Ok(json);
        //}
    }
}
