using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ThereUGoScript : MonoBehaviour {
	
	System.DateTime timerStartTime;
	public Text timerLabel;
	public static int waitTime = 3;
	int time;


	void Start() {
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


	void Update() {
		DateTime currentTime = System.DateTime.Now;
		int timeDiff = (int)currentTime.Subtract(timerStartTime).TotalSeconds;
		time = waitTime - timeDiff;
		timerLabel.text = ""+time;
		
		if (time < 1) {
			PlayerPrefs.SetInt ("isWaiting", 0);
			Destroy (this.gameObject);
			WaitAgain wg = new WaitAgain ();
			wg.OnResumeGame ();
		}
	}

}
