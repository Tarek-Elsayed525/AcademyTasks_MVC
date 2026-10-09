using Microsoft.EntityFrameworkCore;

namespace AcademyTasks.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Models.TaskItem> TaskItems { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-8F377B2;initial catalog=AcademyTasks;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
    }
}
