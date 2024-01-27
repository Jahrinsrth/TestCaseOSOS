namespace DailyTaskDurationCalculator.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfTheHoliday { get; set; }

        public Holiday() { }

        public Holiday(int id, string name, DateTime dateOfTheHoliday) 
        {
            Id = id;
            Name = name;
            DateOfTheHoliday = dateOfTheHoliday;
        }
    }
}
