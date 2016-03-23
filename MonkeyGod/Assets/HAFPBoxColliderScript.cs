using UnityEngine;
using System.Collections;

public class sci : MonoBehaviour {

	//private playerBehaviour mScript;

	// Use this for initialization
	void Start () {
	//	mScript = transform.parent.GetComponent(playerBehaviour);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
//		if (other.transform.tag == "HangMoveForward") {
//			//playerBehaviour.ha
//			if(this.transform.parent.GetComponent<playerBehaviour> ().hangingState !=0)
//				StartCoroutine(hangUp());
//				//this.transform.parent.GetComponent<playerBehaviour> ().hangingState = 3;
//			Debug.Log("HangMoveForward");
//		}

	}
//	IEnumerator hangUp() {
////		yield return new WaitForSeconds (.1f);
////		this.transform.parent.GetComponent<playerBehaviour> ().hangingState = 3;
////		yield return new WaitForSeconds (.05f);
//		this.transform.parent.GetComponent<playerBehaviour> ().hangingState = 4;
//		yield return new WaitForSeconds (.05f);
//		this.transform.parent.GetComponent<playerBehaviour> ().hangingState = 5;
//		yield return new WaitForSeconds (.5f);
//		this.transform.parent.GetComponent<playerBehaviour> ().hangingState = 0;
//	}

}
