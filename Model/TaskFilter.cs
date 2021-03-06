namespace MySolution.Model
{
    public class TaskFilter
    {
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string AssignedContributor { get; set; }

        public TaskFilter()
        {
            this.ProjectName = "";
            this.TaskName = "";
            this.TaskStatus = "";
            this.AssignedContributor = "";
        }
        public TaskFilter(string ProjectName, string TaskName, string TaskStatus ,string AssignedContributor)
        {
            this.ProjectName = ProjectName;
            this.TaskName = TaskName;    
            this.TaskStatus = TaskStatus;
            this.AssignedContributor = AssignedContributor;
        }
    }
}
