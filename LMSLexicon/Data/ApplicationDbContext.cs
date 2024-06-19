using LMSLexicon.API.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LexiconEntities = LMSLexicon.API.Models.Entities;

namespace LMSLexicon.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LexiconEntities.Module> Modules { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<LexiconEntities.Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Documents)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete documents if user is deleted

            modelBuilder.Entity<User>()
                .HasOne(u => u.Course)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CourseID)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete user if course is deleted

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Modules)
                .WithOne(m => m.Course)
                .HasForeignKey(m => m.CourseID)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete modules if course is deleted

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Documents)
                .WithOne(d => d.Course)
                .HasForeignKey(d => d.CourseID)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete documents if course is deleted

            modelBuilder.Entity<Module>()
                .HasMany(m => m.Activities)
                .WithOne(a => a.Module)
                .HasForeignKey(a => a.ModuleID)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete activities if module is deleted

            modelBuilder.Entity<Module>()
                .HasMany(m => m.Documents)
                .WithOne(d => d.Module)
                .HasForeignKey(d => d.ModuleID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete documents if module is deleted

            modelBuilder.Entity<Activity>()
                .HasMany(a => a.Documents)
                .WithOne(d => d.Activity)
                .HasForeignKey(d => d.ActivityID)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete documents if activity is deleted
        }

    }
}
