using DailyTaskDurationCalculator.Models;
using DailyTaskDurationCalculator.Services;
using DailyTaskDurationCalculator.Services.External;
using Microsoft.Extensions.Logging;
using Moq;

namespace DailyTaskDurationCalculator.Unit.Tests
{
    public class TaskDurationCalculatorServiceTests
    {
        private readonly Mock<ILogger<TaskDurationCalculatorService>> _mockLogger;
        private readonly Mock<IHolidayService> _mockHolidayService;

        public TaskDurationCalculatorServiceTests()
        {
            _mockLogger = new Mock<ILogger<TaskDurationCalculatorService>>();
            _mockHolidayService = new Mock<IHolidayService>();
        }

        #region Test Cases

        [Test]
        public void CalculateEndDate_Assuming_HolidaysAndWeekends_Between_StartDateAndEndDate_ReturnsCorrectEndDate()
        {
            // Arrange
            var taskDurationCalculatorService = ArrangeTestData();

            // Act
            DateTime startDate = new DateTime(2024, 1, 31);
            int numberOfDaysForCompletion = 3;
            var result = taskDurationCalculatorService.CalculateEndDate(startDate, numberOfDaysForCompletion);

            // Assert
            Assert.That(result.EndDate, Is.EqualTo(new DateTime(2024, 2, 5)));
        }

        [Test]
        public void CalculateEndDate_Assuming_NoHolidaysAndWeekends_Between_StartDateAndEndDate_ReturnsCorrectEndDate()
        {
            // Arrange
            var taskDurationCalculatorService = ArrangeTestData();

            // Act
            DateTime startDate = new DateTime(2024, 1, 8);
            int numberOfDaysForCompletion = 5;
            var result = taskDurationCalculatorService.CalculateEndDate(startDate, numberOfDaysForCompletion);

            // Assert
            Assert.That(result.EndDate, Is.EqualTo(new DateTime(2024, 1, 12)));
        }

        [Test]
        public void CalculateEndDate_ReturnsWrongEndDate()
        {
            // Arrange
            var taskDurationCalculatorService = ArrangeTestData();

            // Act
            DateTime startDate = new DateTime(2024, 1, 2);
            int numberOfDaysForCompletion = 5;
            var result = taskDurationCalculatorService.CalculateEndDate(startDate, numberOfDaysForCompletion);

            // Assert
            Assert.That(result.EndDate, Is.Not.EqualTo(new DateTime(2024, 1, 7)));
        }

        #endregion Test Cases

        #region Arrange Test Data

        private TaskDurationCalculatorService ArrangeTestData()
        {
            _mockHolidayService.Setup(x => x.GetAllHolidays()).Returns(GetAllHolidays);
            var taskDurationCalculatorService = new TaskDurationCalculatorService(_mockHolidayService.Object, _mockLogger.Object);
            return taskDurationCalculatorService;
        }

        #endregion Arrange Test Data

        #region Private Methods

        private List<Holiday> GetAllHolidays()
        {
            List<Holiday> holidays =
            [
                new Holiday(1, "Poya Day", new DateTime(2024, 2, 2)),
            ];

            return holidays;
        }

        #endregion Private Methods
    }
}
