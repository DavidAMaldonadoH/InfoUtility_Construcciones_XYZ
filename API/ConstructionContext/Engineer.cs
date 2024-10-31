using System.ComponentModel.DataAnnotations.Schema;

namespace API;
[Table("Project", Schema = "construcciones_xyz")]
public partial class Engineer
{
    public virtual ICollection<Project> Projects { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Engineer() {
        Projects = new HashSet<Project>();
    }
}