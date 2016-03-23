using UnityEngine;
using System.Collections;

public class StoreScreen : UFEScreen {
	private int diamondCount;
	private int characterUpgradeValue;

	private int level;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void coinsMthd()
	{
		UFE.HideScreen(UFE.currentScreen);
		UFE.alertUI (0f);
	}
	public void buyDiamondMthdOne()
	{
		int diamondValue = 10;
		diamondCount = PlayerPrefs.GetInt("DIAMOND");
		diamondCount = diamondCount +diamondValue;
		mainBuyMthd ();
	}
	public void buyDiamondMthdtwo()
	{
		int diamondValue = 60;
		diamondCount = PlayerPrefs.GetInt("DIAMOND");
		diamondCount = diamondCount +diamondValue;
		mainBuyMthd ();

	}
	public void buyDiamondMthdthree()
	{
		int diamondValue = 10;
		diamondCount = PlayerPrefs.GetInt("DIAMOND");
		diamondCount = diamondCount +diamondValue;
		mainBuyMthd ();

	}
	public void buyDiamondMthdfour()
	{
		int diamondValue = 250;
		diamondCount = PlayerPrefs.GetInt("DIAMOND");
		diamondCount = diamondCount +diamondValue;
		mainBuyMthd ();

	}
	public void buyDiamondMthdfive()
	{
		int diamondValue = 650;
		diamondCount = PlayerPrefs.GetInt("DIAMOND");
		diamondCount = diamondCount +diamondValue;
		mainBuyMthd ();

	}

	void mainBuyMthd()
	{
		int Fight=PlayerPrefs.GetInt ("FIGHTTAG");
		string level_fgt = PlayerPrefs.GetString("LEVEL");
		if (level_fgt.Equals ("LEVELI"))
			level = 1;
		else if (level_fgt.Equals ("LEVELII"))
			level = 2;
		else if (level_fgt.Equals ("LEVELIII"))
			level = 3;
		switch(Fight)
		{
			case 0 : 
				if (diamondCount >= 1) {
					diamondCount = diamondCount - 1;
					PlayerPrefs.SetInt ("DIAMOND", diamondCount);
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
					this.characterUpgrade();
				} else {
					UFE.HideScreen (UFE.currentScreen);
					UFE.alertUI (0f);
				}
				break;
			case 1 : 
				if (diamondCount >= 2) {
					diamondCount = diamondCount - 2;
					PlayerPrefs.SetInt ("DIAMOND", diamondCount);
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
					this.characterUpgrade();
				} else {
					UFE.HideScreen (UFE.currentScreen);
					UFE.alertUI (0f);
				}
				break;
			case 2 : 
				if (diamondCount >= 3) {
					diamondCount = diamondCount - 3;
					PlayerPrefs.SetInt ("DIAMOND", diamondCount);
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
					this.characterUpgrade();
				} else {
					UFE.HideScreen (UFE.currentScreen);
					UFE.alertUI (0f);
				}
				break;
			case 3 : 
				if (diamondCount >= 4) {
					diamondCount = diamondCount - 4;
					PlayerPrefs.SetInt ("DIAMOND", diamondCount);
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
					this.characterUpgrade();
				} else {
					UFE.HideScreen (UFE.currentScreen);
					UFE.alertUI (0f);
				}
				break;
			case 4 : 
				if (diamondCount >= 5) {
					diamondCount = diamondCount - 5;
					PlayerPrefs.SetInt ("DIAMOND", diamondCount);
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
					this.characterUpgrade();
				} else {
					UFE.HideScreen (UFE.currentScreen);
					UFE.alertUI (0f);
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
}
