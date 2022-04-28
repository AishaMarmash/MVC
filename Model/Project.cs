namespace MySolution.Model
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public List<string> Contributors { get; set; }
        public List<MyTask> Tasks { get; set; }
        public Project() 
        {
        }
        public Project(string name)
        {
            this.Id = Guid.NewGuid();
            this.ProjectName = name;
            this.Contributors = new List<string>();
            this.Tasks = new List<MyTask>();
        }
        public Project(string name, List<string> contributors)
        {
            this.Id = Guid.NewGuid();
            this.ProjectName = name;
            this.Contributors = contributors.ToList();
            this.Tasks = new List<MyTask>();
        }
        public Project(string name, List<MyTask> tasks)
        {
            this.Id = Guid.NewGuid();
            this.ProjectName = name;
            this.Contributors = new List<string>();
            this.Tasks = tasks.ToList();
        }
        public Project(string name, List<string> contributors, List<MyTask> tasks)
        {
            this.Id = Guid.NewGuid();
            this.ProjectName = name;
            Contributors = contributors.ToList();
            Tasks = tasks.ToList();
        }
        public void Addcontributor(string username)
        {
            Contributors.Add(username);
        }
        public void Add_Task(MyTask task)
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