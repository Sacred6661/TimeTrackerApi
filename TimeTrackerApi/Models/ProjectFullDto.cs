namespace TimeTrackerApi.Models
{
    public class ProjectFullDto
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsRemoved { get; set; }
        public DateTime? DateRemoved { get; set; }
        public bool? IsComplited { get; set; }
        public DateTime? DateComplited { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }
        public long TimeTrackerId { get; set; }
        public string TimeTrackerName { get; set; }
        public DateTime? StartTime { get; set; }
        public int TakenTime { get; set; }
    }
}
