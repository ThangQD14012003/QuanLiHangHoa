using ApiQuanlikho.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiQuanlikho.Services
{
    public interface IAcountRepository
    {
        public Task<IdentityResult> SigUpAsync(SignUpModel model);
        public Task<string> SigInAsync(SignInModel model);
    }
}
