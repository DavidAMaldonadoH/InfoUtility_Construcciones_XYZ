using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API;
public partial class ConstructionContext : DbContext
{

  public virtual DbSet<Project> Projects { get; set; }
  public virtual DbSet<ProjectType> ProjectTypes { get; set; }
  public virtual DbSet<ProjectState> ProjectStates { get; set; }
  public virtual DbSet<Engineer> Engineers { get; set; }

  public virtual DbSet<ClosingLog> ClosingLogs { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(@"Server=localhost;Database=construcciones_xyz;ConnectRetryCount=0;User Id=sa;Password=Sql_Srvr_pwd22;Encrypt=false;TrustServerCertificate=True", x => x.MigrationsHistoryTable("Migrations", "construcciones_xyz"));
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.HasDefaultSchema("construcciones_xyz");

    modelBuilder.Entity<Project>(entity =>
    {
      entity.ToTable("Project", "construcciones_xyz");

      entity.Property(e => e.Id);

      entity.Property(e => e.Type).IsRequired().HasColumnType("int");

      entity.Property(e => e.Name).IsRequired().HasColumnType("nvarchar(128)");

      entity.Property(e => e.Location).IsRequired().HasColumnType("nvarchar(128)");

      entity.Property(e => e.Cost).IsRequired().HasColumnType("decimal(12, 2)");

      entity.Property(e => e.State).IsRequired().HasColumnType("int");

      entity.Property(e => e.IsArchived).IsRequired().HasColumnType("bit");

      entity.HasOne(d => d.ProjectType)
        .WithMany(p => p.Projects)
        .HasForeignKey(d => d.Type)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Project_ProjectType");

      entity.HasOne(d => d.ProjectState)
        .WithMany(p => p.Projects)
        .HasForeignKey(d => d.State)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Project_ProjectState");

      entity.HasOne(d => d.Engineer)
        .WithMany(p => p.Projects)
        .HasForeignKey(d => d.EngineerId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_Project_Engineer");
    });

    modelBuilder.Entity<ProjectType>(entity =>
    {
      entity.ToTable("ProjectType", "construcciones_xyz");

      entity.Property(e => e.Id);

      entity.Property(e => e.Name).IsRequired().HasColumnType("nvarchar(128)");
    });

    modelBuilder.Entity<ProjectState>(entity =>
    {
      entity.ToTable("ProjectState", "construcciones_xyz");

      entity.Property(e => e.Id);

      entity.Property(e => e.Name).IsRequired().HasColumnType("nvarchar(128)");
    });

    modelBuilder.Entity<Engineer>(entity =>
    {
      entity.ToTable("Engineer", "construcciones_xyz");

      entity.Property(e => e.Id);

      entity.Property(e => e.FirstName).IsRequired().HasColumnType("nvarchar(128)");

      entity.Property(e => e.LastName).IsRequired().HasColumnType("nvarchar(128)");
    });
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}