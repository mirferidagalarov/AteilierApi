using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public static class SeedData
    {
        //static public IApplicationBuilder seedMembership(this IApplicationBuilder app)
        //{
        //    using (var scope = app.ApplicationServices.CreateScope())
        //    {
        //        var role = new AteilerRole
        //        {
        //            Name = "SuperAdmin"
        //        };
        //        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AteilerUser>>();
        //        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AteilerRole>>();

        //        if (roleManager.RoleExistsAsync(role.Name).Result)
        //        {
        //            role = roleManager.FindByNameAsync(role.Name).Result;
        //        }
        //        else
        //        {
        //            var roleCreateResult = roleManager.CreateAsync(role).Result;
        //            if (!roleCreateResult.Succeeded)
        //                goto end;
        //        }

        //        string pwd = "6290098";

        //        var user = new AteilerUser
        //        {
        //            UserName = "mirferid.agalarov@gmail.com",
        //            Email = "mirferid.agalarov@gmail.com",
        //            EmailConfirmed = true,
        //            Name = "Mirferid",
        //            Surname = "Agalarov"
        //        };

        //        var foundedUser = userManager.FindByEmailAsync(user.Email).Result;
        //        if (foundedUser != null && !userManager.IsInRoleAsync(foundedUser, role.Name).Result)
        //        {
        //            userManager.AddToRoleAsync(foundedUser, role.Name).Wait();
        //        }
        //        else if (foundedUser == null)
        //        {
        //            var userCreatedResult = userManager.CreateAsync(user, pwd).Result;
        //            if (!userCreatedResult.Succeeded)
        //                goto end;


        //            userManager.AddToRoleAsync(user, role.Name).Wait();
        //        }
        //    }
        //end:
        //    return app;
        //}
    }
}
