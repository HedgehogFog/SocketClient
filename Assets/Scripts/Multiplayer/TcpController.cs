using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TcpController : MonoBehaviour
{
    private readonly TcpClient connection;

    public static TcpController instance;

    public bool isServer;

    public IPAddress serverIP;

    List<TcpConnectedClient> clientList = new List<TcpConnectedClient>();

    public static string messageToDisplay;

    public Text text;

    private TcpListener listener;

    // Use this for initialization
    void Awake()
    {
        serverIP = Data.ip;
        instance = this;
        
        
        TcpClient tcpClient = new TcpClient();
        TcpConnectedClient connectedClient = new TcpConnectedClient(tcpClient);
        tcpClient.BeginConnect(serverIP, Data.port, ar => connectedClient.EndConnect(ar), null);

        LoginController.generatePlayer(Data.login);

    }


    private void OnApplicationQuit()
    {
        if (listener != null)
            listener.Stop();
        for (int i = 0; i < clientList.Count; i++)
        {
            clientList[i].Close();
        }
    }

    public float time = 1.0f;
    private float _time;

    private int i;

    // Update is called once per frame
    void Update()
    {
        if (_time >= time)
        {
            TimeSpan timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            long millis = (long) timeSpan.TotalMilliseconds;
//			Send("action:ping;t:" + millis);
        }
        else
            _time += Time.deltaTime;
    }

    void OnServerConnect(IAsyncResult ar)
    {
        TcpClient tcpClient = listener.EndAcceptTcpClient(ar);
        clientList.Add(new TcpConnectedClient(tcpClient));
        listener.BeginAcceptSocket(OnServerConnect, null);
    }

    internal void OnDisconnect(TcpConnectedClient client)
    {
        clientList.Remove(client);
    }

    internal void Send(string msg)
    {
        BroadcastMessage(msg);
        if (isServer)
            messageToDisplay += msg + Environment.NewLine;
    }

    internal static void BroadcastMessage(string newMsg)
    {
        foreach (var client in instance.clientList)
            client.Send(newMsg);
    }
}