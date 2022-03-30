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
            _projects = FilesManager.GetProjects();
        }
        public IActionResult Index()
        {
            List<MySolution.Model.Task> tasks= new();
            return View(tasks);
        }
        [HttpPost]
        public ActionResult Index(string ProjectName, string TaskName, string TaskStatus, string AssignedContributor)
        {
            TaskFilter taskfilter2 = new TaskFilter();
            if (TaskStatus != null)
                taskfilter2.TaskStatus = TaskStatus;
            if (TaskName != null)
                taskfilter2.TaskName = TaskName;
            if (ProjectName != null)
                taskfilter2.ProjectName = ProjectName;
            if (AssignedContributor != null)
                taskfilter2.AssignedContributor = AssignedContributor;
            List<MySolution.Model.Task> tasks = TasksFiltration.Search(_projects, taskfilter2);
            return View(tasks);
        }
    }
}
