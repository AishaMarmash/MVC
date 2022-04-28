using MySolution.Model;

namespace Project_Management_Application___API.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects();
        Project? GetProject(Guid id);
        bool ProjectExist(Guid projectId);
        bool ProjectExist(string projectName);
        IEnumerable<MyTask>? GetProjectTasks(Guid projectId);
        Task<Project> CreateProject(string projectName);
        MyTask? GetTask(Guid projectId,Guid taskId);
        Task<MyTask> UpdateTask(Guid projectId, MyTask UpdatedTask);
    }
}