using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimerUI : UFEScreen {
	System.DateTime timerStartTime;
	public Text timerLabel;
	public static int waitTime = 1;
	int time;
	public Text text1Label;
	public Text text2Label;
	string waitScene;
	public Texture2D energyBGTexture;
	public Texture2D energyFGTexture;

	private int characterUpgradeValue;
	private int Fight;

	private int level;


	// Use this for initialization
	void Start () {
		waitScene = PlayerPrefs.GetString ("WaitScene");
		 if (waitScene.Equals ("UFE_WAIT")) {
			text1Label.text = "Your upgrade is getting Ready";
			text2Label.text = "";
		}
		PlayerPrefs.SetInt ("isWaiting", 0);
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
		GUI.BeginGroup (new Rect (Screen.width / 2f - Screen.width / 1.2f/2, Screen.height / 1.15f, Screen.width / 1.2f, Screen.height / 11));
		GUI.DrawTexture (new Rect (0, 0, Screen.width / 1.2f, Screen.height / 11), energyBGTexture, ScaleMode.StretchToFill, true, 0f);
		GUI.DrawTexture (new Rect (0, 0, Screen.width / 1.2f * (1 -((float)time / waitTime)), Screen.height / 11), energyFGTexture, ScaleMode.StretchToFill, true, 0f);
		GUI.EndGroup ();
	}
	// Update is called once per frame
	void Update () {
		
		DateTime currentTime = System.DateTime.Now;

		int timeDiff = (int)currentTime.Subtract (timerStartTime).TotalSeconds;
		time = waitTime - timeDiff;

		float f = time / waitTime;
		int minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		int seconds = time % 60; //Use the euclidean division for the seconds.
		
		//update the label value
		timerLabel.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
		
		if (time < 0) {
			PlayerPrefs.SetInt ("isWaiting", 0);
			string str = PlayerPrefs.GetString ("WaitScene");
			if (str.Equals ("UFE_WAIT")) {
				Fight = PlayerPrefs.GetInt ("FIGHTTAG");
				string level_fgt = PlayerPrefs.GetString ("LEVEL");
				if (level_fgt.Equals ("LEVELI"))
					level = 1;
				else if (level_fgt.Equals ("LEVELII"))
					level = 2;
				else if (level_fgt.Equals ("LEVELIII"))
					level = 3;

				switch (Fight) {
				case 0:
					if (level == 3) {
						characterUpgradeValue = 23;
						WeaponPopUp.level3buygadha = true;
					}
					else if (level == 2) {
						characterUpgradeValue = 14;
						WeaponPopUp.level2buygadha = true;
					} else {
						characterUpgradeValue = 0;
						WeaponPopUp.buygadha1 = true;
					}
					this.characterUpgrade ();
					break;
				case 1:
					if (level == 3) {
					characterUpgradeValue = 24;
						WeaponPopUp.level3buygadha2 = true;
					}
					else if (level == 2) {
						characterUpgradeValue = 15;
						WeaponPopUp.level2buyarmour = true;
					} else {
						characterUpgradeValue = 6;
						WeaponPopUp.buygadha2 = true;
					}
					this.characterUpgrade ();
					break;
				case 2:
					if (level == 3) {
						characterUpgradeValue = 22;
						WeaponPopUp.level3buyarmour = true;
					}
					else if (level == 2) {
						characterUpgradeValue = 16;
						WeaponPopUp.level2buygadha2 = true;
					} else {
						characterUpgradeValue = 7;
						WeaponPopUp.buyArmour1 = true;
					}
					this.characterUpgrade ();
					break;
				case 3:
					if (level == 3) {
					}
					else if (level == 2) {
						characterUpgradeValue = 17;
						WeaponPopUp.level2buyarmour2 = true;
					} else {
						characterUpgradeValue = 8;
						WeaponPopUp.buygadha3 = true;
					}
					this.characterUpgrade ();
					break;
				case 4:
					if (level == 3) {
					}
					else if (level == 2) {
				characterUpgradeValue = 25;
				WeaponPopUp.level2buyarmour3 = true;
					} else {
						characterUpgradeValue = 9;
						WeaponPopUp.buyArmour2 = true;
					}
					this.characterUpgrade ();
					break;
				}
			} else if (str.Equals ("UFE_UPDATEENERGY _WAIT")) {
				IntroScreen.characterValue = 100;
				UFE.HideScreen (UFE.currentScreen);
				UFE.StartGame (0);
			}
		}
	}
	void characterUpgrade()
	{
		CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
		CharacterInfo character1 = selectableCharacters [characterUpgradeValue];
		UFE.SetPlayer (1, character1);
		UFE.HideScreen(UFE.currentScreen);
		UFE.successUI(0f);
	}
}
