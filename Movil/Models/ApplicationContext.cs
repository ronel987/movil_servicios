using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Usuario", NormalizedName = "Usuario" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Profesor", NormalizedName = "Profesor" });

            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Matemáticas", Status = true });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Baile", Status = true });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Peluquería", Status = true });

            modelBuilder.Entity<Order>()
                    .HasKey(f => new { f.StudentId, f.TeacherId });

            modelBuilder.Entity<Order>()
                    .HasOne(m => m.Student)
                    .WithMany(t => t.Orders)
                    .HasForeignKey(m => m.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                    .HasOne(m => m.Teacher)
                    .WithMany(t => t.TeacherOrders)
                    .HasForeignKey(m => m.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CourseContent> CourseContents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CourseContentOrder> CourseContentOrders { get; set; }
        //public DbSet<AppUser> AppUser { get; set; }
    }
}
