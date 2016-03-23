using UnityEngine;
using System.Collections;

public class MushCross : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnTriggerEnter(Collider other) {
//		Debug.Log("******** =-----------OnCollisionEnter ******** ");
////		Destroy(other.gameObject);
//	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("******** =-----------MushCross ******** ");
		if (collision.transform.tag == "MushCross") {
			Debug.Log("******** MushCross ******** ");
			collision.transform.gameObject.SetActive(false);
			BoxCollider boxCollider = collision.transform.gameObject.GetComponent<BoxCollider>();
			boxCollider.isTrigger = true;
		}
	}

}
