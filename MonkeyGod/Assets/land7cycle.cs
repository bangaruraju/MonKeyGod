using UnityEngine;
using System.Collections;

public class land7cycle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {

//			other.transform.DetachChildren();
//			transform.localScale = new Vector3(12f,12f,12f);
			other.transform.parent = gameObject.transform;
			if (other.attachedRigidbody)
			{
				other.attachedRigidbody.useGravity = false;
//				other.transform.localScale=new Vector3(1f,1f,12f);
			}
		}

	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			other.transform.parent = null;

			if (other.attachedRigidbody) {
				other.attachedRigidbody.useGravity = true;
				StartCoroutine (destroyPS (other.attachedRigidbody));
//				other.attachedRigidbody.transform.localScale
				other.transform.localScale=new Vector3(12f,12f,12f);

			}

		}
	}

	IEnumerator destroyPS (Rigidbody gameObject)
	{
		yield return new WaitForSeconds (1.5f);
		gameObject.isKinematic=true;
		yield return new WaitForSeconds (0.1f);
		gameObject.isKinematic=false;
	}

}
