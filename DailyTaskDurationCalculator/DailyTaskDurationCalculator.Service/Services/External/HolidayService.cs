using DailyTaskDurationCalculator.Models;
using Microsoft.Extensions.Logging;

namespace DailyTaskDurationCalculator.Services.External
{
    public class HolidayService(ILogger<HolidayService> logger) : IHolidayService
    {
        private readonly ILogger<HolidayService> _logger = logger;

        public List<Holiday> GetAllHolidays()
        {
            try
            {
                List<Holiday> holidays =
                [
                    new Holiday(1, "Poya Day", new DateTime(2024, 2, 2)),
                    new Holiday(2, "Thaipongal Day", new DateTime(2024, 2, 7)),
                ];

                return holidays;
            }
            catch (Exception ex) 
            {
                _logger.LogError("Error in HolidayService {exception}", ex.ToString());
                throw;
            }
        }
    }
}
