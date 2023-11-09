using Microsoft.EntityFrameworkCore;
using Schedule.Web.Entities;

namespace Schedule.Web.Contexts;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Group> Groups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}