namespace MySolution.Model
{
    public class Project
    {
        public string ProjectName { get; set; }
        public List<string> Contributors { get; set; }
        public List<Task> Tasks { get; set; }
        public Project() { }
        public Project(string name)
        {
            this.ProjectName = name;
            this.Contributors = new List<string>();
            this.Tasks = new List<Task>();
        }
        public Project(string name, List<string> contributors)
        {
            this.ProjectName = name;
            this.Contributors = contributors.ToList();
            this.Tasks = new List<Task>();
        }
        public Project(string name, List<Task> tasks)
        {
            this.ProjectName = name;
            this.Contributors = new List<string>();
            this.Tasks = tasks.ToList();
        }
        public Project(string name, List<string> contributors, List<Task> tasks)
        {
            this.ProjectName = name;
            Contributors = contributors.ToList();
            Tasks = tasks.ToList();
        }
        public void Addcontributor(string username)
        {
            Contributors.Add(username);
        }
        public void Add_Task(Task task)
        {
            Tasks.Add(task);
        }
        public override string ToString()
        {
            return $"project name : {ProjectName}{Environment.NewLine}" +
                $"it has {Contributors.Count} contributors and they are :{ string.Join(", ", Contributors)}{Environment.NewLine}" +
                $"It consists of multiple tasks:{Environment.NewLine} { string.Join("\n ", Tasks)}";
        }
    }
}