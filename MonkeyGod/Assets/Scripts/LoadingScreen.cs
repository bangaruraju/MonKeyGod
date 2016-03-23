using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	private bool loading = true;
	
	public Texture loadingTexture;
	public Texture2D healthBGTexture;
	public Texture2D healthFGTexture;
	public int health = 10;
	
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
		if (Application.isLoadingLevel) {
			loading = true;
			health = health + 5;
			Debug.Log ("health " + health);
		} else {
			loading = false;
			health = 10;
		}

	}
	
	void OnGUI () {
		if (loading) {
			GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);
			GUI.BeginGroup(new Rect(Screen.width / 2f - healthBGTexture.width/10, Screen.height / 1.9f, healthBGTexture.width/5, healthBGTexture.height));
			GUI.DrawTexture (new Rect(0,0, healthBGTexture.width/5, healthBGTexture.height), healthBGTexture, ScaleMode.StretchToFill, true, 0f);
			GUI.DrawTexture (new Rect (0,0, healthBGTexture.width/5 * (health/500), healthBGTexture.height), healthFGTexture, ScaleMode.StretchToFill, true, 0f);
			GUI.EndGroup();
		}
	}
}
