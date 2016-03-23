using UnityEngine;
using System.Collections;

public class FallingTree : MonoBehaviour {

//	public static bool IsTFL=false;
	Animator anim;
	public bool treeState = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	}
	
	// Update is called once per frame
	public void IsTreeFalling (bool treeState) {
//		Debug.Log("^^^^^^^^^^^^&&&&&&&7777777777^^^^^^^^^^^^^^^^^^^^^^");
//		IsTFL = true;
		anim.SetBool ("TreeFall", treeState);
	}


}
