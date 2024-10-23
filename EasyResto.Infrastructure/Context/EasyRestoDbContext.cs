using EasyResto.Domain.Entities;
using EasyResto.Domain.Enums;
using EasyResto.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

namespace EasyResto.Infrastructure.Context
{
    public class EasyRestoDbContext : DbContext
    {
        public EasyRestoDbContext(DbContextOptions<EasyRestoDbContext> options) : base(options) { }
        
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodItemStatus> FoodItemStatuses { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<DiningTable> DiningTables { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser").HasKey(x => x.Id);
                entity.HasIndex(x => x.Username).IsUnique();
                entity.Property(x => x.Username).HasMaxLength(100);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);
            });

            modelBuilder.Entity<AppUserRole>(entity =>
            {
                entity.ToTable("AppUserRole").HasKey(x => new { x.AppUserId, x.RoleId });
                entity.HasOne(e => e.AppUser).WithMany(s => s.AppUserRoles).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Role).WithMany(s => s.AppUserRoles).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.ToTable("Privilege").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);
            });

            modelBuilder.Entity<RolePrivilege>(entity =>
            {
                entity.ToTable("RolePrivilege").HasKey(x => new { x.RoleId, x.PrivilegeId });
                entity.HasOne(e => e.Role).WithMany(s => s.RolePrivileges).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Privilege).WithMany(s => s.RolePrivileges).HasForeignKey(x => x.PrivilegeId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);

                entity.HasMany(x => x.FoodItems).WithOne(x => x.FoodCategory).HasForeignKey(x => x.FoodCategoryId);
            });

            modelBuilder.Entity<FoodItemStatus>(entity =>
            {
                entity.ToTable("FoodItemStatus").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);

                entity.HasMany(x => x.FoodItems).WithOne(x => x.FoodItemStatus).HasForeignKey(x => x.FoodItemStatusId);
            });

            modelBuilder.Entity<FoodItem>(entity =>
            {
                entity.ToTable("FoodItem").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.Price).HasPrecision(17,2);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);

                entity.HasOne(x => x.FoodCategory).WithMany(x => x.FoodItems).HasForeignKey(x => x.FoodCategoryId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.FoodItemStatus).WithMany(x => x.FoodItems).HasForeignKey(x => x.FoodItemStatusId).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(x => x.OrderDetails).WithOne(x => x.FoodItem).HasForeignKey(x => x.FoodItemId);
            });

            modelBuilder.Entity<DiningTable>(entity =>
            {
                entity.ToTable("DiningTable").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);

                entity.HasMany(x => x.Orders).WithOne(x => x.DiningTable).HasForeignKey(x => x.DiningTableId);
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus").HasKey(x => x.Id);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.Name).HasMaxLength(255);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);

                entity.HasMany(x => x.Orders).WithOne(x => x.OrderStatus).HasForeignKey(x => x.OrderStatusId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order").HasKey(x => x.Id);
                entity.Property(x => x.ChefId).IsRequired(false);
                entity.Property(x => x.CashierId).IsRequired(false);
                entity.HasIndex(x => x.Code).IsUnique();
                entity.Property(x => x.Code).HasMaxLength(100);
                entity.Property(x => x.TotalPrice).HasPrecision(17, 2);
                entity.Property(x => x.Tax).HasPrecision(17, 2);
                entity.Property(x => x.BillAmount).HasPrecision(17, 2);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);

                entity.HasOne(x => x.DiningTable).WithMany(x => x.Orders).HasForeignKey(x => x.DiningTableId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.OrderStatus).WithMany(x => x.Orders).HasForeignKey(x => x.OrderStatusId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Waiter).WithMany(x => x.WaiterOrders).HasForeignKey(x => x.WaiterId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Chef).WithMany(x => x.ChefOrders).HasForeignKey(x => x.ChefId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.Cashier).WithMany(x => x.CashierOrders).HasForeignKey(x => x.CashierId).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail").HasKey(x => x.Id);
                entity.Property(x => x.Price).HasPrecision(17, 2);
                entity.Property(x => x.CreatedBy).IsRequired(false);
                entity.Property(x => x.CreatedAt).IsRequired(false);
                entity.Property(x => x.UpdatedBy).IsRequired(false);
                entity.Property(x => x.UpdatedAt).IsRequired(false);
                entity.Property(x => x.DeletedBy).IsRequired(false);
                entity.Property(x => x.DeletedAt).IsRequired(false);

                entity.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(x => x.FoodItem).WithMany(x => x.OrderDetails).HasForeignKey(x => x.FoodItemId).OnDelete(DeleteBehavior.Restrict);
            });

            #region "SEED"
            string createdBy = "Admin";
            DateTime now = DateTime.Now;
            string adminPassword = new PasswordService().HashPassword("admin");
            Guid adminAppUserId = Guid.NewGuid();
            Guid adminRoleId = Guid.NewGuid();

            List<Role> roles = new List<Role>();
            foreach (RoleCode roleCode in Enum.GetValues(typeof(RoleCode)))
            {
                Role role = new Role();

                if (roleCode == RoleCode.Admin)
                {
                    role.Id = adminRoleId;
                }
                else
                {
                    role.Id = Guid.NewGuid();
                }

                role.Code = roleCode.ToString();
                role.Name = roleCode.ToString();
                role.CreatedBy = createdBy;
                role.CreatedAt = now;

                roles.Add(role);
            }
            modelBuilder.Entity<Role>().HasData(roles);

            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { Id = adminAppUserId, Username = "admin", Name = "Admin", Password = adminPassword, IsActive = true, CreatedBy = createdBy, CreatedAt = now }
            );

            modelBuilder.Entity<AppUserRole>().HasData(
                new AppUserRole { AppUserId = adminAppUserId, RoleId = adminRoleId }
            );

            List<Privilege> privileges = new List<Privilege>();
            foreach (PrivilegeCode privilegeCode in Enum.GetValues(typeof(PrivilegeCode)))
            {
                Privilege privilege = new Privilege { Id = Guid.NewGuid(), Code = privilegeCode.ToString(), Name = privilegeCode.ToString(), CreatedBy = createdBy, CreatedAt = now };
                privileges.Add(privilege);
            }
            modelBuilder.Entity<Privilege>().HasData(privileges);

            List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();
            foreach (Privilege privilege in privileges)
            {
                rolePrivileges.Add(new RolePrivilege { RoleId = adminRoleId, PrivilegeId = privilege.Id });
            }
            modelBuilder.Entity<RolePrivilege>().HasData(rolePrivileges);

            List<FoodItemStatus> foodItemStatuses = new List<FoodItemStatus>();
            foreach (FoodStatusCode foodStatusCode in Enum.GetValues(typeof(FoodStatusCode)))
            {
                foodItemStatuses.Add(new FoodItemStatus { Id = Guid.NewGuid(), Code = foodStatusCode.ToString(), Name = foodStatusCode.ToString(), CreatedBy = createdBy, CreatedAt = now });
            }
            modelBuilder.Entity<FoodItemStatus>().HasData(foodItemStatuses);

            List<OrderStatus> orderStatuses = new List<OrderStatus>();
            foreach (OrderStatusCode orderStatusCode in Enum.GetValues(typeof(OrderStatusCode)))
            {
                orderStatuses.Add(new OrderStatus { Id = Guid.NewGuid(), Code = orderStatusCode.ToString(), Name = orderStatusCode.ToString(), CreatedBy = createdBy, CreatedAt = now });
            }
            modelBuilder.Entity<OrderStatus>().HasData(orderStatuses);
            #endregion
        }
    }
}
