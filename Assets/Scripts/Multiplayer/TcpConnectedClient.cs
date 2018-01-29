using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class TcpConnectedClient
{
	private readonly TcpClient connection;
	
	readonly byte[] readBuf = new byte[5000];


	private NetworkStream stream
	{
		get { return connection.GetStream(); }
	}


	public TcpConnectedClient(TcpClient client)
	{
		connection = client;
		connection.NoDelay = true;
		if (TcpController.instance.isServer)
			stream.BeginRead(readBuf, 0, readBuf.Length, OnRead, null);
	}


	internal void Close()
	{
		connection.Close();
	}
	
	void OnRead(IAsyncResult ar)
	{
		int length = stream.EndRead(ar);
		if (length <= 0)
		{
			TcpController.instance.OnDisconnect(this);
			return;
		}

		string newMsg = Encoding.UTF8.GetString(readBuf, 0, length);

		FastDataObject fdo = new FastDataObject(newMsg);
		String action = fdo.getParameter("action");

		Packet packet = PacketManager.getPacket(action);
		
		Data.Players.Add(new Player());

		if (TcpController.instance.isServer)
			TcpController.BroadcastMessage(newMsg);

		stream.BeginRead(readBuf, 0, readBuf.Length, OnRead, null);
	}

	internal void EndConnect(IAsyncResult ar)
	{
		connection.EndConnect(ar);
		stream.BeginRead(readBuf, 0, readBuf.Length, OnRead, null);
	}

	internal void Send(string msg)
	{
		byte[] buf = Encoding.UTF8.GetBytes(msg);
		stream.Write(buf, 0, buf.Length);
	}
	
}
