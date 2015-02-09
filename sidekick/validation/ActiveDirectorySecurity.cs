using System.DirectoryServices.AccountManagement;

namespace sidekick
{
    public static class ActiveDirectorySecurity
    {
        public static bool ValidateCredentials(string username, string password, string domain) {
            if (string.IsNullOrEmpty(domain))
                return false;

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain)) {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return false;

                if (pc.ValidateCredentials(username, password))
                    return true;
            }

            return false;
        }
    }
}