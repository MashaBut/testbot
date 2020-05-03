using Microsoft.EntityFrameworkCore;
using testProject.Models;

namespace testProject.DataAccess
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }
    }
}
