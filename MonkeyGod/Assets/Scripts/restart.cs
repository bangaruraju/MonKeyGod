using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class restart : MonoBehaviour {
	public Button restartbtn;
	private int  fontSize  = 30;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	

	}
	void OnEnable () {
//		button = gameObject.GetComponent<Selectable>();
//
//
//		Debug.Log(button.interactable.ToString());
//		if(button.is)
//		Application.LoadLevel ("DynamicPath");
	}
	void OnGUI()
	{ 

		//GUI.Box(new Rect(Screen.width - 200 , 45 ,120 , 350), "");
		GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;

		if (GUI.Button (new Rect (Screen.width/2 -108, Screen.height/2 +10, 185, 37), "Restart")) {

			Application.LoadLevel("DynamicPath");
		}
	}
}