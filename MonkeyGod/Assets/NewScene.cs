using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class NewScene : MonoBehaviour {
	
	public Texture2D fullTex;
	public Texture2D emptyTex;
	public Vector2 size = new Vector2(0,0);
	public float barDisplay;
	public bool displayProgressBar = false;
	int noOfSeconds = 0;
	public Font customFont;
	
	//	AsyncOperation async;
	// Use this for initialization
	void Start () {
		
		//		Application.LoadLevelAdditive ("DynamicPath");
		StartCoroutine(load());
	}
	void OnGUI() {
		if (displayProgressBar) {
			GUI.BeginGroup (new Rect (Screen.width / 2f-Screen.width/1.2f/2, Screen.height / 1.1f, Screen.width/1.15f, Screen.height / 2));
			GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f, Screen.height / 11), emptyTex);
			GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f*(barDisplay),Screen.height / 11),fullTex);

			GUI.skin.label.normal.textColor = Color.white;
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			GUI.Label (new Rect(0,0,Screen.width/1.2f,Screen.height / 11), "LOADING");
			GUI.EndGroup ();
			
		}
	}
	// Update is called once per frame
	void Update () {
		if (displayProgressBar) {
			barDisplay = (noOfSeconds /2.1f);
		}
	}
	
	IEnumerator load() {
		startProgressBar ();
		yield return new WaitForSeconds (3f);
		//		Debug.LogWarning("ASYNC LOAD STARTED - " +
		//		                 "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
		string SceneTO=PlayerPrefs.GetString ("SceneTO");
		if(SceneTO.Equals("UFE")){
			Application.LoadLevel("TrainingRoom");
		}else if(SceneTO.Equals("DYNMAIC")){
			Application.LoadLevel("DynamicPath");
			//			Application.LoadLevel("LoadingScene");
		}
		
		//		async = 
		//			Application.LoadLevel("DynamicPath");
		//		async.allowSceneActivation = false;
		//		yield return async;
	}
	public void stopProgressBar(){
		displayProgressBar = false;
	}
	public void startProgressBar(){
		displayProgressBar = true;
		noOfSeconds = 0;
		StartCoroutine(Example());
	}
	IEnumerator Example() {
		yield return new WaitForSeconds(1);
		noOfSeconds = noOfSeconds + 1;
		if(noOfSeconds<3){
			StartCoroutine(Example());
		}
		else {
			//		displayProgressBar = false;
			noOfSeconds = 0;
		}
	}
}
