using MySolution.Model;
namespace Services.FilesManager
{
    public class FilesManager
    {
        static List<Project>? projects;
        public static List<Project> GetProjects()
        {
            projects = Reader.ReadDataFromFile("../data.txt");
            return projects;
        }
    }
}