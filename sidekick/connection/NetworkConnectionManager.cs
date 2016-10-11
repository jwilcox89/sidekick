using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace sidekick
{
    public class NetworkConnectionManager : IDisposable
    {
        private UserImpersonation _userImpersonation;
        private NetworkCredential _networkCredential;
        private NetworkConnection _networkConnection;

        /// <summary>
        ///     Set up a network connection by impersonating a user.
        ///     Used for accesses network files via a universal log in.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="fileSharePath"></param>
        public NetworkConnectionManager(string username, string password, string domain, string fileSharePath)
        {
            _userImpersonation = new UserImpersonation(username, password, domain);
            _networkCredential = new NetworkCredential(username, password, domain);
            _networkConnection = new NetworkConnection(fileSharePath, _networkCredential);
        }

        public void Dispose()
        {
            _userImpersonation.undoimpersonateUser();
            GC.SuppressFinalize(this);
        }
    }

    #region Network Connection
    public class NetworkConnection
    {
        private string _networkName;

        public NetworkConnection(string networkName, NetworkCredential credentials)
        {
            _networkName = networkName;

            dynamic netResource = new NetResource()
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplaytype.Share,
                RemoteName = networkName
            };

            dynamic userName = String.IsNullOrEmpty(credentials.Domain) ? credentials.UserName : $"{credentials.Domain}\\{credentials.UserName}";
            dynamic result = WNetAddConnection2(netResource, credentials.Password, userName, 0);

            if (result != 0)
                throw new Win32Exception(result, "Error connecting to remote share");
        }

        ~NetworkConnection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(_networkName, 0, true);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags, bool force);
    }

    [StructLayout(LayoutKind.Sequential)]
    public class NetResource
    {
        public ResourceScope Scope;
        public ResourceType ResourceType;
        public ResourceDisplaytype DisplayType;
        public int Usage;
        public string LocalName;
        public string RemoteName;
        public string Comment;
        public string Provider;
    }

    public enum ResourceScope : int
    {
        Connected = 1,
        GlobalNetwork,
        Remembered,
        Recent,
        Context
    }

    public enum ResourceType : int
    {
        Any = 0,
        Disk = 1,
        Print = 2,
        Reserved = 8
    }

    public enum ResourceDisplaytype : int
    {
        Generic = 0x0,
        Domain = 0x1,
        Server = 0x2,
        Share = 0x3,
        File = 0x4,
        Group = 0x5,
        Network = 0x6,
        Root = 0x7,
        Shareadmin = 0x8,
        Directory = 0x9,
        Tree = 0xa,
        Ndscontainer = 0xb
    }
    #endregion

    #region User Impersonation
    public class UserImpersonation
    {
        const int LOGON32_LOGON_INTERACTIVE = 2;
        const int LOGON32_LOGON_NETWORK = 3;
        const int LOGON32_LOGON_BATCH = 4;
        const int LOGON32_LOGON_SERVICE = 5;
        const int LOGON32_LOGON_UNLOCK = 7;
        const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;
        const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_PROVIDER_WINNT35 = 1;
        const int LOGON32_PROVIDER_WINNT40 = 2;
        const int LOGON32_PROVIDER_WINNT50 = 3;

        WindowsImpersonationContext impersonationContext;
        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LogonUserA(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]

        public static extern int DuplicateToken(IntPtr ExistingTokenHandle, int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]

        public static extern long RevertToSelf();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern long CloseHandle(IntPtr handle);

        public UserImpersonation()
        {
        }

        public UserImpersonation(string username, string password, string domain)
        {
            impersonateValidUser(username, domain, password);
        }

        public bool impersonateUser(string userName, string domain, string password)
        {
            return impersonateValidUser(userName, domain, password);
        }

        public void undoimpersonateUser()
        {
            undoImpersonation();
        }

        private bool impersonateValidUser(string userName, string domain, string password)
        {
            bool functionReturnValue = false;

            WindowsIdentity tempWindowsIdentity = default(WindowsIdentity);
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            functionReturnValue = false;

            if (RevertToSelf() > 0)
            {
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_WINNT50, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();
                        if ((impersonationContext != null))
                            functionReturnValue = true;
                    }
                }
            }

            if (!tokenDuplicate.Equals(IntPtr.Zero))
            {
                CloseHandle(tokenDuplicate);
            }

            if (!token.Equals(IntPtr.Zero))
            {
                CloseHandle(token);
            }
            return functionReturnValue;
        }

        private void undoImpersonation()
        {
            impersonationContext.Undo();
        }
    }
    #endregion
}
