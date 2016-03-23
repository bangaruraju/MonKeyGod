using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
//	private bool dirRight = true;
//	public float speed = 100.0f;
	void Update () {
//		if (dirRight)
//			transform.Translate (Vector2.right * speed * Time.deltaTime);
//		else
//			transform.Translate (-Vector2.right * speed * Time.deltaTime);
//		if(transform.position.x >= 4.0f) {
//			dirRight = false;
//		}
//		if(transform.position.x <= -4) {
//			dirRight = true;
//		}
		transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.9f));
	}
	private Vector3 pos1 = new Vector3(-4,0,0);
	private Vector3 pos2 = new Vector3(4,0,0);
	public float speed = 0f;





}
