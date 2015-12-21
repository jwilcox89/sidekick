using System;
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
        /// <param name="contextName">Active directory domain</param>
        /// <returns>Returns true if credentials are validated</returns>
        public static bool ValidateCredentials(string username, string password, string domain) 
        {
            if (String.IsNullOrEmpty(domain))
                return false;

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain)) 
            {
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    return false;

                if (pc.ValidateCredentials(username, password))
                    return true;
            }

            return false;
        }

        /// <summary>
        ///     Validates user's credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="contextType"></param>
        /// <param name="contextName"></param>
        /// <returns></returns>
        public static bool ValidateCredentials(string username, string password, ContextType contextType, string contextName) 
        {
            if (String.IsNullOrEmpty(contextName))
                return false;

            using (PrincipalContext pc = new PrincipalContext(contextType, contextName)) 
            {
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    return false;

                if (pc.ValidateCredentials(username, password))
                    return true;
            }

            return false;
        }
    }
}