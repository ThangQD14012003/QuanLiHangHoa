using ApiQuanlikho.Datas;
using ApiQuanlikho.Helper;
using ApiQuanlikho.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiQuanlikho.Services
{
    public class AccountRepository : IAcountRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        // configuration để làm việc với secretkey
        {
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<string> SigInAsync(SignInModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passwordValid)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var authenkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(40),// thời gian hết hạn đây là 20p
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenkey,
                SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token); // của tui
        }

        public async Task<IdentityResult> SigUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // kiểm tra role customer đã có chưa
                if (!await roleManager.RoleExistsAsync(AppicationRole.Manager))
                {
                    // nếu chưa có thì khi đăng kí sẽ có luôn role là manager
                    await roleManager.CreateAsync(new IdentityRole(AppicationRole.Manager));
                }
                await userManager.AddToRoleAsync(user, AppicationRole.Manager);
            }
            return result;
        }
    }
}
