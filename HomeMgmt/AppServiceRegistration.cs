using Backend.Services.SeederService;
using FluentValidation;
using HomeMgmt.Helpers.ValidatorServices;
using HomeMgmt.Models.UserModels;
using HomeMgmt.Services.AuthServices;
using HomeMgmt.Services.NotificationServices;
using HomeMgmt.Services.UserAccountService;
using HomeMgmt.Services.UserRoleServices;
using HomeMgmt.Utils;

namespace HomeMgmt
{
    public static class AppServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {

            // ADD AUTHORIZATION POLICY
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AUTHORIZATION.EXCLUDE_INACTIVE, policy => policy.AddRequirements(new CustomRoleRequirement()));
            });

            // HELPER SERVICES
            services.AddScoped<IValidatorService, ValidatorService>();

            // VALIDATORS
            services.AddScoped<IValidator<UserAccount>, UserAccountValidator>();
            services.AddScoped<IValidator<UserRole>, UserRoleValidator>();

            // SERVICES
            services.AddScoped<SeederService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUserAccountService, UserAccountService>();

            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
