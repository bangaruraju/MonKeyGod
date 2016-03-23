using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class updateScreen : UFEScreen {
	[HideInInspector]public GameObject btn;
	private int CheckIN_Index=0;

	public void Start()
	{
		CheckIN_Index = 0;
	}
	
	public void diamondMethod()
	{
		int diamondCount = PlayerPrefs.GetInt ("DIAMOND");
		btn = GameObject.FindGameObjectWithTag ("DiamondTag");
		btn.GetComponent<Button> ().interactable = false;
		string Value = btn.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text;
		int diamondValue = int.Parse (Value);
		if (diamondCount >= diamondValue) {
			diamondCount = diamondCount - diamondValue;
			PlayerPrefs.SetInt ("DIAMOND", diamondCount);
			UFE.diamondCheck = true;
			IntroScreen.characterValue =100;
			UFE.StartGame (0);
		} else {
			UFE.HideScreen (UFE.currentScreen);
			UFE.alertUI (0f);
		}
	}
	public void videoMethod()
	{
		AudioListener.volume = 0;
		btn = GameObject.FindGameObjectWithTag("CoinsTag");
		btn.GetComponent<Button>().interactable = false;

		if (InternetStatus ()) {
			Vungle.playAd (true, "QuantumLeap"); 
			Vungle.onAdFinishedEvent += (adFinishedEventArgs) => {
				if (adFinishedEventArgs.IsCompletedView) {
					AudioListener.volume = 1;
					UFE.videoCheck = true;
					IntroScreen.characterValue =100;
					UFE.StartGame (0);
				}
				else {
				}
				
			};
		}
		else {
			UFE.tryAgainPopUp(0f);
		}
	}
	public void waitMethod()
	{
		Text val = GameObject.FindGameObjectWithTag("level2BuyGadha").transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
		if (CheckIN_Index == 0) {
			val.text = "Are you sure want to wait or\nyou want to buy diamonds or\nwatch a video for Upgrading Weapon";
			CheckIN_Index++;
		} else if (CheckIN_Index == 1) {
			PlayerPrefs.SetString ("WaitScene","UFE_UPDATEENERGY _WAIT");
			CheckIN_Index=0;
			UFE.HideScreen (UFE.currentScreen);
			UFE.timerUI (0f);
		} else {
		}
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
}