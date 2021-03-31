using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerScene : MonoBehaviour
{
    Server server;

    public void StartServer()
    {
        server.StartServer();
    }

    private void Start()
    {
        server = new Server();
    }
}
