namespace MySolution.Model
{
    public class ProjectFactory
    {
        public static Project BuildProject(string projectName, List<string> contributors, List<Task> tasks)
        {
            Project project = new(projectName, contributors, tasks);
            return project;
        }
        public static Project BuildProject(string projectName, List<string> contributors)
        {
            Project project = new(projectName, contributors);
            return project;
        }
        public static Project BuildProject(string projectName, List<Task> tasks)
        {
            Project project = new(projectName, tasks);
            return project;
        }
        public static Project BuildProject(string projectName)
        {
            Project project = new(projectName);
            return project;
        }
    }
}
