using Microsoft.EntityFrameworkCore;
using testProject.Data.Entities;

namespace testProject
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<TGUser> TGUsers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
