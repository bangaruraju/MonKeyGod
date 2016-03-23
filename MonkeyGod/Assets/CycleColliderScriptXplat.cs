using UnityEngine;
using System.Collections;

public class CycleColliderScriptXplat : MonoBehaviour {
	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			other.transform.parent = gameObject.transform;
			if (other.attachedRigidbody)
			{
				other.attachedRigidbody.useGravity = false;
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
			}
		}
	}
	IEnumerator destroyPS (Rigidbody gameObject)
	{
		yield return new WaitForSeconds (1f);
		gameObject.isKinematic=true;
		yield return new WaitForSeconds (0.1f);
		gameObject.isKinematic=false;
		gameObject.transform.localScale = new Vector3 (12f,12f,12f);
	}
}