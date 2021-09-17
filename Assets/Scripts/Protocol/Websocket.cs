using System;
using System.Text;
using UnityEngine;
using WebSocketSharp;

public class Websocket: Protocol
{
	private WebSocketSharp.WebSocket connect;

	protected override void Connect()
	{
		try
		{
			connect = new WebSocket("ws://95.216.204.181:8081");
			connect.OnClose += OnClose;
			connect.OnMessage += OnMessage;
			connect.OnOpen += OnOpen;
			connect.OnError += OnError;
			connect.Connect();
		}
		catch (Exception ex)
		{
			error = "Ошибка соединения " + ex.Message;
		}
	}

	private void OnOpen(object sender, EventArgs e)
	{
		Debug.Log("Соединение с севрером установлено");
		reconnect = 0;
	}

	private void OnError(object sender, ErrorEventArgs e)
	{
		error = "Ошибка соединения " + e.Message;
	}


	private void OnMessage(object sender, MessageEventArgs e)
	{
		recives.Add(e.Data);	
	}


	private void OnClose(object sender, CloseEventArgs e)
	{
		/*if (reconnect < 5 && !e.WasClean)
		{
			Debug.Log("Соединение с сервером закрыто: " + e.Reason + ", устанавливаю новое");
			if (!connect.IsAlive)
			{
				Thread.Sleep(5000);
				reconnect++;
				connect.Connect();
			}
		}
		else*/
			error = "Соединение с сервером закрыто " + e.Reason;
	}


	public override void Send(string data)
	{
		try
		{
			Debug.Log(DateTime.Now.Millisecond + " Отправили серверу " + data);
			byte[] sendBytes = Encoding.ASCII.GetBytes(data);
			connect.Send(sendBytes);
		}
		catch (Exception ex)
		{
			error = ex.Message;
		}
	}
}