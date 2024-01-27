using DailyTaskDurationCalculator.Models.DTO;

namespace DailyTaskDurationCalculator.Services
{
    public interface ITaskDurationCalculatorService
    {
        TaskDurationResponseDTO CalculateEndDate(DateTime startDate, int numberOfDaysForCompletion);
    }
}
