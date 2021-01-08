using Microsoft.EntityFrameworkCore;

namespace Task.Infra.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Task>().ToTable("Tasks");
            modelBuilder.Entity<Domain.Entities.Task>().Property(x => x.Id);
            modelBuilder.Entity<Domain.Entities.Task>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Domain.Entities.Task>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<Domain.Entities.Task>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<Domain.Entities.Task>().Property(x => x.Date);
            modelBuilder.Entity<Domain.Entities.Task>().HasIndex(b => b.User);
        }
    }
}
