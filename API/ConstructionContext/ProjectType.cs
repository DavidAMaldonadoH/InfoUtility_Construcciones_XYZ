using System.ComponentModel.DataAnnotations.Schema;

namespace API;

[Table("ProjectType", Schema = "construcciones_xyz")]
public partial class ProjectType
{
  public virtual ICollection<Project> Projects { get; set; }

  public ProjectType()
  {
    Projects = new HashSet<Project>();
  }

  public int Id { get; set; }
  public required string Name { get; set; }
}