namespace TimeTrackerApi.Data.Enteties
{
    public class Project
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsRemoved { get; set; }
        public DateTime? DateRemoved { get; set; }
        public bool? IsComplited { get; set; }
        public DateTime? DateComplited { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
