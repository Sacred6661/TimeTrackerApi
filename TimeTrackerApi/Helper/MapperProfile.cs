using AutoMapper;
using TimeTrackerApi.Data.Enteties;
using TimeTrackerApi.Models;

namespace TimeTrackerApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectFullDto>();
            CreateMap<FullProjectInfo, ProjectDto>();
            CreateMap<TimeTracker, TrackingTime>();
            CreateMap<TrackingTime, TimeTracker>();
            CreateMap<TrackingTime, TimeTracker>();
            CreateMap<AddTimeDto, TimeTracker>();
            CreateMap<AddTimeDto, TrackingTime>();
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
            CreateMap<Project, AddProjectDto>();
            CreateMap<AddProjectDto, Project>();


        }
    }
}
