using MySolution.Model;
namespace Services.FilesManager
{
    public class Reader
    {
        static List<Project>? projects;
        public static List<Project> ReadDataFromFile(string textFile)
        {
            projects = new List<Project>();
            List<MySolution.Model.Task> projectTasks = new();
            List<string> projectContributors = new();
            string[] taskInfo;
            string[] lines = File.ReadAllLines(textFile);
            int LineIndex = 1;
            int projectsNum = int.Parse(lines[0]);
            for (int i = 0; i < projectsNum; i++)
            {
                string[] projectInfo = lines[LineIndex++].Split(" ");
                string projectName = projectInfo[0];
                for (int j = 0; j < int.Parse(projectInfo[1]); j++)
                {
                    projectContributors.Add(lines[LineIndex++]);
                }
                for (int k = 0; k < int.Parse(projectInfo[2]); k++)
                {
                    taskInfo = lines[LineIndex++].Split(",");
                    projectTasks.Add(new MySolution.Model.Task(taskInfo[0], taskInfo[1], taskInfo[2]));
                }
                Project project = ProjectFactory.BuildProject(projectName, projectContributors, projectTasks);
                projects.Add(project);
                projectContributors.Clear();
                projectTasks.Clear();
            }
            return projects;
        }
    }
}