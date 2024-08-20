using Microsoft.AspNetCore.Identity;

namespace ApiQuanlikho.Datas
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = null!;
    }
}
