using UnityEngine;
using System.Collections;

public class FloatHanScript : MonoBehaviour {

	private bool JetPackStatus = true;
	private Rigidbody m_Rigidbody;
	private Animator m_animator;
	public GameObject ps;
	 public GameObject obj;
	void Start () {
		m_animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
		m_animator.SetBool ("JetPack", true);

		int Fightabc=PlayerPrefs.GetInt ("FIGHTTAG");
		string level_fgt = PlayerPrefs.GetString("LEVEL");
		PlayerPrefs.SetInt ("jetpackSpeedCheck", 0);

		if (PlayerPrefs.GetInt ("FIGHTRESULT") == 2) {
			transform.position = new Vector3 (transform.position.x + 800, transform.position.y, transform.position.z);
		}
		else if(PlayerPrefs.GetInt ("FIGHTRESULT") == 1){
			foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
				if(o.gameObject.tag.Equals("removeCutPrefab")){
					Destroy(o);
				}
				else{
				}
			}
			JetPackStatus = false;
			obj = GameObject.Instantiate(obj);
		}
	}

	void FixedUpdate()
	{
		int speed = PlayerPrefs.GetInt ("jetpackSpeedCheck");
		if (JetPackStatus){
			if(speed == 0)
			transform.position = Vector3.Lerp (m_Rigidbody.transform.position, new Vector3(transform.position.x+1.0f,transform.position.y,transform.position.z), 30f * Time.deltaTime); 
			else if(speed == 1)
				transform.position = Vector3.Lerp (m_Rigidbody.transform.position, new Vector3(transform.position.x+1.0f,transform.position.y,transform.position.z), 5f * Time.deltaTime); 

		}
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.name == "Trak") {
			m_animator.SetBool ("JetPack", false);
			m_Rigidbody.isKinematic = false;
			JetPackStatus = false;
			transform.GetChild (0).gameObject.SetActive (false);
		}
		else if (other.gameObject.name == "base") {
			m_animator.SetBool ("JetPack", false);
			m_Rigidbody.isKinematic = false;
			JetPackStatus = false;
			transform.GetChild (0).gameObject.SetActive (false);
		}
		else if (other.gameObject.name == "Lion Face") {
			PlayerPrefs.SetInt ("jetpackSpeedCheck", 1);
			transform.position = Vector3.Lerp (m_Rigidbody.transform.position, new Vector3(transform.position.x+1.0f,transform.position.y+3.5f,transform.position.z), 1f * Time.deltaTime); 
			other.gameObject.transform.root.GetChild(8).GetComponent<Animator>().enabled = false;
			m_animator.SetBool ("JetPack", true);
			m_Rigidbody.isKinematic = true;
			JetPackStatus = true;
			transform.GetChild (0).gameObject.SetActive (true);
		}
		else if (other.gameObject.name == "Lower_Jaw") {
//			Debug.Log("lower jaw collided");
			PlayerPrefs.SetInt ("homeSceneUI", 1);
			//        Application.LoadLevel("LoadingScene");
			PlayerPrefs.SetString("SceneTO","DYNMAIC");
			Application.LoadLevel ("NewScene");		}

	}
	void OnCollisionEnter (Collision collision){
		if (collision.collider.transform.name == "pCube3") {
			PlayerPrefs.SetInt("FIGHTTAG",4);
			PlayerPrefs.SetString("LEVEL","LEVELII");
			Application.LoadLevel("TrainingRoom");
		}
	}
}
