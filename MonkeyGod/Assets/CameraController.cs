using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	
	private Vector3 offset;
	public bool rotateCamera;
	public bool currentCamPos = false;
	private float posIncr = 0f;
	
	void Start ()
	{
		offset = transform.position - player.transform.position;
//		Application.CaptureScreenshot("Screenshot.png");
	}
	
	void LateUpdate ()
	{
//		transform.position = player.transform.position + offset;
		if(rotateCamera){

			Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x,70,Camera.main.transform.eulerAngles.z);
			if(player !=null)
			transform.position = player.transform.position + offset + new Vector3(-15,0,15);

//			Vector3 cameraPosition = new Vector3(0,0,0);
//			if(currentCamPos){
////				cameraPosition =  player.transform.position + offset;
//				currentCamPos = false;
//			}
////			Vector3 camPos = Vector3.Lerp(new Vector3(0,0,0), new Vector3(-25,0,25), 0.5f);
//			if(posIncr<15)
//				posIncr = posIncr + 0.1f;
//			Vector3 camPos = new Vector3(-(posIncr),0,posIncr);
//			transform.position = player.transform.position + offset + camPos;
//			Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, new Vector3(Camera.main.transform.eulerAngles.x,70,Camera.main.transform.eulerAngles.z), Time.deltaTime*1f);
		} else
			transform.position = player.transform.position + offset;
	}
}
