using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace work_01.Data
{
    public class MyUserClimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser>
    {
        public MyUserClimsPrincipalFactory(UserManager<ApplicationUser> userManager,IOptions<IdentityOptions> optionsAccessor):base(userManager,optionsAccessor)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("Name", user.Name ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("CellPhone", user.Name ?? "[Click to edit profile]"));
            identity.AddClaim(new Claim("Country", user.Name ?? "[Click to edit profile]"));

            return identity;
        }
    }
}
