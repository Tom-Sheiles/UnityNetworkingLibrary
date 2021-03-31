using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientScene : MonoBehaviour
{
    Client client;

    public void StartServer()
    {
        client.ConnectToServer();
    }

    private void Start()
    {
        client = new Client();
    }
}
