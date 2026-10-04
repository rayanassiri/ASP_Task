using Microsoft.EntityFrameworkCore;
using ASP_Task.Domain.Models;

namespace ASP_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRoles> PermissionRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // إعداد جدول الربط للصلاحيات والأدوار بالطريقة المباشرة السليمة
            modelBuilder.Entity<PermissionRoles>()
                .HasKey(pr => new { pr.RolesId, pr.PermissionId });

            modelBuilder.Entity<PermissionRoles>()
                .HasOne(pr => pr.Role)
                .WithMany()
                .HasForeignKey(pr => pr.RolesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PermissionRoles>()
                .HasOne(pr => pr.Permission)
                .WithMany()
                .HasForeignKey(pr => pr.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // إعداد جدول الربط للمستخدمين والأدوار
            modelBuilder.Entity<RoleUser>()
                .HasKey(ru => new { ru.RoleId, ru.UserId });

            modelBuilder.Entity<RoleUser>()
                .HasOne(ru => ru.Role)
                .WithMany()
                .HasForeignKey(ru => ru.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoleUser>()
                .HasOne(ru => ru.User)
                .WithMany()
                .HasForeignKey(ru => ru.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}