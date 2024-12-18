namespace TimeTrackerApi.Models
{
    public class AddProjectDto
    {
        public string ProjectName { get; set; }
        public string DateStartedString { get; set; }
        public string DateEndString { get; set; }
    }
}
