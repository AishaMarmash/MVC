using Microsoft.AspNetCore.Mvc;
using MySolution.Model;
using Services.FilesManager;

namespace Project_Management_Application_MVC.Controllers
{
    public class UsersController : Controller
    {
        private List<Project>? _projects = null;
        public UsersController()
        {
            ReadProjects();
        }
        public async void ReadProjects()
        {
            _projects = await FilesManager.GetProjects();
        }
        public async Task<IActionResult> UserDetails(string userName)
        {
            ViewBag.UserName = userName;
            var query = _projects.Select(p => p).Where(p => p.Contributors.Contains(userName)).ToList();
            return View(query);
        }
    }
}