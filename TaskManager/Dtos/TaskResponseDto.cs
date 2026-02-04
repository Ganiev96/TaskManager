namespace TaskManager.Dtos
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
