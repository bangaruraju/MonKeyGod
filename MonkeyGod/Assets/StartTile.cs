using UnityEngine;
using System.Collections;

public class StartTile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int random = Random.Range (0, 3);
		transform.GetChild (1).GetChild (random).gameObject.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
