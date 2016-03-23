using UnityEngine;
using System.Collections;

public class coinRotate1 : MonoBehaviour {

	public GameObject[] coinsObj;

	private Rigidbody coinRigidbody;
	//public GameObject singlecoinObj;
	// Use this for initialization
	void Start () {
		coinRigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.tag == "PickUpCoin") {
			transform.Rotate (new Vector3 (0, 45, 0) * 0.4f);

			//float ff = Random.Range(0.1f,2.0f);

//			transform.Translate(transform.up);

		}
		else
			return;
	}


	void removeCoinObj(){


		print("-----------------NNNNNNNNNN--------");
		if (coinRigidbody) {
			coinRigidbody.gameObject.SetActive (false);
			Destroy (coinRigidbody.gameObject);
		}
	}
}
