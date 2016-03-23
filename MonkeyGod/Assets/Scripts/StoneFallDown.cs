using UnityEngine;
using System.Collections;

public class StoneFallDown : MonoBehaviour {

	public bool StoneFallingStatus = false;
	public float speed = 1f; 
	public float h1 = 1;//0.25f;
	Rigidbody rockRigidbody;
	Vector3 movement;
	private bool movedown = true;
	public bool destroyStone = false;
	
	// Use this for initialization
	void Start () {
		rockRigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (StoneFallingStatus) {
			Move (h1);
		}
		if (destroyStone)
			StartCoroutine (destroyRock ());
	}
	
	void Move(float h){
			movement.Set (0f, -h, 0f);
			movement = movement.normalized * 8 * Time.deltaTime;
			rockRigidbody.MovePosition (transform.position + movement);
	}
	
	IEnumerator destroyRock() {
		yield return new WaitForSeconds(0.5f);
		Destroy (rockRigidbody.gameObject);
	}
}
