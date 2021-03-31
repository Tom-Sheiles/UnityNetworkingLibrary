using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Server
{
    private UdpClient udpClient;
    private int port = 25565;
    private bool serverShouldRun = false;

    public void StartServer()
    {
        Debug.Log("start");
        Thread thread = new Thread(new ThreadStart(listenThread));
        thread.Start();
    }

    private void listenThread()
    {
        udpClient = new UdpClient(port);
        Debug.Log("Server Started on port " + port);

        serverShouldRun = true;

        IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);

        byte[] buffer = udpClient.Receive(ref clientEndPoint);
        string clientMessage = Encoding.ASCII.GetString(buffer);

        Debug.Log(clientMessage);

        string response = "Server Response";
        udpClient.Send(Encoding.ASCII.GetBytes(response), response.Length, clientEndPoint);

    }
}
