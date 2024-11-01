using System.ComponentModel.DataAnnotations.Schema;

namespace API;

[Table("ClosingLog", Schema = "construcciones_xyz")]
public partial class ClosingLog
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
}