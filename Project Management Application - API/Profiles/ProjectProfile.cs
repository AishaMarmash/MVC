using MySolution.Model;
using AutoMapper;
using Project_Management_Application___API.Helpers;

namespace Project_Management_Application___API.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project,Models.ProjectDto>()
                .ForMember(
                dest => dest.ContributorsNames,
                opt => opt.MapFrom(dest => dest.Contributors.GetString(new string(""))));
            CreateMap<Models.ProjectForCreationDto, Project>();
            CreateMap<Project, Models.ProjectForResponse>();
        }
    }
}