using DailyTaskDurationCalculator.Services.External;
using DailyTaskDurationCalculator.Services;

namespace DailyTaskDurationCalculator.Infrastructure.Extensions
{
    public static class RegisterDependencies
    {
        public static void AddAppDependencies(this IServiceCollection services)
        {
            services.AddTransient<ITaskDurationCalculatorService, TaskDurationCalculatorService>();
            services.AddTransient<IHolidayService, HolidayService>();
        }
    }
}
