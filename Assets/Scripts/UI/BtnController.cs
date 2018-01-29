using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour {

    public Text text;
    
    public void ClientStartClick()
    {
        
        IPAddress ip = IPAddress.Parse("127.0.0.1");

        Data.ip = ip;
        Data.login = text.text;        

        SceneManager.LoadScene(1);
//        TcpChat.instance.Send("action:login;h:" + transform.position + ";");
        
    }
    
}
