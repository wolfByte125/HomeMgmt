using HomeMgmt.Contexts;
using HomeMgmt.DTOs.UserDTOs.UserAccountDTOs;
using HomeMgmt.Models.UserModels;
using HomeMgmt.Services.AuthServices;
using HomeMgmt.Utils;
using System.Reflection;

namespace Backend.Services.SeederService
{
    public class SeederService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;

        public SeederService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public bool SeedDB()
        {
            UserRoleSeeder();
            UserAccountSeeder();

            return true;
        }

        #region USER RELATED

        public void UserRoleSeeder()
        {
            List<UserRole> userRoles = new();
            List<string> rolePermissions = new();
            rolePermissions.Add("Id");
            rolePermissions.Add("UserRole");
            rolePermissions.Add("UserRoleId");

            if (!_context.UserRoles.Any(x => x.RoleName == SEEDED_ROLES.SUPER_ADMIN))
            {
                userRoles.Add(new UserRole()
                {
                    RoleName = SEEDED_ROLES.SUPER_ADMIN,
                    IsSuperAdmin = true,
                    Permissions = new(),
                });

                foreach (PropertyInfo prop in userRoles[0].Permissions.GetType().GetProperties())
                {
                    _ = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    if (!rolePermissions.Contains(prop.Name))
                        prop.SetValue(userRoles[0].Permissions, true);
                }
            }
            
            if (!_context.UserRoles.Any(x => x.RoleName == SEEDED_ROLES.DEFAULT_ROLE))
            {
                userRoles.Add(new UserRole()
                {
                    RoleName = SEEDED_ROLES.DEFAULT_ROLE,
                    IsSuperAdmin = false,
                    Permissions = new(),
                });
            }

            _context.UserRoles.AddRange(userRoles);
            _context.SaveChanges();

            Console.WriteLine("User Role Seeded");
        }

        public void UserAccountSeeder()
        {
            if (_context.UserAccounts.Any())
            {
                return;
            }

            _authService.RegisterUserAccount(new RegisterUserAccountDTO()
            {
                FirstName = "Super Admin",
                Username = "admin",
                Password = "password",
                IsSuperAdmin = true
            }).Wait();

            Console.WriteLine("Super Admin Account Seeded");
        }

        #endregion
    }
}
