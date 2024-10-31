using System.ComponentModel.DataAnnotations.Schema;
using Models = API.Models;

namespace API;

[Table("Project", Schema = "construcciones_xyz")]
public partial class ProjectState
{
    public virtual ICollection<Project> Projects { get; set; }

    public ProjectState()
    {
        Projects = new HashSet<Project>();
    }
    public int Id { get; set; }
    public required string Name { get; set; }
}