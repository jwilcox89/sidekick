using System.DirectoryServices.AccountManagement;

namespace sidekick
{
    public static class ActiveDirectorySecurity
    {
        /// <summary>
        ///     Validates user's active directory credentials
        /// </summary>
        /// <param name="username">Active directory username</param>
        /// <param name="password">Active directory password</param>
        /// <param name="domain">Active directory domain</param>
        /// <returns>Returns true if credentials are validated</returns>
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