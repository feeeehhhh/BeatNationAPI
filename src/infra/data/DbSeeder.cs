
using src.domain.models;
using Microsoft.AspNetCore.Identity;

namespace src.infra.data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            await SeedRoles(roleManager);
            await SeedAdminUser(userManager);
        }

        public static async Task SeedRoles(RoleManager<IdentityRole<Guid>> roleManager)
        {
            string[] roles = { "User", "Admin", "Producer" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }

        public static async Task SeedAdminUser(UserManager<User> userManager)
        {
            string adminEmail = "teste@example.com"; //Trocar para email real depois
            string adminPassword = "Teste123!"; //Trocar para senha real depois

            var user = await userManager.FindByEmailAsync(adminEmail);

            if(user == null)
            {
                var adminUser = new User
                {
                    UserName = "Admin",
                    Email = adminEmail,
                    Name = "Admin Beat Nation",
                    EmailConfirmed = true
                };

                    await userManager.CreateAsync(adminUser, adminPassword);
                    await userManager.AddToRoleAsync(adminUser, "Admin");
              
            }
        }
    }
}