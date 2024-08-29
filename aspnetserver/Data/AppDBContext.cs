using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    public class AppDBContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] contentsToSeed = new Post[6];

            for (int i = 1; i <=6; i++)
            {
                contentsToSeed[i - 1] = new Post
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"This is very nice content about Post {i}, which is very informative and interesting."

                };
            }

            modelBuilder.Entity<Post>().HasData(contentsToSeed);
        }

    }
}
