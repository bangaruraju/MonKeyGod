using UnityEngine;
using System.Collections;

public class load2 : MonoBehaviour {
	public GameObject loading_;
	private GameObject loading_Two;
	// Use this for initialization
	void Start () {
	
	}
	void OnGUI()
	{
		if(loading_Two ==null )
			loading_Two = (GameObject)Instantiate (loading_, new Vector3 (Screen.width/2, Screen.height/2, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
