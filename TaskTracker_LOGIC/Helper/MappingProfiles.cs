using AutoMapper;
using TaskTracker_DAL.Entities;
using TaskTracker_LOGIC.Services.ViewModels.Project;
using TaskTracker_LOGIC.Services.ViewModels.TrackingTask;

namespace TaskTracker_LOGIC.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Project, CreateProjectVM>();
            CreateMap<Project, GetProjectByIdVM>();
            CreateMap<Project, GetProjectsVM>();
            CreateMap<Project, UpdateProjectVM>();
            CreateMap<Project, UpdateProjectStatusVM>();
            CreateMap<CreateProjectVM, Project>();
            CreateMap<GetProjectByIdVM, Project>();
            CreateMap<GetProjectsVM, Project>();
            CreateMap<UpdateProjectVM, Project>();
            CreateMap<UpdateProjectStatusVM, Project>();
            

            CreateMap<TrackingTask, CreateTrackingTaskVM>();
            CreateMap<TrackingTask, GetTrackingTaskByIdVM>();
            CreateMap<TrackingTask, GetTrackingTasksVM>();
            CreateMap<TrackingTask, UpdateTrackingTaskVM>();
            CreateMap<TrackingTask, UpdateTrackingTaskStatusVM>();
            CreateMap<CreateTrackingTaskVM, TrackingTask>();
            CreateMap<GetTrackingTaskByIdVM, TrackingTask>();
            CreateMap<GetTrackingTasksVM, TrackingTask>();
            CreateMap<UpdateTrackingTaskVM, TrackingTask>();
            CreateMap<UpdateTrackingTaskStatusVM, TrackingTask>();

        }
    }
}