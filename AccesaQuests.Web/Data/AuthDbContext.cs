using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AccesaQuests.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            {
                base.OnModelCreating(builder);


                // Seed Roles (User, Admin, SuperAdmin)

                var adminRoleId = "37cc67e1-41ca-461c-bf34-2b5e62dbae32";
                var superAdminRoleId = "3cfd9eee-08cb-4da3-9e6f-c3166b50d3b0";
                var userRoleId = "a0cab2c3-6558-4a1c-be81-dfb39180da3d";

                var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name= "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

                builder.Entity<IdentityRole>().HasData(roles);

                // Seed SuperAdminUser
                var superAdminId = "472ba632-6133-44a1-b158-6c10bd7d850d";
                var superAdminUser = new IdentityUser
                {
                    UserName = "superadmin@accesa.com",
                    Email = "superadmin@accesa.com",
                    NormalizedEmail = "superadmin@accesa.com".ToUpper(),
                    NormalizedUserName = "superadminaccesa.com".ToUpper(),
                    Id = superAdminId
                };

                superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                    .HashPassword(superAdminUser, "TeRogIoMeri@123");


                builder.Entity<IdentityUser>().HasData(superAdminUser);


                // Add All roles to SuperAdminUser
                var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

                builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

            }
        }
    }
}
