using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> UserManager)
        {
            if(!UserManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Jorge",
                    Email = "Jorge@test.com",
                    UserName = "Jorge@test.com",
                    Address = new Address
                    {
                        FirstName = "Jorge",
                        LastName = "Rivas",
                        Street = "10 Test Drive",
                        City = "New York",
                        State = "Ny",
                        ZipCode = "90219"
                        
                    }
                };
                await UserManager.CreateAsync(user, "Pa$$w0rd");
            }
            
        }
    }
}