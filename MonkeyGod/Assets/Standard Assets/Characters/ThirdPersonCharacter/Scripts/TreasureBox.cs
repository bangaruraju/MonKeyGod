using UnityEngine;
using System.Collections;

public class TreasureBox : MonoBehaviour {

	Animation anim1;
	public bool tboxState;
	public GameObject coin;

	// Use this for initialization
	void Start () {
		tboxState = false;
		anim1 = GetComponent<Animation>();
		GameObject ps_Gobj=(GameObject)Instantiate (coin, transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	public void OpenTreasureBox () {

//		print ("-----000000-----");
		anim1.Play("BoxOpen");
	}
	public void CloseTreasureBox () {


//		print ("-----111111111-----");
		anim1.Play("BoxClose");
	}

	void OnCollisionEnter(Collision collision) {

//		print ("-----vvvvvvvvvvvvvvvvvv-----");

	}
}
