using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace Koolitused.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>//DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "opetaja" };
            var role3 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "somemail@gmail.com", UserName = "somemail@gmail.com" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            var opetaja1 = new ApplicationUser { Email = "marinaoleinik@gmail.com", UserName = "marinaoleinik@gmail.com" };
            string password_opetaja1 = "ad46D_ewr3";
            var result1 = userManager.Create(opetaja1, password_opetaja1);

            var opetaja2 = new ApplicationUser { Email = "irinamerkulova@gmail.com", UserName = "irinamerkulova@gmail.com" };
            string password_opetaja2 = "ad46D_ewr3";
            var result2 = userManager.Create(opetaja2, password_opetaja2);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
                if (result1.Succeeded)
                {
                    userManager.AddToRole(opetaja1.Id, role2.Name);
                    if (result2.Succeeded)
                    {
                        userManager.AddToRole(opetaja2.Id, role2.Name);
                    }
                }
            }
            base.Seed(context);
        }
    }
}