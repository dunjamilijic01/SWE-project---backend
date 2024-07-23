using Microsoft.AspNetCore.Identity;

namespace Models
{
    public static class SeedData
    {
        public static void Seed(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, Context context)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager, context);
        }

        private static async void SeedUsers(UserManager<AppUser> userManager,Context context)
        {
            if(userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new AppUser
                {
                    UserName="admin",
                    Email = "admin@gmail.com"
                };
                var result =  userManager.CreateAsync(user,"Admin123!").Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Admin").Wait();
                }
            }

            if(userManager.FindByNameAsync("Menadzer").Result == null)
            {
                var user = new Radnik
                {
                    UserName="Menadzer",
                    Email = "menadzer@gmail.com",
                    PhoneNumber="0693205222",
                    Ime="Dunja",
                    Prezime="Milijic",
                    Vlasnik = true,
                    KaficId = 1
                };
                var result =  userManager.CreateAsync(user,"Menadzer123!").Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Menadzer").Wait();
                }
            }
            if(userManager.FindByNameAsync("Radnik").Result == null)
            {
                var user = new Radnik
                {
                    UserName="Radnik",
                    Email = "radnik@gmail.com",
                    PhoneNumber="0628402664",
                    Ime="Tamara",
                    Prezime="Milovanovic",
                    Vlasnik=false,
                    KaficId = 1
                };
                var result =  userManager.CreateAsync(user,"Radnik123!").Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Radnik").Wait();
                }
            }
            if(userManager.FindByNameAsync("Posetilac").Result == null)
            {
                var user = new Posetilac
                {
                    UserName="Posetilac",
                    Email = "Posetilac@gmail.com",
                    PhoneNumber="065234897",
                    Ime="Nikola",
                    Prezime="Nikolic"
                };
                var result =  userManager.CreateAsync(user,"Posetilac123!").Result;
                if(result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Posetilac").Wait();
                }
            }
            
        }

        private static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if(!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new AppRole
                {
                    Name="Admin"
                };
                 var result = roleManager.CreateAsync(role).Result;
            }

            if(!roleManager.RoleExistsAsync("Posetilac").Result)
            {
                var role = new AppRole
                {
                    Name="Posetilac"
                };
                var result =roleManager.CreateAsync(role).Result;
            }

            if(!roleManager.RoleExistsAsync("Menadzer").Result)
            {
                var role = new AppRole
                {
                    Name="Menadzer"
                };
                var result =roleManager.CreateAsync(role).Result;
            }

            if(!roleManager.RoleExistsAsync("Radnik").Result)
            {
                var role = new AppRole
                {
                    Name="Radnik"
                };
                var result =roleManager.CreateAsync(role).Result;
            }
        }
    }
}