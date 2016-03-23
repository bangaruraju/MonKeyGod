using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pathscript : MonoBehaviour {

	public Transform[] path;
	private float speed = 0.0f,reachDist = 1.0f;
	private int currentpoint = 0;
	private Animator anim;
	public GameObject textures;

	void Start () {
//		anim = GetComponent<Animator>();
//		anim.SetFloat ("Forward", 1.0f);
		StartCoroutine (speedchange());

	}

	IEnumerator speedchange(){
		yield return new WaitForSeconds (10f);
		speed = 0.2f;
		yield return new WaitForSeconds (4f);
		speed = 0.3f;
	}
	// Update is called once per frame
	void Update () {

		try{
		float dist = Vector3.Distance (transform.position,path[currentpoint].position);
		transform.forward = Vector3.RotateTowards(transform.forward, path[currentpoint].position - transform.position, speed*Time.deltaTime, 0.0f);
		transform.position = Vector3.MoveTowards (transform.position,path[currentpoint].position,Time.deltaTime * speed);
		
		if(dist <= reachDist){
			if(currentpoint <= 9)
			currentpoint++;
		}
		}
		catch{}
	}
	void OnTriggerEnter(Collider collider){

		StartCoroutine (FirstpopupInstantiation());
//		PlayerPrefs.SetString ("LEVEL", "LEVELIII");
//		PlayerPrefs.SetInt ("FIGHTTAG", 2);
//		Application.LoadLevelAsync ("TrainingRoom");
	}
	IEnumerator removeobjects(){
		yield return new WaitForSeconds (6f);
		Destroy(GameObject.Find("ashok_tot_set"));

	}
	GameObject instance;
	IEnumerator FirstpopupInstantiation(){
		yield return new WaitForSeconds (5f);
		instance = Instantiate(Resources.Load("Popup1", typeof(GameObject)),textures.transform.position,Quaternion.identity)as GameObject;
		instance.transform.SetParent (textures.transform);
		StartCoroutine (removeobjects());
	}

	IEnumerator popupInstantiation(){
		yield return new WaitForSeconds (0f);
//		obj = (GameObject)Instantiate (textures, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		Destroy(GameObject.FindGameObjectWithTag("removePopUp"));
		Destroy(GameObject.Find("path"));
		Destroy(GameObject.Find("Directional Light"));
//		Destroy(GameObject.Find("Main Camera"));
	}
	GameObject obj,emptyObj;
	public void popUp()
	{
		if (obj == null) {
			if(textures==null)
			{
				try{
				GameObject[] objects = Object.FindObjectsOfType<GameObject>();
				foreach (GameObject o in objects) {
					Destroy(o);
				}
				}catch{
				}
				PlayerPrefs.SetString ("LEVEL", "LEVELIII");
				PlayerPrefs.SetInt ("FIGHTTAG", 2);
				Application.LoadLevelAsync ("TrainingRoom");
			}
			else{
				emptyObj = GameObject.Find("GameObject");
				if(emptyObj.transform.GetChild(0).name == "Popup1(Clone)")
					createPopUps("Popup2");
				else if(emptyObj.transform.GetChild(0).name == "Popup2(Clone)")
					createPopUps("Popup3");
				else if(emptyObj.transform.GetChild(0).name == "Popup3(Clone)")
					createPopUps("Popup4");
				else if(emptyObj.transform.GetChild(0).name == "Popup4(Clone)")
					createPopUps("Popup5");
				else if(emptyObj.transform.GetChild(0).name == "Popup5(Clone)")
					createPopUps("Popup6");
				else if(emptyObj.transform.GetChild(0).name == "Popup6(Clone)")
					createPopUps("Popup7");
				else if(emptyObj.transform.GetChild(0).name == "Popup7(Clone)")
					createPopUps("Popup8");
				else if(emptyObj.transform.GetChild(0).name == "Popup8(Clone)")
					createPopUps("Popup9");
				else if(emptyObj.transform.GetChild(0).name == "Popup9(Clone)")
					createPopUps("Popup10");
				else if(emptyObj.transform.GetChild(0).name == "Popup10(Clone)")
					createPopUps("Popup11");
				else if(emptyObj.transform.GetChild(0).name == "Popup11(Clone)")
					createPopUps("Popup12");
				else if(emptyObj.transform.GetChild(0).name == "Popup12(Clone)")
					createPopUps("Popup13");
				StartCoroutine(popupInstantiation());
			}
		}
	}
	void createPopUps(string name)
	{
		instance = Instantiate(Resources.Load(name, typeof(GameObject)),textures.transform.position,Quaternion.identity)as GameObject;
		instance.transform.SetParent (emptyObj.transform);
	}
}
