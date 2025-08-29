using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProjectManagementSystem.Domain.Master;
using ProjectManagementSystem.Domain.UserManagement;

namespace ProjectManagementSystem.Domain
{
    public class PmsContext : DbContext
    {
        public PmsContext(DbContextOptions<PmsContext> opitions) : base(opitions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "Master");
                entity.HasKey("Id");
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Code).HasMaxLength(150).IsRequired();

                entity.HasData
                (
                    new Role() { Id = 1, Name = "SuperAdmin", Code="SA" }
                );
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments", "Master");
                entity.HasKey("Id");
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Code).HasMaxLength(150).IsRequired();
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation", "Master");
                entity.HasKey("Id");
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Code).HasMaxLength(150).IsRequired();
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.ToTable("Priorities", "Master");
                entity.HasKey("Id");
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Code).HasMaxLength(150).IsRequired();
            });


            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status", "Master");
                entity.HasKey("Id");
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
                entity.Property(x => x.Code).HasMaxLength(150).IsRequired();
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module", "UserManagement");
                entity.HasKey("Id");
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.ModuleName).HasMaxLength(200).IsRequired();
                entity.Property(x => x.ControllerName).HasMaxLength(200).IsRequired();
                entity.Property(x=>x.ActionName).HasMaxLength(200).IsRequired();
                entity.Property(x => x.IconClass).HasMaxLength(200);
                entity.Property(x => x.DisplayOrder);

                //seed Data inside the Module Master

                entity.HasData
                (
                    new Module() { Id = 1,ModuleName="Master", ActionName = "Index", ControllerName = "Roles", IconClass = "", DisplayOrder = 1 },
                    new Module() { Id = 2, ModuleName = "Master", ActionName = "Index", ControllerName = "Department", IconClass = "", DisplayOrder = 2 },
                    new Module() { Id = 3, ModuleName = "Master", ActionName = "Index", ControllerName = "Designation", IconClass = "", DisplayOrder = 3 },
                    new Module() { Id = 4, ModuleName = "Master", ActionName = "Index", ControllerName = "Status", IconClass = "", DisplayOrder = 4 },
                    new Module() { Id = 5, ModuleName = "Master", ActionName = "Index", ControllerName = "Priority", IconClass = "", DisplayOrder = 5 }
                );
            });

            modelBuilder.Entity<RoleModuleAccess>(entity =>
            {
                entity.ToTable("RoleModuleAccess", "UserManagement");

                entity.HasKey(e => e.Id); // Assuming BaseDomain has Id

                entity.Property(e => e.RoleId).IsRequired();
                entity.Property(e => e.ModuleId).IsRequired();

                entity.HasOne(e => e.Roles)
                      .WithMany()
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(e => e.Modules)
                      .WithMany()
                      .HasForeignKey(e => e.ModuleId)
                      .OnDelete(DeleteBehavior.Cascade);
                //seed Data inside the Module Master

                //entity.HasData
                //(
                //    new RoleModuleAccess() { Id = 1, RoleId=1, ModuleId=1 },
                //    new RoleModuleAccess() { Id = 2, RoleId=1, ModuleId=2},
                //    new RoleModuleAccess() { Id = 3, RoleId = 1, ModuleId = 3 },
                //    new RoleModuleAccess() {Id = 4, RoleId = 1, ModuleId = 4 },
                //    new RoleModuleAccess() {Id = 5, RoleId = 1, ModuleId = 5 }
                //);
            });
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Priority> Priorities { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<RoleModuleAccess> RoleModuleAccesses { get; set; }

    }
}
