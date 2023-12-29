using Microsoft.EntityFrameworkCore;

namespace ApiAppEnglish.Data.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Homework> homeWorks { get; set; }
        public DbSet<ListWord> listWords { get; set; }
        public DbSet<Topic> topic { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();         
        }
    }
}
