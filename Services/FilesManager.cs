using MySolution.Model;
namespace Services.FilesManager
{
    public class FilesManager
    {
        static List<Project>? projects;
        public async static Task<List<Project>> GetProjects()
        {
            projects = await Reader.ReadDataFromFile("../data.txt");
            return projects;
        }
    }
}