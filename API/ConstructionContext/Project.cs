using System.ComponentModel.DataAnnotations.Schema;
using Models = API.Models;

namespace API;
[Table("Project", Schema = "construcciones_xyz")]
public partial class Project
{
  public int Id { get; set; }
  public int Type { get; set; }
  public string Name { get; set; }
  public string Location { get; set; }
  public decimal Cost { get; set; }
  public int State { get; set; }

  public int EngineerId { get; set; }
  public virtual ProjectType ProjectType { get; set; }
  public virtual ProjectState ProjectState { get; set; }

  public virtual Engineer Engineer { get; set; }
}