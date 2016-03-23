using UnityEngine;
using System.Collections;

public class load : MonoBehaviour {

	// Use this for initialization

	private AsyncOperation aO;
	public void Start(){
		StartCoroutine (Load_Game ());

//		Resources.UnloadUnusedAssets();
//		aO=Application.LoadLevelAsync ("DynamicPath");
//		yield return aO;
	
	}

	/*
	 *   Alternate fn for LoadGame
	 */

	IEnumerator Load_Game ()
	{
		yield return new WaitForSeconds (1f);

////		Resources.UnloadUnusedAssets();
//		foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
//			//			yield return new WaitForSeconds (1f);
//			//			Debug.Log(o.name);
//			if(!o.name.Equals("Main Camera"))
//				Destroy(o);
//		}
		Application.LoadLevel ("DynamicPath");
//		Application.LoadLevel ("NewScene");
//		Application.LoadLevel ("DynamicPath");


	}


//	IEnumerator Load_Game2 ()
//	{
//		yield return new WaitForSeconds (0.2f);
//		//	Debug.Log("HHHHHHH");
//		foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
//			//		Debug.Log(o.name);
//			Destroy(o);
//		}
//	}
	


	public Texture loadingTexture;
	public Texture2D healthBGTexture;
	public Texture2D healthFGTexture;
	public float health = 10f;
	public Font customFont;

	void Update () {
//		health = aO.progress;
//		if(health == 0.9f){
//			StartCoroutine (Load_Game2 ());
//		}
		health = 0.8f;
	}
	
	void OnGUI () {
		GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);
		GUI.BeginGroup (new Rect (Screen.width / 2f-Screen.width/1.2f/2, Screen.height / 1.1f, Screen.width/1.15f, Screen.height / 2));
		GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f, Screen.height / 11), healthBGTexture);
		GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f*(health/0.9f),Screen.height / 11),healthFGTexture);
		GUI.skin.label.normal.textColor = Color.white;
		GUI.skin.label.fontSize = 30;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.skin.label.font = customFont;
		GUI.Label (new Rect(0,0,Screen.width/1.2f,Screen.height / 11), "LOADING");
		GUI.EndGroup();
	}
}
