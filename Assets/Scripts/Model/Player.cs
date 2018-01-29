using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    private int id;
    private string login;

    private Vector3 pos;
    
    public Player(int id, string login, float x, float y, float z)
    {
        this.id = id;
        this.login = login;
        pos = new Vector3(x, y, z);
    }
    
    
}
