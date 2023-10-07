namespace TravelerAppService.Models
{
    public class TrainSchedule
    {
       
            public string Id { get; set; } 
            public string DepartureStation { get; set; }
            public string ArrivalStation { get; set; }
            public DateTime DepartureTime { get; set; }
            public DateTime ArrivalTime { get; set; }
            public decimal Price { get; set; }
            public int AvailableSeats { get; set; }
       
    }
}
