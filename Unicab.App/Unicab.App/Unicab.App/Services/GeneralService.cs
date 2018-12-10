using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net;

namespace Unicab.App.Services
{
    public static class GeneralService
    {
        //public static IPStatus TestServerStatus(string url)
        //{
        //    try
        //    {

        //        TcpClient tcpClient = new TcpClient();
        //        tcpClient.Connect(Common.AppServerConstants.AppServerUrl, Common.AppServerConstants.AppServerPort);
        //        Debug.WriteLine("Port open, server is up");
        //        return IPStatus.Success;
        //    }
        //    catch (SocketException e)
        //    {
        //        Debug.WriteLine("Port not open, server is down");
        //        Debug.WriteLine(e.Message);
        //        return IPStatus.DestinationUnreachable;
        //    }

        //}
    }
}
