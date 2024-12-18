namespace TimeTrackerApi.Models
{
    public class ProjectDto
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsComplited { get; set; }
        public DateTime? DateComplited { get; set; }
        public int TimeSpent { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? ShowAddTimeBtn { get { return IsComplited; } }
        public int TotalTimePassed { get; set; } = 0;
        public List<TrackingTime> TrackingTimes { get; set; }
    }
}
