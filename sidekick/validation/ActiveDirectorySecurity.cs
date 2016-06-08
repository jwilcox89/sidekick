using System;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;
using System.Linq;

namespace sidekick
{
    /// <summary>
    ///     Validates users credentials against active directory
    /// </summary>
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

        /// <summary>
        ///     Returns user roles for given username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static IList<string> GetUserRoles(string username, string domain)
        {
            if (String.IsNullOrEmpty(domain))
                return new List<string>();

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);
                if (user == null)
                    return new List<string>();

                return user.GetAuthorizationGroups().Select(x => x.Name).ToList();
            }
        }

        /// <summary>
        ///     Returns user roles for given username
        /// </summary>
        /// <param name="username"></param>
        /// <param name="contextType"></param>
        /// <param name="contextName"></param>
        /// <returns></returns>
        public static IList<string> GetUserRoles(string username, ContextType contextType, string contextName)
        {
            using (PrincipalContext pc = new PrincipalContext(contextType, contextName))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, username);
                if (user == null)
                    return new List<string>();

                return user.GetAuthorizationGroups().Select(x => x.Name).ToList();
            }
        }
    }
}