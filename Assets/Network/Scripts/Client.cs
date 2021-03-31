using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Client
{
    private UdpClient udpClient = new UdpClient(0);
    private int port = 25565;

    public void ConnectToServer()
    {
        Thread clientListenThread = new Thread(clientListen);
        clientListenThread.Start();

        string hostname = Dns.GetHostName();
        Debug.Log(hostname);
        udpClient.Connect(hostname, port);

        string message = "Client Sent";

        udpClient.Send(Encoding.ASCII.GetBytes(message), message.Length);
    }

    private void clientListen()
    {
        IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, port);

        byte[] buffer = udpClient.Receive(ref serverEndpoint);
        string clientMessage = Encoding.ASCII.GetString(buffer);
        Debug.Log(clientMessage);
    }
}
