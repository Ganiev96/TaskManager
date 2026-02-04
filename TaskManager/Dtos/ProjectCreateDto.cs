using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dtos;

public class ProjectCreateDto
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = null!;
}
