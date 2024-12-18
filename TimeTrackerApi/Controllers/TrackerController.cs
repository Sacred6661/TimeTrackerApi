using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TimeTrackerApi.Models;
using TimeTrackerApi.Services.Interfaces;

namespace TimeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly ITracker _tracker;
        public TrackerController(ITracker tracker)
        {
            _tracker = tracker;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<ProjectDto>>> GetAllProjects()
        {
            var projects = await _tracker.GetProjects();

            return projects;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<ResponseModel<ProjectDto>> GetProject(int projectId)
        {
            if (projectId == 0)
            {
                return new ResponseModel<ProjectDto>
                {
                    IsError = true,
                    ErrorMessage = "Wrong project id"
                };
            }
            var projects = _tracker.GetProject(projectId);

            if (projects == null)
                return new ResponseModel<ProjectDto>
                {
                    IsError = true,
                    ErrorMessage = "Wrong project id"
                };

            return new ResponseModel<ProjectDto>
            {
                Data = projects
            };
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<ResponseModel<TrackingTime>> AddTrackingTime([FromBody] AddTimeDto addTime)
        {
            var getTrackerItem = _tracker.GetProject(addTime.ProjectId);

            if(getTrackerItem == null)
            {
                return new ResponseModel<TrackingTime>
                {
                    IsError = true,
                    ErrorMessage = "There is no item to add time"
                };

            }

            if (addTime?.TakenTime == null || addTime?.TakenTime < 15)
            {
                return new ResponseModel<TrackingTime>
                {
                    IsError = true,
                    ErrorMessage = "Bad taken time. It should be more than 15"
                };
            }

            var addTrackingTime = _tracker.AddTime(addTime);
            if (addTrackingTime == null)
                return new ResponseModel<TrackingTime>
                {
                    IsError = true,
                    ErrorMessage = "Error on adding tracking time"
                };





            return new ResponseModel<TrackingTime>
            {
                Data = addTrackingTime
            };
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<ProjectDto> AddProject(AddProjectDto addProject)
        {
            var project = _tracker.AddProject(addProject);
            return project;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<ProjectDto> RemoveProject([FromBody]RemoveProjectDto removeProject)
        {
            var project = _tracker.RemoveProject(removeProject);
            return project;
        }

        [HttpPost]
        [Route("[action]")]
        public ProjectDto CompleteProject(CompleteProjectDto completeProject)
        {
            var test = _tracker.CompleteProject(completeProject);
            return test;
        }
        //[HttpGet]
        //[Route("[action]")]
        //public Task<List<ProjectFullDto>> GetAllProjects()
        //{
        //    _tracker.
        //}
    }
}
