using MySolution.Model;
namespace Services.Filtration
{
    public class TasksFiltration
    {
        public TasksFiltration ()
        {
        }
        public static List<MySolution.Model.MyTask>? Search(List<Project>? projects, TaskFilter? filter)
        {
            if (projects == null)
            {
                throw new Exception();
            }
            else if(filter==null)
            {
                throw new Exception();
            }
            else
            {
                var searchQuery = projects.Select(p => p).Where(p => p.ProjectName.Contains(filter.ProjectName))
                          .SelectMany(pros => pros.Tasks).Where(task => task.Title.Contains(filter.TaskName))
                          .Select(task => task).Where(task => task.Status.ToString().Contains(filter.TaskStatus.ToString()))
                          .Select(tasks => tasks).Where(task => task.Contributor.Contains(filter.AssignedContributor));
                return searchQuery.ToList();

            }
        }
    }
}