using BlazorTestApp.Data;
using Microsoft.AspNetCore.Identity;

namespace BlazorTestApp.Code
{
    public class RoleHandler
    {
        public static async Task CreateUserRole(string user, string role, IServiceProvider _serviceProvider) 
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var userRoleCheck = await roleManager.RoleExistsAsync(role);
            if (!userRoleCheck)
                await roleManager.CreateAsync(new IdentityRole(role));

            Data.ApplicationUser identityUser = await userManager.FindByEmailAsync(user);
            await userManager.AddToRoleAsync(identityUser, role);
        }
    }
}
