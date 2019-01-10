using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LearnNETcORE2.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "123456Bo@";

        public static async Task EnsurePopulatedAsync(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser("Admin");
                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("couldn't create the admin user");
                }
            }
        }

    }
}






/*UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager = 
 * app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();*/
