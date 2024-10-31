using Microsoft.EntityFrameworkCore;
using API;

public static class StartDb
{
  public static async Task Start()
  {
    await CheckMigrations();
  }

  private static async Task CheckMigrations()
  {
    await using var db = new ConstructionContext();
    await db.Database.MigrateAsync();
  }
}