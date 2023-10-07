namespace TravelerAppService.Models
{
    public class Train
    {
        public string Id { get; set; } 
        public string TrainName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } 
        public List<TrainSchedule> Schedules { get; set; } 
    }
}
