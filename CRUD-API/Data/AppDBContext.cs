using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
}
