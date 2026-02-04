using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dtos
{
    public class CreateTaskDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int ProjectId { get; set; }
    }
}
