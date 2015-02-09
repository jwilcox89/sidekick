﻿using System.Net;

namespace sidekick
{
    public class NetworkConnectionManager
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
        public NetworkConnectionManager(string username, string password, string domain, string fileSharePath) {
            _userImpersonation = new UserImpersonation(username, password, domain);
            _networkCredential = new NetworkCredential(username, password, domain);
            _networkConnection = new NetworkConnection(fileSharePath, _networkCredential);
        }

        /// <summary>
        ///     Undo the impersonation attempt
        /// </summary>
        public void UndoImpersonateUser() {
            _userImpersonation.undoimpersonateUser();
        }
    }
}
