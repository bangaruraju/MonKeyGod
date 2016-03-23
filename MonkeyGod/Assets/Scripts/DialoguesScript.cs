using UnityEngine;
using System.Collections;

public class DialoguesScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public	void destroySeetha01UI()
	{
		PlayerPrefs.SetInt("isGui",0);
		PlayerPrefs.SetInt ("Seetha01", 1);
		Destroy (this.gameObject);
	}
}
