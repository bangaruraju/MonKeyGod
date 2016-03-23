using UnityEngine;
using System.Collections;

public class RollingRockScript : MonoBehaviour {

	Rigidbody logRigidbody;
	Vector3 movement;
	public bool startMoving = false;
	// Use this for initialization
	void Start () {
		logRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (startMoving) {
			logRigidbody.isKinematic = false;
			logRigidbody.transform.Rotate (0, 0, -1f);
			movement.Set (10f, 0f, 0f);
			movement = movement.normalized * 1 * Time.deltaTime;
			logRigidbody.MovePosition (transform.position + movement);
			Transform t = transform.parent.GetChild (1).transform;
			t.position = new Vector3 (transform.position.x, transform.position.y + 0.7f, transform.position.z);
			Transform t2 = transform.parent.GetChild (2).transform;
			t2.position = new Vector3 (transform.position.x + 0.4f, transform.position.y + 3.2f, transform.position.z);
		} else {
			logRigidbody.isKinematic = true;
		}
	}
}
