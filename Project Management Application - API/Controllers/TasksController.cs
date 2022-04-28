using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project_Management_Application___API.Models;
using Project_Management_Application___API.Repositories;

namespace Project_Management_Application___API.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IProjectRepository _projectsRepository;
        private readonly IMapper _mapper;

        public TasksController(IProjectRepository Repository, IMapper mapper)
        {
            _projectsRepository = Repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProjectTasks(Guid projectId)
        {
            if(!_projectsRepository.ProjectExist(projectId))
            {
                return NotFound();
            }
            var tasks = _projectsRepository.GetProjectTasks(projectId);
            return Ok(tasks);
        }
        [HttpGet("{taskId}")]
        public IActionResult GetProjectTask(Guid projectId, Guid taskId)
        {
            if (_projectsRepository.ProjectExist(projectId) == false)
            {
                return NotFound();
            }
            var task = _projectsRepository.GetTask(projectId, taskId);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPatch("{taskId}")]
        public IActionResult UpdateTaskStatus(Guid projectId, Guid taskId, JsonPatchDocument<MyTaskForUpdateDto> patchDocument)
        {
            var taskFromRepo = _projectsRepository.GetTask(projectId, taskId);
            if(patchDocument == null)
            {
                return BadRequest();
            }
            if(taskFromRepo == null)
            {
                return NotFound();
            }
            MyTaskForUpdateDto taskToPatch = _mapper.Map<MyTaskForUpdateDto>(taskFromRepo);
            patchDocument.ApplyTo(taskToPatch);
            _mapper.Map(taskToPatch,taskFromRepo);
            _projectsRepository.UpdateTask(projectId, taskFromRepo);
            return Ok(taskFromRepo);
        }

    }
}
