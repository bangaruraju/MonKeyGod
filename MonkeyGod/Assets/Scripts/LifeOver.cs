using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using System.Collections.Generic;


public class LifeOver : MonoBehaviour {
	private string GameOver = "GAMEOVERXI";
	private string COINS="COINSI";
	public GameObject WaitScene,purchase_diamond,TryAgain_pre;
	private GameObject TryAgain;
	public static GameObject lifeover_GameObj;
	private int CheckIN_Index=0;

	// Use this for initialization
	void Start () {
		CheckIN_Index = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static bool InternetStatus ()
	{
		if (Application.internetReachability != NetworkReachability.NotReachable)
		{
			return true;
		}else{
			return false;
		}
	}

	private IEnumerator videoTimer2()
	{
		yield return new WaitForSeconds(1f);
	}



	private IEnumerator videoTimer()
	{
	 yield return new WaitForSeconds(13f);

	}
	public	void videoFn() {


//		if (InternetStatus ()) {
//			int videoCount =PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
//			videoCount++;
//			PlayerPrefs.SetInt("VIDEOWATCHCOUNT",videoCount);
//			Destroy (this.gameObject);
//			PlayerPrefs.SetFloat ("HEALTH", 500);
//			PlayerPrefs.SetFloat ("RE", 500);
//			PlayerPrefs.SetInt (GameOver, 2);
//			WaitAgain wg = new WaitAgain ();
//			wg.OnResumeGame ();
//		}
		if (InternetStatus ()) {

			AudioListener.volume = 0;
//			StartCoroutine(videoTimer());
//			StartCoroutine(videoTimer2());
//			

			int videoCount;

//			int videoCount =PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
//			videoCount++;
//			PlayerPrefs.SetInt("VIDEOWATCHCOUNT",videoCount);
//			
//			PlayerPrefs.SetFloat ("HEALTH", 500);
//			PlayerPrefs.SetFloat ("RE", 500);
//			PlayerPrefs.SetInt (GameOver, 2);
////			WaitAgain wg = new WaitAgain ();
////			wg.OnResumeGame ();
//			Destroy (this.gameObject);

			Vungle.playAd (true, "QuantumLeap"); 
			try{
			Vungle.onAdFinishedEvent += (adFinishedEventArgs) => {
					try{
				if (adFinishedEventArgs.IsCompletedView) {
					//					Destroy (this.gameObject);
					AudioListener.volume = 1;
					//					WaitAgain wg = new WaitAgain ();
					//					wg.OnResumeGame ();
					
					videoCount =PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
					videoCount++;
					PlayerPrefs.SetInt("VIDEOWATCHCOUNT",videoCount);
					
					PlayerPrefs.SetFloat ("HEALTH", 500);
					PlayerPrefs.SetFloat ("RE", 500);
					PlayerPrefs.SetInt (GameOver, 2);
					WaitAgain wg2 = new WaitAgain ();
					wg2.OnResumeGame ();
//					if(this.gameObject !=null)
//					Destroy (this.gameObject);
					PlayerPrefs.SetInt ("Video", 1);
					
				} else {
					
				}
					}catch{

					}
			};
			}catch{

			}

		} else {
			Destroy (this.gameObject);
			PlayerPrefs.SetString ("WaitScene", "LifeOver");
			if (TryAgain == null)
				TryAgain = (GameObject)Instantiate (TryAgain_pre, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		}
	}
	public	void diamondFn() {
		PlayerPrefs.SetString ("WaitScene", "LifeOver");
		GameObject DiamondEnergy = (GameObject)Instantiate (purchase_diamond, new Vector3 (Screen.width / 2f, Screen.height / 2f, 0), Quaternion.identity);
		Text btn_txt = DiamondEnergy.transform.GetChild(0).GetChild(1).GetComponentInChildren<Text>();
		Text desc_txt = DiamondEnergy.transform.GetChild(0).GetChild(2).GetComponent<Text>();
		if (PlayerPrefs.GetInt ("DIAMOND") < 2) {
			desc_txt.text = "YOU DON'T HAVE ENOUGH \n DIAMONDS";
			btn_txt.text = "STORE";
			PlayerPrefs.SetString ("OKORSTORE", "STORE");
			PlayerPrefs.SetString ("ISFROM-DIALESS-DIALOG", "TRUE");
		} else {
			Destroy (this.gameObject);
			PlayerPrefs.SetFloat("HEALTH",500);PlayerPrefs.SetFloat ("RE",500);
			PlayerPrefs.SetInt("DIAMOND",PlayerPrefs.GetInt("DIAMOND") - 2);
			PlayerPrefs.SetInt (GameOver, 2);
			PlayerPrefs.SetString("OKORSTORE","OK");
			PlayerPrefs.SetString("ISFROM-DIALESS-DIALOG","TRUE");
			DiamondEnergy.transform.GetChild (0).GetChild (0).gameObject.SetActive(false);
			desc_txt.text = "YOUR TRANSACTION IS \n SUCCESSFUL";
			btn_txt.text = "OK";
			Button but = DiamondEnergy.transform.GetChild(0).GetChild(3).GetComponentInChildren<Button>();
			if(but!=null)
			but.gameObject.SetActive(false);
		}
	}
	private GameObject popup;
	public	void ok () {
		Text val = this.gameObject.transform.GetChild (1).GetComponentInChildren<Text> ();
		if (CheckIN_Index == 0) {
			val.text = "Are you sure want to wait or you want to buy diamonds or watch a video";
			CheckIN_Index++;
		} else if (CheckIN_Index == 1) {
			Destroy(this.gameObject);
			PlayerPrefs.SetString ("WaitScene", "LifeOver");
			CheckIN_Index=0;
			if(GameObject.Find("popup")== null)
				popup= (GameObject)Instantiate (WaitScene, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		} else {
		}
	}

	public	void home () {
		Destroy (this.gameObject);
		PlayerPrefs.SetInt ("homeSceneUI", 2);
		PlayerPrefs.SetInt("UI_DESABLE",0);
		PlayerPrefs.SetInt("isGui",0);
		Time.timeScale =1;
	}
}
