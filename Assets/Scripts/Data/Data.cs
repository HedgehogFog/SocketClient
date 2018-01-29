using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public static class Data
{
	public const int port = 9999;

	public static IPAddress ip;
	public static string login;

	public static List<Player> Players = new List<Player>();
}
