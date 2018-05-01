using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCloudGaming.Classes
{
    class InternetConnection
    {
        public bool ConnectivityCheck()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;

            return isConnected;
        }
    }
}
