using UnityEngine;
using System.Collections;

public class ForwardRotateRock : MonoBehaviour {
	public float speed = 1f; 
	public float h1 = 0.25f;
	Rigidbody rockRigidbody;
	Vector3 movement;
	private bool movedown = true;

	// Use this for initialization
	void Start () {
		rockRigidbody = GetComponent<Rigidbody> ();
		StartCoroutine (moveDownFalse ());
		StartCoroutine (destroyRock ());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		transform.Rotate (new Vector3 (	-15f, -30f, -45f) * Time.deltaTime);
		Move (h1);
		//transform.position  = transform.position + new Vector3(0.25f,0f,0f);
	}

	void Move(float h){
		if (!movedown) {
			movement.Set (h, 0f, 0f);
			movement = movement.normalized * speed * Time.deltaTime;
			rockRigidbody.MovePosition (transform.position + movement);
		} else {
			movement.Set (0f, -h, 0f);
			movement = movement.normalized * 8 * Time.deltaTime;
			rockRigidbody.MovePosition (transform.position + movement);
		}
	}

	IEnumerator moveDownFalse() {
		yield return new WaitForSeconds(.5f);
		movedown = false;
	}

	IEnumerator destroyRock() {
		yield return new WaitForSeconds(3f);
//		rockRigidbody.gameObject.SetActive(false);
	}
}
