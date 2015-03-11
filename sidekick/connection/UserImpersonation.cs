﻿using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace sidekick
{
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

        public UserImpersonation() {}

        public UserImpersonation(string username, string password, string domain) {
            impersonateValidUser(username, domain, password);
        }

        public bool impersonateUser(string userName, string domain, string password) {
            return impersonateValidUser(userName, domain, password);
        }

        public void undoimpersonateUser() {
            undoImpersonation();
        }

        private bool impersonateValidUser(string userName, string domain, string password){
            bool functionReturnValue = false;

            WindowsIdentity tempWindowsIdentity = default(WindowsIdentity);
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            functionReturnValue = false;

            if (RevertToSelf() > 0) {
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_WINNT50, ref token) != 0) {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0) {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();
                        if ((impersonationContext != null))
                            functionReturnValue = true;
                    }
                }
            }

            if (!tokenDuplicate.Equals(IntPtr.Zero)) {
                CloseHandle(tokenDuplicate);
            }

            if (!token.Equals(IntPtr.Zero)) {
                CloseHandle(token);
            }
            return functionReturnValue;
        }

        private void undoImpersonation() {
            impersonationContext.Undo();
        }
    }
}