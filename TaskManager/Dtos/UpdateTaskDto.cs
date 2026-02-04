using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dtos
{
    public class UpdateTaskDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
        [Range(1, int.MaxValue)]
        public int ProjectId { get; set; }
    }
}
