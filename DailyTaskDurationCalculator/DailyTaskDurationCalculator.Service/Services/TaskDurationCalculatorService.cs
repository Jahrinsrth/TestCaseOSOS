using DailyTaskDurationCalculator.Models.DTO;
using DailyTaskDurationCalculator.Services.External;
using Microsoft.Extensions.Logging;

namespace DailyTaskDurationCalculator.Services
{
    public class TaskDurationCalculatorService(IHolidayService holidayService, ILogger<TaskDurationCalculatorService> logger) 
         : ITaskDurationCalculatorService
    {
        private readonly IHolidayService _holidayService = holidayService;
        private readonly ILogger<TaskDurationCalculatorService> _logger = logger;

        #region Public methods

        public TaskDurationResponseDTO CalculateEndDate(DateTime startDate, int numberOfDaysForCompletion)
        {
            try
            {
                TaskDurationResponseDTO taskDurationResponseDTO = new();
                int remainingDays = numberOfDaysForCompletion;
                DateTime currentDate = startDate;

                while (remainingDays > 0)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday 
                         && !CheckCurrentDateIsPublicHoliday(currentDate))
                    {
                        remainingDays--;
                    }

                    currentDate = currentDate.AddDays(1);
                }

                currentDate = currentDate.AddDays(-1);
                taskDurationResponseDTO.EndDate = currentDate;

                return taskDurationResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in TaskDurationCalculatorService {exception}", ex.ToString());
                throw;
            }
        }

        #endregion Public Methods

        #region Private methods
        private bool CheckCurrentDateIsPublicHoliday(DateTime currentDate) 
        {
            return _holidayService.GetAllHolidays().Exists(x => x.DateOfTheHoliday.Date == currentDate.Date);
        }

        #endregion Private methods
    }
}
