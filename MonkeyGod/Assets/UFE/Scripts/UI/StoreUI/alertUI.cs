using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class alertUI : UFEScreen {
	private int characterUpgradeValue;
	[HideInInspector]public GameObject btn;
	private	int level;
	private int CheckIN_Index=0;

	// Use this for initialization
	void Start () {
		CheckIN_Index = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void buyDiamonds()
	{
		UFE.HideScreen(UFE.currentScreen);
		UFE.storeUI(0f);
	}
	private int Fight;
	private int coinValue;

	public void coinsANDvideo()
	{
		
		Fight=PlayerPrefs.GetInt ("FIGHTTAG");
		int coinsCount = PlayerPrefs.GetInt ("COINSI");
		btn = GameObject.FindGameObjectWithTag("CoinsTag");
		btn.GetComponent<Button>().interactable = false;
		string Value = btn.transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ().text;
		coinValue =int.Parse(Value);
		string level_fgt = PlayerPrefs.GetString("LEVEL");
		if (level_fgt.Equals ("LEVELI"))
			level = 1;
		else if (level_fgt.Equals ("LEVELII"))
			level = 2;
		switch(Fight)
		{
		case 0 : 
			if (coinsCount >= coinValue) {
				PlayVideo();
			} else {
				UFE.HideScreen(UFE.currentScreen);
				UFE.waitUI(0f);
			}
			break;
		case 1 : 
			if (coinsCount >= coinValue) {
				PlayVideo();
			} else {
				UFE.HideScreen(UFE.currentScreen);
				UFE.waitUI(0f);
			}
			break;
		case 2 : 
			if (coinsCount >= coinValue) {
				PlayVideo();
			} else {
				UFE.HideScreen(UFE.currentScreen);
				UFE.waitUI(0f);
			}
			break;
		case 3 : 
			if (coinsCount >= coinValue) {
				PlayVideo();
			} else {
				UFE.HideScreen(UFE.currentScreen);
				UFE.waitUI(0f);
			}
			break;
		case 4 : 
			if (coinsCount >= coinValue) {
				PlayVideo();
			} else {
				UFE.HideScreen(UFE.currentScreen);
				UFE.waitUI(0f);
			}
			break;
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
	public void wait()
	{
		Text val = GameObject.FindGameObjectWithTag("level2BuyGadha").transform.GetChild(1).GetComponent<UnityEngine.UI.Text>();
		if (CheckIN_Index == 0) {
			val.text = "Are you sure want to wait or you want to buy diamonds or watch a video for Upgrading Weapon";
			CheckIN_Index++;
		} else if (CheckIN_Index == 1) {
			PlayerPrefs.SetString ("WaitScene","UFE_WAIT");
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
	/*
	private  IEnumerator videoTimer()
	{
		yield return new WaitForSeconds (15f); 
		AudioListener.volume = 1;
		Fight = PlayerPrefs.GetInt ("FIGHTTAG");
		int coinsCount = PlayerPrefs.GetInt ("COINSI");
		btn = GameObject.FindGameObjectWithTag ("CoinsTag");
		btn.GetComponent<Button> ().interactable = false;
		string level_fgt = PlayerPrefs.GetString("LEVEL");
		if (level_fgt.Equals ("LEVELI"))
			level = 1;
		else if (level_fgt.Equals ("LEVELII"))
			level = 2;
		else if (level_fgt.Equals ("LEVELIII"))
			level = 3;
		switch (Fight) {
		case 0: 
			coinsCount = coinsCount - coinValue;
			PlayerPrefs.SetInt ("COINSI", coinsCount);
			if(level == 3)
			{
				characterUpgradeValue = 23;
				WeaponPopUp.level3buygadha = true;
			}
			else if(level == 2)
			{
				characterUpgradeValue = 14;
				WeaponPopUp.level2buygadha = true;
			}
			else
			{
				characterUpgradeValue = 0;
				WeaponPopUp.buygadha1 = true;
			}
			this.characterUpgrade ();
			break;
		case 1: 
			coinsCount = coinsCount - coinValue;
			PlayerPrefs.SetInt ("COINSI", coinsCount);
			if(level == 3)
			{
				characterUpgradeValue = 24;
				WeaponPopUp.level3buygadha2 = true;
			}
			else if(level == 2)
			{
				characterUpgradeValue = 15;
				WeaponPopUp.level2buyarmour = true;
			}
			else
			{
				characterUpgradeValue = 6;
				WeaponPopUp.buygadha2 = true;
			}
			this.characterUpgrade ();
			break;
		case 2: 
			coinsCount = coinsCount - coinValue;
			PlayerPrefs.SetInt ("COINSI", coinsCount);
			if(level == 3)
			{
				characterUpgradeValue = 22;
				WeaponPopUp.level3buyarmour = true;
			}
			else if(level == 2)
			{
				characterUpgradeValue = 16;
				WeaponPopUp.level2buygadha2 = true;
			}
			else
			{
				characterUpgradeValue = 7;
				WeaponPopUp.buyArmour1 = true;
			}
			this.characterUpgrade ();
			break;
		case 3: 
			coinsCount = coinsCount - coinValue;
			PlayerPrefs.SetInt ("COINSI", coinsCount);
			if(level == 3)
			{
			}
			else if(level == 2)
			{
				characterUpgradeValue = 17;
				WeaponPopUp.level2buyarmour2 = true;
			}
			else
			{
				characterUpgradeValue = 8;
				WeaponPopUp.buygadha3 = true;
			}
			this.characterUpgrade ();
			break;
		case 4: 
			coinsCount = coinsCount - coinValue;
			PlayerPrefs.SetInt ("COINSI", coinsCount);
			if(level == 3)
			{
			}
			else if(level == 2)
			{
//							characterUpgradeValue = 14;
//							level2buygadha = true;
			}
			else
			{
				characterUpgradeValue = 9;
				WeaponPopUp	.buyArmour2 = true;
			}
			this.characterUpgrade ();
			break;
		}
		
	}
	*/
	void PlayVideo(){
		AudioListener.volume = 0;
		if (InternetStatus ()) {
//			StartCoroutine(videoTimer());
			Vungle.playAd (true, "QuantumLeap"); 
			Vungle.onAdFinishedEvent += (adFinishedEventArgs) => {
				if (adFinishedEventArgs.IsCompletedView) {
					AudioListener.volume = 1;
					Fight = PlayerPrefs.GetInt ("FIGHTTAG");
					int coinsCount = PlayerPrefs.GetInt ("COINSI");
					btn = GameObject.FindGameObjectWithTag ("CoinsTag");
					btn.GetComponent<Button> ().interactable = false;
					string level_fgt = PlayerPrefs.GetString("LEVEL");
					if (level_fgt.Equals ("LEVELI"))
						level = 1;
					else if (level_fgt.Equals ("LEVELII"))
						level = 2;
					else if (level_fgt.Equals ("LEVELIII"))
						level = 3;
					switch (Fight) {
					case 0: 
						coinsCount = coinsCount - coinValue;
						PlayerPrefs.SetInt ("COINSI", coinsCount);
						if(level == 3)
						{
							characterUpgradeValue = 23;
							WeaponPopUp.level3buygadha = true;
						}
						else if(level == 2)
						{
							characterUpgradeValue = 14;
							WeaponPopUp.level2buygadha = true;
						}
						else
						{
							characterUpgradeValue = 0;
							WeaponPopUp.buygadha1 = true;
						}
						this.characterUpgrade ();
						break;
					case 1: 
						coinsCount = coinsCount - coinValue;
						PlayerPrefs.SetInt ("COINSI", coinsCount);
						if(level == 3)
						{
							characterUpgradeValue = 24;
							WeaponPopUp.level3buygadha2 =true;
						}
						else if(level == 2)
						{
							characterUpgradeValue = 15;
							WeaponPopUp.level2buyarmour = true;
						}
						else
						{
							characterUpgradeValue = 6;
							WeaponPopUp.buygadha2 = true;
						}
						this.characterUpgrade ();
						break;
					case 2: 
						coinsCount = coinsCount - coinValue;
						PlayerPrefs.SetInt ("COINSI", coinsCount);
						if(level == 3)
						{
							characterUpgradeValue = 22;
							WeaponPopUp.level3buyarmour = true;
						}
						else if(level == 2)
						{
							characterUpgradeValue = 16;
							WeaponPopUp.level2buygadha2 = true;
						}
						else
						{
							characterUpgradeValue = 7;
							WeaponPopUp.buyArmour1 = true;
						}
						this.characterUpgrade ();
						break;
					case 3: 
						coinsCount = coinsCount - coinValue;
						PlayerPrefs.SetInt ("COINSI", coinsCount);
						if(level == 3)
						{
						}	
						else if(level == 2)
						{
							characterUpgradeValue = 17;
							WeaponPopUp.level2buyarmour2 = true;
						}
						else
						{
							characterUpgradeValue = 8;
							WeaponPopUp.buygadha3 = true;
						}
						this.characterUpgrade ();
						break;
					case 4: 
						coinsCount = coinsCount - coinValue;
						PlayerPrefs.SetInt ("COINSI", coinsCount);
						if(level == 3)
						{
						}
						else if(level == 2)
						{
							characterUpgradeValue = 25;
							WeaponPopUp.level2buyarmour3 = true;
						}
						else
						{
							characterUpgradeValue = 9;
							WeaponPopUp.buyArmour2 = true;
						}
						this.characterUpgrade ();
						break;
					}
				}
				else {
					UFE.tryAgainPopUp(0f);
				}
				
			};
		}
		else {
			UFE.tryAgainPopUp(0f);
		}
		
	}
}
