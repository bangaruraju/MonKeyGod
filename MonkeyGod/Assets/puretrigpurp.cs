using UnityEngine;
using System.Collections;

public class puretrigpurp : MonoBehaviour {

	public GameObject bat_bomb_blast;


//	void OnCollisionEnter (Collision collision){
//		print ("collision called");
//		if (collision.transform.tag == "batbomb") {
//			GameObject DestroyEffect = (GameObject)Instantiate (bat_bomb_blast, collision.transform.position, Quaternion.identity);
//			collision.transform.gameObject.SetActive(false);
//			StartCoroutine (destroyPS (DestroyEffect,collision.transform.gameObject));
//
//		}
//	}
	void OnTriggerEnter (Collider other)
	{
		try{
		if (other.transform.tag == "batbomb") {
			GameObject DestroyEffect = (GameObject)Instantiate (bat_bomb_blast, other.transform.position, Quaternion.identity);
			other.transform.gameObject.SetActive(false);
			StartCoroutine (destroyPS (DestroyEffect,other.transform.gameObject));

		}
	}
		catch{
		}
	}

	void OnTriggerStay (Collider other){
		try{
		if (other.transform.tag == "batbomb") {
			GameObject DestroyEffect = (GameObject)Instantiate (bat_bomb_blast, other.transform.position, Quaternion.identity);
			other.transform.gameObject.SetActive(false);
			StartCoroutine (destroyPS (DestroyEffect,other.transform.gameObject));
			
		}
		}
		catch{
		}
	}

	
	void OnTriggerExit (Collider other)
	{
		try{
		if (other.transform.tag == "batbomb") {
			GameObject DestroyEffect = (GameObject)Instantiate (bat_bomb_blast, other.transform.position, Quaternion.identity);
			other.transform.gameObject.SetActive(false);
			StartCoroutine (destroyPS (DestroyEffect,other.transform.gameObject));
			
		}
		}
		catch{
		}
	}
	IEnumerator destroyPS (GameObject gameObject,GameObject bombobj)
	{
	//	GameObject.Destroy (bombobj);
		yield return new WaitForSeconds (0.6f);
		bombobj.SetActive (true);
		yield return new WaitForSeconds (0.15f);
		gameObject.transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;
	//	ps.GetComponent<ParticleSystem> ().Stop ();
		yield return new WaitForSeconds (1f);
		GameObject.Destroy (gameObject);

}
}
