using Microsoft.AspNetCore.Mvc;
using MySolution.Model;
using Project_Management_Application___API.Repositories;
using Newtonsoft.Json;
using Services.FilesManager;
using AutoMapper;
using Project_Management_Application___API.Models;
using Services;
using Microsoft.AspNetCore.JsonPatch;

namespace Project_Management_Application___API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectsRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository Repository, IMapper mapper)
        {
            _projectsRepository = Repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectsRepository.GetProjects();
            return Ok(_mapper.Map<IEnumerable<ProjectDto>>(projects));
        }

        [HttpGet("{projectId}")]
        public IActionResult GetProject(Guid projectId)
        {
            var project = _projectsRepository.GetProject(projectId);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectForCreationDto project)
        {
            if (project.ProjectName == null)
            {
                throw new Exception("ProjectName Field is required");
            }
            if(project.ProjectName.Length == 0)
            {
                throw new Exception("ProjectName Field is required");
            }
            if (_projectsRepository.ProjectExist(project.ProjectName))
            {
                throw new Exception("Project is exist");
            }
            Project newProject = _projectsRepository.CreateProject(project.ProjectName).Result;
            return Ok(_mapper.Map<ProjectForResponse>(newProject));
        }
    }
}