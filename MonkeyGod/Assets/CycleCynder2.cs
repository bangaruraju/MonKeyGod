using UnityEngine;
using System.Collections;

public class CycleCynder2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			other.transform.parent = gameObject.transform;

			if (other.attachedRigidbody)
			{
				other.attachedRigidbody.useGravity = true;
			}
		}

	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			other.transform.parent = null;
			if (other.attachedRigidbody) {
				other.attachedRigidbody.useGravity = true;
//				other.attachedRigidbody.isKinematic=true;
			}

		}
	}
}
