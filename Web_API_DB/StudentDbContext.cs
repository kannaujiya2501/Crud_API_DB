using Microsoft.EntityFrameworkCore;

namespace Web_API_DB
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
        {
        }
        public DbSet<Student> students { get; set; }


    }
}
