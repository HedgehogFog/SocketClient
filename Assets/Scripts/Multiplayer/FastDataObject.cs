using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FastDataObject {
    private string split=":";
    private string dataName;
    private Dictionary<string, string> prms;
    private HashSet<string> keySet;
    public FastDataObject(string data)
    {
        prms = new Dictionary<string, string>();
        
        int l1 = data.Split(';').Length;
        
        string[] parse = new string[l1];
        
        parse = data.Split(';');
        
        foreach (var vals in parse)
        {
            string[] keysik = vals.Split(':');
            prms.Add(keysik[0], keysik[1]);
        }
        
        keySet = new HashSet<string>(prms.Keys);
        
    }

    public FastDataObject(byte[] bytes)
    {
//        string data = bytes;
//        int l1 = data.split(";").length;
//        string[] parse = new string[l1];
//        parse = data.split(";");
//        for (string vals:parse)
//        {
//            string[] keysik = vals.split(":");
//            prms.put(keysik[0], keysik[1]);
//        }
//        keySet=prms.keySet();
    }


    public FastDataObject(){}

//    public void addFloat(string key, float value)
//    {
//        prms.Add(key, value.Tostring());
//        keySet = new HashSet<string>(prms.Keys);
//    }
//
//    public void addInt(string key, int value)
//    {
//        prms.Add(key, value.Tostring());
//        keySet = new HashSet<string>(prms.Keys);
//    }
//
//    public void addstring(string key, string value)
//    {
//        prms.put(key, value);
//        keySet=prms.keySet();
//    }
//
//    public void addBoolean(string key, Boolean value)
//    {
//        prms.put(key, value.tostring());
//        keySet=prms.keySet();
//    }
//
//    public void addDouble(string key, Double value)
//    {
//        prms.put(key, value.tostring());
//        keySet=prms.keySet();
//    }
//
//    public byte[] generateData()
//    {
//        string result="";
//        Collection<string> param = prms.values();
//        Set<string> keys = prms.keySet();
//        string[] key = (string[])keys.toArray();
//        string[] datastrings = (string[]) param.toArray();
//        for(string string:key)
//        {
//            result+=string+":"+prms.get(key)+";";
//        }
//        return result.getBytes();
//    }
//
//    public string generatestring()
//    {
//        string result="";
//        Collection<string> param = prms.values();
//        Set<string> keys = prms.keySet();
//        string[] key = (string[])keys.toArray();
//        string[] datastrings = (string[]) param.toArray();
//        for(string string:key)
//        {
//            result+=string+":"+prms.get(key)+";";
//        }
//        return result;
//    }

    public string getParameter(int i)
    {
        return prms[getKey(i)];
    }

    public string getParameter(string Key)
    {
        return prms[Key];
    }

    public float getFloat(string key)
    {
        return Convert.ToSingle(prms[key]);
    }

    public float getFloat(int key)
    {
        return Convert.ToSingle(prms[getKey(key)]);
    }

    public int getInt(string key)
    {
        return Convert.ToInt32(prms[key]);
    }

    public int getInt(int key)
    {
        return Convert.ToInt32(prms[getKey(key)]);
    }

    public string getString(string key)
    {
        return prms[key];
    }

    public string getString(int key)
    {
        return prms[getKey(key)];
    }

    private string getKey(int i)
    {
        string[] keys = keySet.ToArray();
        return keys[i];
    }
}