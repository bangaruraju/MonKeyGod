using UnityEngine;
using System.Collections;

public class WaitUI : UFEScreen {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void wait()
	{
		UFE.HideScreen (UFE.currentScreen);
		PlayerPrefs.SetString ("WaitScene","UFE_WAIT");
		UFE.timerUI (0f);
	}
	public void cancel()
	{

	}
}
