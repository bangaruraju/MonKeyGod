using UnityEngine;
using System.Collections;

public class boxRotate : MonoBehaviour {

//	private Rigidbody coinRigidbody;

	// Use this for initialization
//	void Start () {
//		coinRigidbody = GetComponent<Rigidbody> ();
//	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 45, 0) * 0.1f);
	}
}
