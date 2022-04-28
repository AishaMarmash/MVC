namespace MySolution.Model
{
    public class MyTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Contributor { get; set; }
        public StatusType Status { get; set; }
        public MyTask(string title,string descriprion,string contributor)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = descriprion;
            this.Contributor = contributor;
            Status = StatusType.ToDo;
        }
        public override string ToString()
        {
            return $"Task Title : {Title} ,its description : {Description} , assigned to {Contributor} and now its on {Status} status";
        }
    }
}