using Models = API.Models;

namespace API;
public static class Converter
{

    public static Models.ProjectType ToApi(this ProjectType projectType)
    {
        return new Models.ProjectType
        {
            Id = projectType.Id,
            Name = projectType.Name
        };
    }

    public static Models.ProjectState ToApi(this ProjectState projectState)
    {
        return new Models.ProjectState
        {
            Id = projectState.Id,
            Name = projectState.Name
        };
    }

    public static Models.Engineer ToApi(this Engineer engineer)
    {
        return new Models.Engineer
        {
            Id = engineer.Id,
            FirstName = engineer.FirstName,
            LastName = engineer.LastName
        };
    }
    public static Models.Project ToApi(this Project project)
    {
        return new Models.Project
        {
            Id = project.Id,
            Type = project.Type,
            Name = project.Name,
            Location = project.Location,
            Cost = project.Cost,
            State = project.State,
            EngineerId = project.EngineerId,
            IsArchived = project.IsArchived,
            ProjectType = project.ProjectType != null ? project.ProjectType.ToApi() : null,
            ProjectState = project.ProjectState != null ? project.ProjectState.ToApi() : null,
            Engineer = project.Engineer != null ? project.Engineer.ToApi() : null
        };
    }
}