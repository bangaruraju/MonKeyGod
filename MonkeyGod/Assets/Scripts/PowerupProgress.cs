	using UnityEngine;
	using System.Collections;

	public class PowerupProgress : MonoBehaviour {


	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(0,0);
	public Vector2 size = new Vector2(0,0);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public bool displayProgressBar = false;
	int noOfSeconds = 0;

	void OnGUI() {
		if (displayProgressBar) {
			GUI.BeginGroup(new Rect(Screen.width/2.6f, Screen.height/2.2f, emptyTex.width/7f, emptyTex.height));
			GUI.DrawTexture (new Rect(0,0, emptyTex.width/5, emptyTex.height), emptyTex, ScaleMode.StretchToFill, true, 0f);
			GUI.DrawTexture (new Rect(0,0,emptyTex.width/5 * (1-barDisplay), emptyTex.height), fullTex, ScaleMode.StretchToFill, true, 0f);
			GUI.EndGroup();
		}
	}

	void Update() {
		if (displayProgressBar) {
			barDisplay = (noOfSeconds /20f);
		}
	}

	public void stopProgressBar(){
		displayProgressBar = false;
		noOfSeconds = -1;
		StopCoroutine(Example());
	//		Debug.Log ("stopProgressBar");
	}

	public void startProgressBar(){
		stopProgressBar ();
		displayProgressBar = true;
		noOfSeconds = 0;
		StartCoroutine(Example());
	}

	IEnumerator Example() {
		yield return new WaitForSeconds(1);
		noOfSeconds = noOfSeconds + 1;
	//		Debug.Log ("noOfSeconds" + noOfSeconds);
		if(noOfSeconds<20 && noOfSeconds>0){
			StartCoroutine(Example());
		}
		else {
			stopProgressBar();

		}
	}
}
