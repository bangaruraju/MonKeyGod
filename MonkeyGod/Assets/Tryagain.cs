using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Tryagain : MonoBehaviour {

	public GameObject WaitScene;
	string waitScene;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public	void Wait_fn () {
		if(LifeOver.lifeover_GameObj!=null)
		Destroy (LifeOver.lifeover_GameObj);
		if(RunEnergy.runenergy_GameObj !=null)
			Destroy (RunEnergy.runenergy_GameObj);

		Destroy (this.gameObject);
		GameObject timer = (GameObject)Instantiate (WaitScene, new Vector3 (0f, 0f, 0f), Quaternion.identity);
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
	public	void Tryagain_fn () {
		AudioListener.volume = 0;
		
		if (InternetStatus ()) {
			int videoCount =PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
			videoCount++;
			PlayerPrefs.SetInt("VIDEOWATCHCOUNT",videoCount);
			Destroy (this.gameObject);
			waitScene = PlayerPrefs.GetString ("WaitScene");
			if (waitScene.Equals ("LifeOver")) {
				PlayerPrefs.SetFloat ("HEALTH", 500);
				PlayerPrefs.SetInt ("GAMEOVERXI", 2);
			} else if (waitScene.Equals ("RunEnergy")) {
				PlayerPrefs.SetFloat ("RE", 500);
			}
			WaitAgain wg = new WaitAgain ();
			wg.OnResumeGame ();
		}
		if (InternetStatus ()) {
			Vungle.playAd (true, "QuantumLeap"); 
			Vungle.onAdFinishedEvent += (adFinishedEventArgs) => {
				if (adFinishedEventArgs.IsCompletedView) {
					AudioListener.volume = 1;
//					WaitAgain wg = new WaitAgain ();
//					wg.OnResumeGame ();
				} else {
					
				}
			};
		} else {
		}
	}
}