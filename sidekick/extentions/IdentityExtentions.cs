using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace sidekick
{
    public static class IdentityExtentions
    {
        public static string GetIdentityProperty(this IIdentity identity, string propertyName) {
            return ((ClaimsIdentity)identity).Claims.FirstOrDefault(x => x.Type == propertyName).Value;
        }
    }
}
