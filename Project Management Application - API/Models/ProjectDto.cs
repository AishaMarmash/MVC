using MySolution.Model;

namespace Project_Management_Application___API.Models
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string? ProjectName { get; set; }
        public String? ContributorsNames { get; set; }
        public List<MyTask>? Tasks { get; set; }
    }
}