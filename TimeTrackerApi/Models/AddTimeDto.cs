namespace TimeTrackerApi.Models
{
    public class AddTimeDto
    {
        public string TimeTrackerName { get; set; }
        public int TakenTime { get; set; }
        public int ProjectId { get; set; }
    }
}
