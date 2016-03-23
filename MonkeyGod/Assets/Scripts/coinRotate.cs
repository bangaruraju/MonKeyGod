using UnityEngine;
using System.Collections;

public class coinRotate : MonoBehaviour {

	public GameObject[] coinsObj;

	private Rigidbody coinRigidbody;
	//public GameObject singlecoinObj;
	// Use this for initialization
	void Start () {
		coinRigidbody = GetComponent<Rigidbody> ();
		Invoke ("removeCoinObj",10);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.tag == "PickUpCoin")
			transform.Rotate (new Vector3 (0, 45, 0) * 0.4f);
		else
			return;


	}


	void removeCoinObj(){
		if (coinRigidbody) {
			coinRigidbody.gameObject.SetActive (false);
			Destroy (coinRigidbody.gameObject);
		}
	}
}
