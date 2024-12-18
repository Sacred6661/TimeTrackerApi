namespace TimeTrackerApi.Models
{
    public class TrackingTime
    {
        public long TimeTrackerId { get; set; }
        public string TimeTrackerName { get; set; }
        public long ProjectId { get; set; }
        public DateTime? StartTime { get; set; }
        public int TakenTime { get; set; }
    }
}
