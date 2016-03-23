using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaitAgain : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
public	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	public	void OnPauseGame ()
	{
		Time.timeScale = 0.0f;
		PlayerPrefs.SetInt ("isGui", 1);
		PlayerPrefs.SetInt ("UI_DESABLE", 1);
		PlayerPrefs.SetInt ("walkStickStatus",0);
		player = GameObject.FindGameObjectWithTag ("Player");
		TouchController tcScript = player.GetComponent<TouchController> ();
		tcScript.enabled = false;

	}
	public	void OnResumeGame ()
	{
		Time.timeScale = 1.0f;
		PlayerPrefs.SetInt ("isGui", 0);
		PlayerPrefs.SetInt ("UI_DESABLE", 0);
		PlayerPrefs.SetInt ("walkStickStatus",1);
		player = GameObject.FindGameObjectWithTag ("Player");
		TouchController tcScript = player.GetComponent<TouchController> ();
		tcScript.enabled = true;
	}
}
