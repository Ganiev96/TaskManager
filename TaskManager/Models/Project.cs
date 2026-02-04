using System.Text.Json.Serialization;

namespace TaskManager.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        [JsonIgnore]
        public List<TaskItem> Tasks { get; set; } = new();
    }
}
