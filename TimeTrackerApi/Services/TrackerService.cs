using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeTrackerApi.Data;
using TimeTrackerApi.Data.Enteties;
using TimeTrackerApi.Models;
using TimeTrackerApi.Services.Interfaces;

namespace TimeTrackerApi.Services
{
    public class TrackerService : ITracker
    {
        private readonly IMapper _mapper;
        private readonly TimeTrackerDbContext _dbContext;

        public TrackerService(IMapper mapper, TimeTrackerDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<List<ProjectDto>> GetProjects()
        {
            var projects = await _dbContext.Projects
                .Where(p => p.IsRemoved == false || p.IsRemoved == null)?.ToListAsync();

            var result = _mapper.Map<List<ProjectDto>>(projects);

            return result;
        }

        public ProjectDto GetProject(long projectId)
        {
            var project = _dbContext.Projects
                .Where(p => (p.IsRemoved == false || p.IsRemoved == null) && p.ProjectId == projectId)
                ?.FirstOrDefault();
            var trackers = _dbContext
                .TimeTrackers.Where(p => p.ProjectId == projectId).ToList();

            var query =  (from p in _dbContext.Projects
                               join t in _dbContext.TimeTrackers
                                  on p.ProjectId equals t.ProjectId
                               where p.ProjectId == projectId
                               select new FullProjectInfo
                               {
                                   ProjectId = p.ProjectId,
                                   ProjectName = p.ProjectName,
                                   DateComplited = p.DateComplited,
                                   IsComplited = p.IsComplited,
                                   TimeTrackerId = t.TimeTrackerId,
                                   TimeTrackerName = t.TimeTrackerName,
                                   StartTime = t.StartTime,
                                   DateEnd = p.DateEnd,
                                   TakenTime = t.TakenTime,
                                   IsRemoved = p.IsRemoved,
                                   DateStarted = p.DateStarted,
                                   DateRemoved = p.DateRemoved,
                                   TotalTimePassed = 0
                               })?.FirstOrDefault();

            if (query == null)
                query = (from p in _dbContext.Projects
                               where p.ProjectId == projectId
                               select new FullProjectInfo
                               {
                                   ProjectId = p.ProjectId,
                                   ProjectName = p.ProjectName,
                                   DateComplited = p.DateComplited,
                                   IsComplited = p.IsComplited,
                                   DateEnd = p.DateEnd,
                                   IsRemoved = p.IsRemoved,
                                   DateStarted = p.DateStarted,
                                   DateRemoved = p.DateRemoved,
                                   TotalTimePassed = 0
                               })?.FirstOrDefault();

            List<TrackingTime> allTrackers = new();

            foreach (var tracker in trackers)
            {
                var time = _mapper.Map<TrackingTime>(tracker);
                query.TrackingTimes.Add(time);
                query.TotalTimePassed += tracker.TakenTime;
            }

            var result = _mapper.Map<ProjectDto>(query);
            return result;
        }

        public TrackingTime AddTime(AddTimeDto addTime)
        {
            TrackingTime result = null;
            try
            {
                var trackingTime = _mapper.Map<TimeTracker>(addTime);
                trackingTime.ProjectId = addTime.ProjectId;

                _dbContext.TimeTrackers.Add(trackingTime);
                _dbContext.SaveChanges();

                result = _mapper.Map<TrackingTime>(trackingTime);
            }
            catch(Exception ex)
            {
                return null;
            }


            return result;
        }


        public ProjectDto AddProject(AddProjectDto project)
        {
            var prj = _mapper.Map<Project>(project);
            prj.DateStarted = DateTime.Parse(project.DateStartedString);
            prj.DateEnd = DateTime.Parse(project.DateEndString);

            _dbContext.Projects.Add(prj);
            _dbContext.SaveChanges();

            var result = _mapper.Map<ProjectDto>(prj);
            return result;
        }

        public ProjectDto RemoveProject(RemoveProjectDto project)
        {
            var prj = _dbContext.Projects.Where(p => p.ProjectId == project.ProjectId).FirstOrDefault();
            prj.IsRemoved = true;
            prj.DateRemoved = DateTime.Now;

            _dbContext.SaveChanges();

            var result = _mapper.Map<ProjectDto>(prj);

            return result;
        }

        public ProjectDto CompleteProject(CompleteProjectDto project)
        {
            var prj = _dbContext.Projects.Where(p => p.ProjectId == project.ProjectId).FirstOrDefault();

            prj.IsComplited = true;
            prj.DateComplited = DateTime.Now;

            _dbContext.SaveChanges();

            var result = _mapper.Map<ProjectDto>(prj);

            return result;

        }


    }
}
