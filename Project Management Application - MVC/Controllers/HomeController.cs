using Microsoft.AspNetCore.Mvc;
using MySolution.Model;
using Services.FilesManager;
namespace Project_Management_Application_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Project>? _projects = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _projects = FilesManager.GetProjects();
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(_projects);
        }
    }
}