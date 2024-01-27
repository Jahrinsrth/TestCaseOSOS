using DailyTaskDurationCalculator.Models.DTO;
using DailyTaskDurationCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace DailyTaskDurationCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTaskCalculationController(ITaskDurationCalculatorService taskDurationCalculator,
        ILogger<DailyTaskCalculationController> logger) : ControllerBase
    {
        private readonly ITaskDurationCalculatorService _taskDurationCalculator = taskDurationCalculator;
        private readonly ILogger<DailyTaskCalculationController> _logger = logger;

        [HttpPost]
        public IActionResult CalculateEndDate([FromBody] TaskDurationRequestDTO taskDurationRequestDTO)
        {
            if (taskDurationRequestDTO is null)
            {
                return BadRequest();
            }

            _logger.LogInformation(
                "--- CalculateEndDate inputs {startDate} : {NumberOfDaysForCompletion} ---",
                taskDurationRequestDTO.StartDate,
                taskDurationRequestDTO.NumberOfDaysForCompletion);

            var taskDurationResponseDTO = _taskDurationCalculator.CalculateEndDate(taskDurationRequestDTO.StartDate, taskDurationRequestDTO.NumberOfDaysForCompletion);
            return Ok(taskDurationResponseDTO);
        }
    }
}
