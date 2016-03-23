using System.Collections;
using UnityEngine;
using SocketIO;

public class SOCKETIO2 : MonoBehaviour {
	private SocketIOComponent socket;
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
		socket.On("open", TestOpenn);

	}
	public void TestOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void TestOpenn(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
}
