using Microsoft.EntityFrameworkCore;

namespace RecompenseAPI.Data.Db
{
    public class DbContextApp : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Challenge> Challenges { get; set; }

        public DbContextApp(DbContextOptions options): base(options)
        {

        }
    }
}
