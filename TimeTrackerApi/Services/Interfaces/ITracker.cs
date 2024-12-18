using TimeTrackerApi.Models;

namespace TimeTrackerApi.Services.Interfaces
{
    public interface ITracker
    {
        public Task<List<ProjectDto>> GetProjects();
        public Task<ProjectDto> GetProject(long projectId);
        public TrackingTime AddTime(AddTimeDto addTime);
        public ProjectDto AddProject(AddProjectDto project);
        public ProjectDto RemoveProject(RemoveProjectDto project);
        public ProjectDto CompleteProject(CompleteProjectDto project);


    }
}
