using AutoMapper;
using TaskManager.Models;
using TaskManager.Dtos;

namespace TaskManager.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<TaskItem, TaskResponseDto>()
                .ForMember(dest => dest.ProjectName,
                opt => opt.MapFrom(src => src.Project.Name));
            CreateMap<CreateTaskDto, TaskItem>();
            CreateMap<UpdateTaskDto, TaskItem>();

            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectResponseDto>();

        }
    }
}
