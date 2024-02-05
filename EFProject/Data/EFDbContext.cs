using Microsoft.EntityFrameworkCore;

namespace EFProject.Data
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options) 
        {
            
        }
        //to add tables into database we have to add DbSet properties here
        //these properties must have name same as the class name
        //we may pluralize the names
        public DbSet<Student> Students { get; set; }
    }
}
