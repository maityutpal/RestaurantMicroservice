using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Restaurant.Services.Identity.DbContexts;
using Restaurant.Services.Identity.Models;
using System.Security.Claims;

namespace Restaurant.Services.Identity.Initializer
{
    public class DbInitializer: IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(SettingConstants.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SettingConstants.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SettingConstants.Customer)).GetAwaiter().GetResult();
            }
            else { return; }

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "utpal@yopmail.com",
                Email = "utpal@yopmail.com",
                EmailConfirmed = true,
                PhoneNumber = "9433912719",
                FirstName = "Utpal",
                LastName = "Admin"
            };
           var data= _userManager.CreateAsync(adminUser, "Abcd.1234").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SettingConstants.Admin).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+" "+ adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,SettingConstants.Admin),
            }).Result;

            ApplicationUser customerUser = new ApplicationUser()
            {
                UserName = "customer@yopmail.com",
                Email = "customer@yopmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "General",
                LastName = "Customer"
            };

            _userManager.CreateAsync(customerUser, "Abcd.1234").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SettingConstants.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                new Claim(JwtClaimTypes.Name,customerUser.FirstName+" "+ customerUser.LastName),
                new Claim(JwtClaimTypes.GivenName,customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,customerUser.LastName),
                new Claim(JwtClaimTypes.Role,SettingConstants.Customer),
            }).Result;

        }
    }
}
