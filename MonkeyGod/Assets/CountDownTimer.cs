using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CountDownTimer : MonoBehaviour {

	System.DateTime timerStartTime;
	public Text timerLabel;
	public static int waitTime = 10;
	int time;
	public Text text1Label;
	public Text text2Label;
	string waitScene;

	public Texture2D energyBGTexture;
	public Texture2D energyFGTexture;

	void Start() {
//		PlayerPrefs.SetInt ("UI_DESABLE", 1);
//		PlayerPrefs.SetInt ("isGui", 1);
		waitScene = PlayerPrefs.GetString ("WaitScene");
		if (waitScene.Equals ("LifeOver")) {
			text1Label.text = "No more lives";
			text2Label.text = "Time to next life";
		} else if (waitScene.Equals ("RunEnergy")) {
			text1Label.text = "No more energy";
			text2Label.text = "";
		}

	//	Time.timeScale = 1;
//		if (!PlayerPrefs.GetString ("sysString").Equals("")) {
//
//		}
		if (PlayerPrefs.GetInt ("isWaiting") == 0 || PlayerPrefs.GetString ("sysString").Equals("")) {
			PlayerPrefs.SetInt ("isWaiting", 1);
			PlayerPrefs.SetString ("sysString", DateTime.Now.ToBinary ().ToString ());
			timerStartTime = System.DateTime.Now;
		} else {
			long temp=0;
			try{
			//Grab the old time from the player prefs as a long
				Debug.Log(""+PlayerPrefs.GetString ("sysString"));
			temp = System.Convert.ToInt64 (PlayerPrefs.GetString ("sysString"));
			}catch{
			}
			
			//Convert the old time from binary to a DataTime variable
			timerStartTime = System.DateTime.FromBinary (temp);
		}
	}

	void OnGUI (){
		GUI.BeginGroup (new Rect (Screen.width / 2f - Screen.width / 2.4f, Screen.height / 1.15f, Screen.width / 1.2f, Screen.height / 11));
		GUI.DrawTexture (new Rect (0, 0, Screen.width / 1.2f, Screen.height / 11), energyBGTexture, ScaleMode.StretchToFill, true, 0f);
		GUI.DrawTexture (new Rect (0, 0, Screen.width / 1.2f * (1 -((float)time / waitTime)), Screen.height / 11), energyFGTexture, ScaleMode.StretchToFill, true, 0f);
		GUI.EndGroup ();
	}

		

	void Update() {
		DateTime currentTime = System.DateTime.Now;

		int timeDiff = (int)currentTime.Subtract(timerStartTime).TotalSeconds;
		time = waitTime - timeDiff;
		int minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		int seconds = time % 60; //Use the euclidean division for the seconds.
				
		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00}", minutes, seconds);

		if (time < 0) {
			PlayerPrefs.SetInt ("isWaiting", 0);
//			Time.timeScale = 1;
//			PlayerPrefs.SetInt ("UI_DESABLE", 0);
//			PlayerPrefs.SetInt ("isGui", 0);
			
			waitScene = PlayerPrefs.GetString ("WaitScene");
			if (waitScene.Equals ("LifeOver")) {
				PlayerPrefs.SetFloat ("HEALTH", 500);
				PlayerPrefs.SetInt ("GAMEOVERXI", 2);
				WaitAgain wg = new WaitAgain ();
				wg.OnResumeGame ();
			} else if (waitScene.Equals ("RunEnergy")) {
				WaitAgain wg = new WaitAgain ();
				wg.OnResumeGame ();
				PlayerPrefs.SetFloat ("RE", 500);
			//	PlayerPrefs.SetInt ("walkStickStatus", 0);
			}
			Destroy (this.gameObject);
		}
	}

//	void OnApplicationQuit()
//	{
//		if (PlayerPrefs.GetInt ("isWaiting") == 1) {
//			//Savee the current system time as a string in the player prefs class
//			PlayerPrefs.SetString ("sysString", System.DateTime.Now.ToBinary ().ToString ());
//		}
//	}

//	int time = 60;
//	public Text timerLabel;
////	System.DateTime timerStartTime;
//
//	void Start() {
//		Time.timeScale = 1;
////		timerStartTime = System.DateTime.Now;
////		StartCoroutine (count());
//		Debug.Log ("Hello : ");
//		InvokeRepeating ("printT", 0f, 10f);
//	}
//
//	void printT(){
//		//      f = f - 0.1f;
//		//      print ("Hello : " +f);
//		time = time - 1;
//		int minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
//		int seconds = time % 60;//Use the euclidean division for the seconds.
//		//update the label value
//		Debug.Log  (string.Format ("{0:00} : {1:00}", minutes, seconds));
////		if(time <=0)
////			CancelInvoke ("printT");
//	}
//
//	IEnumerator count(){
//		Debug.Log ("Start");
//		yield return new WaitForSeconds(1f);
//		Debug.Log ("Start");
////		Debug.Log ("count");
////		System.DateTime currentTime = System.DateTime.Now;
////		Debug.Log ("currentTime.Second - timerStartTime.Second " + currentTime.Second + " " + timerStartTime.Second + " " + (currentTime.Second - timerStartTime.Second));
////		int time = totaltime - (currentTime.Second - timerStartTime.Second);
//		time = time - 1;
//		int minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
//		int seconds = time % 60;//Use the euclidean division for the seconds.
//		
//		//update the label value
//		timerLabel.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
//		if (time > 0)
//			StartCoroutine (count ());
//		else {
//			Time.timeScale = 1;
//			PlayerPrefs.SetInt ("UI_DESABLE", 0);
//			PlayerPrefs.SetInt ("isGui", 0);
//
//			string waitScene = PlayerPrefs.GetString ("WaitScene");
//			if(waitScene.Equals("LifeOver")){
//			PlayerPrefs.SetFloat ("HEALTH", 500);
//			PlayerPrefs.SetInt ("GAMEOVERXI", 2);
//			}
//			else if(waitScene.Equals("RunEnergy")){
//			PlayerPrefs.SetFloat ("RE", 500);
//			PlayerPrefs.SetInt ("walkStickStatus", 0);
//			}
//			Destroy(this.gameObject);
////			Application.LoadLevel("DynamicPath");
//		}
//	}
	
}
