using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeScreenController : MonoBehaviour {


	public GameObject Seetha01UI,store_UI;

	bool isSoundOn = true;
	public Sprite soundOn;
	public Sprite soundOff;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("isGui",1);
		Image img = this.gameObject.transform.GetChild (0).GetComponent<Image> ();
		if (PlayerPrefs.GetInt ("isSoundOn") == 0) {
			isSoundOn = true;
			img.sprite = soundOn;
			AudioListener.volume = 1;
		} else {
			isSoundOn = false;
			img.sprite = soundOff;
			AudioListener.volume = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public	void startGame()
	{

//		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetString ("LEVEL", "LEVELI");
//		PlayerPrefs.SetString("LEVEL","LEVELI");
//		PlayerPrefs.SetString("LEVELTILESCREATED","YES");
//		TileManager.Instance.level1Prefabs ();
		Destroy (this.gameObject);
		PlayerPrefs.SetInt("isGui",0);
		PlayerPrefs.SetInt ("UI_DESABLE",0);
//		
//		if (PlayerPrefs.GetInt ("Seetha01") == 0) {
//			
//			GameObject Seetha01 = (GameObject)Instantiate (Seetha01UI, new Vector3 (0f, 0f, 0f), Quaternion.identity);
//			PlayerPrefs.SetInt("isGui",1);
//		}
		

	}

	public	void leaderBoard()
	{
		PlayerPrefs.SetInt ("leaderBoardUI", 1);
//		PlayerPrefs.SetInt ("homeSceneUI", 1);
//		PlayerPrefs.SetInt("isGui",0);
//		PlayerPrefs.SetInt ("UI_DESABLE",0);
//		Destroy (this.gameObject);
		
	}

	public void level(){

//		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetString ("LEVEL", "LEVELII");


//		PlayerPrefs.SetString("LEVEL","LEVELII");
//		PlayerPrefs.SetString("LEVELTILESCREATED","YES");
		PlayerPrefs.SetInt("isGui",0);
		PlayerPrefs.SetInt ("UI_DESABLE",0);
		//		map ();
		Destroy (this.gameObject);
//		GameObject thePlayer = GameObject.Find("H T_P F R_Prefab");
//		playerBehaviour playerScript1 = thePlayer.GetComponent<playerBehaviour>();
//		playerScript1.istexture = true;
////		playerScript1.loading_br = 0f;
//		PlayerPrefs.SetFloat ("loading_br",0);

//		TileManager.Instance.level2Prefabs ();
	}

	public	void store()
	{
//		PlayerPrefs.SetInt ("homeSceneUI", 1);
//		PlayerPrefs.SetInt("isGui",0);
//		PlayerPrefs.SetInt ("UI_DESABLE",0);
//		Destroy (this.gameObject);

//		PlayerPrefs.SetString ("FROMHOME","true");
//		PlayerPrefs.SetInt ("DiamondsDisplay",100);
		GameObject store12 = (GameObject)Instantiate (store_UI, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		PlayerPrefs.SetString ("ISFROM-DIALESS-DIALOG", "FALSE");
		PlayerPrefs.SetString("IS-TO-INIT-COINPREFAB","FALSE");
		PlayerPrefs.SetString ("ISFROMARMOUR",null);
	}

	public	void map()
	{
//		PlayerPrefs.SetInt ("homeSceneUI", 1);
		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetInt ("FIGHTTAGBOOL", 100);
//		PlayerPrefs.SetInt ("FIGHTTAGBOOL", 100);
		PlayerPrefs.SetInt("isGui",0);
		PlayerPrefs.SetInt ("UI_DESABLE",0);
		Destroy (this.gameObject);
		
	}

	public	void sound()
	{
		isSoundOn = !isSoundOn;
		Image img = this.gameObject.transform.GetChild (0).GetComponent<Image> ();
		if (isSoundOn) {
			PlayerPrefs.SetInt ("isSoundOn",0);
			AudioListener.volume = 1;
			img.sprite = soundOn;

		} else {
			PlayerPrefs.SetInt ("isSoundOn",1);
			AudioListener.volume = 0;
			img.sprite = soundOff;
		}
	}
}
