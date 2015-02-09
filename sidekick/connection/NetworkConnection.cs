using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace sidekick
{
    public class NetworkConnection
    {
        private string _networkName;

        public NetworkConnection(string networkName, NetworkCredential credentials) {
            _networkName = networkName;

            dynamic netResource = new NetResource { Scope = ResourceScope.GlobalNetwork,
                                                    ResourceType = ResourceType.Disk,
                                                    DisplayType = ResourceDisplaytype.Share,
                                                    RemoteName = networkName };

            dynamic userName = string.IsNullOrEmpty(credentials.Domain) ? credentials.UserName : string.Format("{0}\\{1}", credentials.Domain, credentials.UserName);
            dynamic result = WNetAddConnection2(netResource, credentials.Password, userName, 0);

            if (result != 0)
                throw new Win32Exception(result, "Error connecting to remote share");
        }

        ~NetworkConnection()
        {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
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
}