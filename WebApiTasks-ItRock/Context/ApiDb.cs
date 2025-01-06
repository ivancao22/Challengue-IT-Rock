using Microsoft.EntityFrameworkCore;

namespace WebApiTasks_ItRock.Context
{
    public class ApiDb : DbContext
    {
        public ApiDb(DbContextOptions<ApiDb> options): base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }

    }
}
