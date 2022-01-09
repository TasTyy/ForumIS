using web.Data;
using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ForumContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var roles = new IdentityRole[] {
                new IdentityRole{Id="1", Name="Administrator"},
                new IdentityRole{Id="2", Name="Uporabnik"},
            };

            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }

            var user = new ApplicationUser
            {
                Ime = "Admini",
                Priimek = "Strator",
                Email = "admin@mail.com",
                NormalizedEmail = "XXXX@mail.com",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
        
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user,"Geslo123;");
                user.PasswordHash = hashed;
                context.Users.Add(user);
                
            } 

            context.SaveChanges();
            

            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=user.Id},
                new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=user.Id},
            };

            foreach (IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }

            context.SaveChanges();

            
            var kategorije = new Category[]
            {
                new Category{Title="Splošno"},
                new Category{Title="Predavanja"},
                new Category{Title="Naloge"},
                new Category{Title="Diskusije"},
            };

            foreach (Category c in kategorije)
            {
                context.Categories.Add(c);
            }

            //context.Cattegorys.AddRange(kategorije);
            context.SaveChanges();
        }
    }
}