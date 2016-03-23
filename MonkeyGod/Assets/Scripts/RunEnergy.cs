using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunEnergy : MonoBehaviour {

	public float max_health =500f;
	private string GameOver = "GAMEOVERXI";
	private string COINS="COINSI";
	public GameObject WaitScene,purchase_diamond,TryAgain_pre,againWaitPopUp;
	private GameObject TryAgain;
	public static GameObject runenergy_GameObj;
	private GameObject btn;
	public void ClickFn(){
		Time.timeScale = 1;
		PlayerPrefs.SetInt("isGui",0);
		PlayerPrefs.SetFloat ("RE", max_health);
		PlayerPrefs.SetInt ("walkStickStatus", 0);
		PlayerPrefs.SetInt ("UI_DESABLE", 0);
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

	//	runenergy_GameObj=this.gameObject;
//		if (InternetStatus ()) {
//			int videoCount =PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
//			videoCount++;
//			PlayerPrefs.SetInt("VIDEOWATCHCOUNT",videoCount);
//			Destroy (this.gameObject);
//			PlayerPrefs.SetFloat ("RE", max_health);
//		//	ClickFn ();
//			WaitAgain wg = new WaitAgain ();
//			wg.OnResumeGame ();
//
//		}

			if (InternetStatus ()) {
			AudioListener.volume = 0;
//			StartCoroutine(videoTimer());
//			StartCoroutine(videoTimer2());

			int videoCount;
//			int videoCount =PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
//			videoCount++;
//			PlayerPrefs.SetInt("VIDEOWATCHCOUNT",videoCount);
//			
//			PlayerPrefs.SetFloat ("RE", max_health);
//			//	ClickFn ();
////			WaitAgain wg = new WaitAgain ();
////			wg.OnResumeGame ();
//			Destroy (this.gameObject);
//
			Vungle.playAd (true, "QuantumLeap"); 
			try{
			Vungle.onAdFinishedEvent += (adFinishedEventArgs) => {
					try{
				if (adFinishedEventArgs.IsCompletedView) {
					AudioListener.volume = 1;
					//				WaitAgain wg = new WaitAgain ();
					//				wg.OnResumeGame ();
					videoCount =PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
					videoCount++;
					PlayerPrefs.SetInt("VIDEOWATCHCOUNT",videoCount);
					
					PlayerPrefs.SetFloat ("RE", max_health);
					//	ClickFn ();
					WaitAgain wg2 = new WaitAgain ();
					wg2.OnResumeGame ();
//					if(this.gameObject!=null)
					Destroy (this.gameObject);
					
				} else {
					
				}
					}catch{

					}
			};
			}catch{

			}

		} else {
			Destroy(this.gameObject);
			PlayerPrefs.SetString ("WaitScene", "RunEnergy");
			if (TryAgain == null)
				TryAgain = (GameObject)Instantiate (TryAgain_pre, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		}
	}
	public	void diamondFn() {

		PlayerPrefs.SetString ("WaitScene", "RunEnergy");
		GameObject DiamondEnergy = (GameObject)Instantiate (purchase_diamond, new Vector3 (Screen.width / 2f, Screen.height / 2f, 0), Quaternion.identity);
		Text btn_txt = DiamondEnergy.transform.GetChild(0).GetChild(1).GetComponentInChildren<Text>();
		Text desc_txt = DiamondEnergy.transform.GetChild(0).GetChild(2).GetComponent<Text>();
		if (PlayerPrefs.GetInt ("DIAMOND") < 2) {
			desc_txt.text = "YOU DON'T HAVE ENOUGH \n DIAMONDS";
			btn_txt.text = "STORE";
			PlayerPrefs.SetString ("OKORSTORE", "STORE");
			PlayerPrefs.SetString ("ISFROM-DIALESS-DIALOG", "TRUE");
		} else {
//			PlayerPrefs.SetInt("UI_DESABLE",0);
//			Time.timeScale =1;
//			PlayerPrefs.SetInt("isGui",0);
			Destroy (this.gameObject);
			PlayerPrefs.SetFloat ("RE",500);
			PlayerPrefs.SetInt("DIAMOND",PlayerPrefs.GetInt("DIAMOND") - 2);
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
	GameObject timer ;
	public	void WaitFn () {
//		Destroy (this.gameObject);
//		PlayerPrefs.SetString ("WaitScene", "RunEnergy");
//		if(timer == null)
//		timer= (GameObject)Instantiate (WaitScene, new Vector3 (0f, 0f, 0f), Quaternion.identity);
	}
	private GameObject popup;
	public	void ok () {
//		Time.timeScale = 0;
//		PlayerPrefs.SetInt("UI_DESABLE",1);
//		PlayerPrefs.SetInt("isGui",1);

		Text val = this.gameObject.transform.GetChild (1).GetComponentInChildren<Text> ();
		if (CheckIN_Index == 0) {
			val.text = "Are you sure want to wait or you want to buy diamonds or watch a video";
			CheckIN_Index++;
		} else if (CheckIN_Index == 1) {
			Destroy(this.gameObject);
			PlayerPrefs.SetString ("WaitScene", "RunEnergy");
			CheckIN_Index=0;
			if(GameObject.Find("popup")== null)
				popup= (GameObject)Instantiate (WaitScene, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		} else {

		}
//		Destroy (this.gameObject);
//		PlayerPrefs.SetString ("WaitScene", "RunEnergy");
//		if(timer == null)
//			timer= (GameObject)Instantiate (WaitScene, new Vector3 (0f, 0f, 0f), Quaternion.identity);

	}
	private int CheckIN_Index=0;
	void Start ()
	{
		CheckIN_Index=0;
//		Debug.Log ("START!!!");
	}
}
