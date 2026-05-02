using Microsoft.EntityFrameworkCore;
using Tarea3.MODEL;

namespace Tarea3.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}