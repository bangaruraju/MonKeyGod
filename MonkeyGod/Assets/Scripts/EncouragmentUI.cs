using UnityEngine;
using System.Collections;

public class EncouragmentUI : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public	void destroyEncouragmentUI()
	{
		Time.timeScale = 1;
		PlayerPrefs.SetInt("isGui",0);
		Destroy (this.gameObject);

	}

}
