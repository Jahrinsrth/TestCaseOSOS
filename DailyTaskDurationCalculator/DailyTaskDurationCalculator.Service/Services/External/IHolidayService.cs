using DailyTaskDurationCalculator.Models;

namespace DailyTaskDurationCalculator.Services.External
{
    public interface IHolidayService
    {
        List<Holiday> GetAllHolidays();
    }
}
