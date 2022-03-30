using Microsoft.AspNetCore.Mvc;
using MySolution.Model;
using Services.FilesManager;
using Services.Filtration;

namespace Project_Management_Application_MVC.Controllers
{
    public class SearchController : Controller
    {
        private List<Project>? _projects = null;
        public SearchController()
        {
            ReadProjects();
        }
        public async void ReadProjects()
        {
            _projects = await FilesManager.GetProjects();
        }
        public IActionResult Index()
        {
            List<MySolution.Model.Task> tasks= new();
            return View(tasks);
        }
        [HttpPost]
        public ActionResult Index(string ProjectName, string TaskName, string TaskStatus, string AssignedContributor)
        {
            TaskFilter taskfilter = new TaskFilter();
            if (TaskStatus != null)
                taskfilter.TaskStatus = TaskStatus;
            if (TaskName != null)
                taskfilter.TaskName = TaskName;
            if (ProjectName != null)
                taskfilter.ProjectName = ProjectName;
            if (AssignedContributor != null)
                taskfilter.AssignedContributor = AssignedContributor;
            List<MySolution.Model.Task> tasks = TasksFiltration.Search(_projects, taskfilter);
            return View(tasks);
        }
    }
}
