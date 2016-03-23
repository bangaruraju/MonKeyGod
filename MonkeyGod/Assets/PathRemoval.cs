using UnityEngine;
using System.Collections;
//namespace UnityStandardAssets.Characters.ThirdPerson
//	{
//	[RequireComponent(typeof (ThirdPersonUserControl))]
	public class PathRemoval : MonoBehaviour {
	public static bool PathRemovalGameOver=false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		IEnumerator FallDown(GameObject obj){
			
			yield return new WaitForSeconds (4f);
			
			DestroyObject (obj);
			
		}

	void OnTriggerExit(Collider other){

//		Debug.Log (other.tag);
//		Debug.Log ("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
//			PlayerPrefs.SetInt("PathRemovalLEFT",1);
			int index=PlayerPrefs.GetInt ("PathRemovalLEFT");
//			if(index == 0){
//				if (other.tag == "Dynamic") {
//				Debug.Log (other.tag);
//					DestroyObject (other.transform.gameObject);
//				}
			if(other.tag == "Dynamic"){
//				DestroyObject (other.transform.gameObject);
				StartCoroutine(FallDown(other.transform.gameObject));
			}
		if (other.tag != "PathRemoval"){
				if (other.tag != "gameOver") {
//					DestroyObject (other.transform.gameObject);
//					StartCoroutine(FallDown(other.transform.gameObject));
				}
				}
//			}
		
	}
//}

}
