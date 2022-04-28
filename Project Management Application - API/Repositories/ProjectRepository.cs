using MySolution.Model;
using Newtonsoft.Json;
using Services;
using Services.FilesManager;

namespace Project_Management_Application___API.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public static List<Project> _projects = new();
        public ProjectRepository()
        {
            Build();
        }
        public async void Build()
        {
            _projects = await GetProjects();
        }
        public async Task<List<Project>> GetProjects()
        {
            _projects = await FilesManager.GetProjects();
            return _projects;
        }
        public Project? GetProject(Guid id)
        {
            Project? project;
            if (_projects == null) return null;
            else
            {
                project = _projects.SingleOrDefault(p => p.Id == id);
            }
            return project;
        }
        public async Task<Project> CreateProject(string projectName)
        {
            List<Project>? projects;
            projects = await FilesManager.GetProjects();
            var newProject = ProjectFactory.BuildProject(projectName);
            if(projects==null)
            {
                projects = new();
            }
            projects.Add(newProject);
            Writer.WriteToFile(projects);
            return newProject;
        }
        public IEnumerable<MyTask>? GetProjectTasks(Guid projectId)
        {
            Project? project;
            project = _projects.Select(project => project).Where(project => project.Id == projectId).SingleOrDefault();
            if(project == null) 
                return null;
            else
                return project.Tasks;

        }
        public bool ProjectExist(string projectName)
        {
            var project = _projects.Select(project => project).Where(project => project.ProjectName.Equals(projectName)).SingleOrDefault();
            if (project == null)
                return false;
            else
                return true;
        }
        public bool ProjectExist(Guid projectId)
        {
            var project = _projects.Select(project => project).Where(project => project.Id == projectId).SingleOrDefault();
            if (project == null)
                return false;
            else
                return true;
        }
        public MyTask? GetTask(Guid projectId, Guid taskId)
        {
            var project = _projects.Select(project => project).Where(project => project.Id == projectId).SingleOrDefault();
            if (project == null)
            {
                return null;
            }
            var task = project.Tasks.Select(task => task).Where(task => task.Id == taskId).SingleOrDefault();
            return task;
        }
        public async Task<MyTask> UpdateTask(Guid projectId, MyTask UpdatedTask)
        {
            _projects = await FilesManager.GetProjects();
            MyTask newtask = UpdatedTask;
            foreach (var project in _projects)
            {
                foreach (var task in project.Tasks)
                {
                    if (task.Id == UpdatedTask.Id)
                    {
                        task.Status = UpdatedTask.Status;
                    }
                }
            }
            Writer.WriteToFile(_projects);
            return newtask;
        }
    }
}