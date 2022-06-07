namespace HolidayProjectAPI.Models
{
    public class Holiday
    {
        /// <summary>
        /// Holiday Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Holiday Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Holiday Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Whether Holiday is a floating date or not
        /// </summary>
        public bool IsFloatingDate { get; set; }
    }
}
