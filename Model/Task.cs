namespace MySolution.Model
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Contributor { get; set; }
        public string Status { get; set; }
        public Task(string title,string descriprion,string contributor)
        {
            this.Title = title;
            this.Description = descriprion;
            this.Contributor = contributor;
            Status = StatusType.ToDo.ToString();
        }
        public override string ToString()
        {
            return $"Task Title : {Title} ,its description : {Description} , assigned to {Contributor} and now its on {Status} status";
        }
    }
}