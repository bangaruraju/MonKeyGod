using UnityEngine;
using System.Collections;

public class RotationFinl : MonoBehaviour {
	float targetRotation = 30f; //Rotation to stop at
	float distanceToSlow = 500f; //How far from target to start slowing down
	float minDistance = 10f; //How far from target to stop completely
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 rot = transform.rotation.eulerAngles;
//		float d = targetRotation - rot.z;
////		if(d > minDistance){
////			if(d < distanceToSlow){
////				d = d / distanceToSlow;
////			}
////			else{
////				d = 1f;    
////			}
////		}
////		else{
////			d = 0f;    
////		}
//		
//		//Or shorter
//		d = d > minDistance? d < distanceToSlow? d / distanceToSlow : 1f : 0f;
//		
//		float rotationAmount = 270f * d;
//		
//		rot.z = rot.z + rotationAmount * Time.deltaTime;
//		if (rot.z > 360)
//			rot.z -= 360;
//		else if (rot.z < 360)
//			rot.z += 360;
////		transform.Rotate (new Vector3 (	15f, 30f, 45f) * Time.deltaTime);
//		
//		transform.eulerAngles = rot;
//		transform.Rotate (transform.eulerAngles);
	

//		float h = Input.GetAxis("Horizontal") * minDistance * Time.deltaTime;
//		float v = Input.GetAxis("Vertical") * minDistance * Time.deltaTime;
//		
//		//        _transform.localPosition += _transform.right * h;
//		//        _transform.localPosition += _transform.forward * v;
//		
//		Vector3 RIGHT = transform.TransformDirection(Vector3.right);
//		Vector3 FORWARD = transform.TransformDirection(Vector3.forward);
//		
//		transform.localPosition += RIGHT * h;
//		transform.localPosition += FORWARD * v;
		transform.Rotate (Vector3.forward);
	




	}
}
