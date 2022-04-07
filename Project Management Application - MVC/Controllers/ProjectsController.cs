using Microsoft.AspNetCore.Mvc;
using MySolution.Model;
using Services.FilesManager;
namespace Project_Management_Application_MVC.Controllers
{
    public class ProjectsController : Controller
    {
        private List<Project>? _projects = null;
        public ProjectsController()
        {
            ReadProjects(); 
        }
        public async void ReadProjects()
        {
            _projects = await FilesManager.GetProjects();
        }
        public IActionResult ProjectDetails(string projectName)
        {
            var pro = _projects.Select(p => p).Where(p => p.ProjectName == projectName).ToList()[0];
            return View(pro);
        }
    }
}
