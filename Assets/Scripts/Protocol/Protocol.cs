using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;
using System.Runtime.Remoting;

abstract public class Protocol
{
	public static string error;
	public static List<string> recives = new List<string>();


	protected int reconnect = 0;
	public Protocol()
	{
		Debug.Log("Соединяемся с сервером");
		Connect();
	}

	protected abstract void Connect();
	public abstract void Send(string data);

    public static explicit operator Protocol(ObjectHandle v)
    {
        throw new NotImplementedException();
    }
}