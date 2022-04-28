using MySolution.Model;
using Newtonsoft.Json;

namespace Services
{
    public class Writer
    {
        public static void WriteToFile(List<Project> data)
        {
            string fileText = JsonConvert.SerializeObject(data);
            File.WriteAllText("ProjectsData.json", fileText);
        }
    }
}