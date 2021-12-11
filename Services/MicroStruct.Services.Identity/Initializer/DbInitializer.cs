using IdentityModel;
using MicroStruct.Services.Identity.DbContexts;
using MicroStruct.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MicroStruct.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(GlobalRoles.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(GlobalRoles.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(GlobalRoles.Customer)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "12",
                FirstName = "Ben",
                LastName = "Admin"
            };

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, GlobalRoles.Admin).GetAwaiter().GetResult();
            _userManager.AddClaimsAsync(adminUser, new Claim[]{
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+" "+adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                 new Claim(JwtClaimTypes.Role,GlobalRoles.Admin)
            }).GetAwaiter().GetResult() ;


            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer1@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "12",
                FirstName = "Ben",
                LastName = "Cust"
            };

            _userManager.CreateAsync(customerUser, "GlobalRoles*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, GlobalRoles.Customer).GetAwaiter().GetResult();
            _userManager.AddClaimsAsync(customerUser, new Claim[]{
                new Claim(JwtClaimTypes.Name,customerUser.FirstName+" "+customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                 new Claim(JwtClaimTypes.Role,GlobalRoles.Customer)
            }).GetAwaiter().GetResult();

            
        }
    }
}
