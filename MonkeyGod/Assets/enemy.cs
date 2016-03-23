using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();

		if (TileManager.IDEAL == 0) {
			anim.SetTrigger ("ske_fireball");
		}
		if (TileManager.IDEAL == 1) {
			anim.SetTrigger ("ske_1weapon");
		}
		if (TileManager.IDEAL == 2) {
			anim.SetTrigger ("ske_2weapon");
		}
		if(TileManager.IDEAL == 3)
		{
			anim.SetTrigger("ske_fireball");
		}
//		Invoke ("functionCall",3);
	}

	void functionCall(){


	}

	// Update is called once per frame
	void Update () {

	
	}
}
