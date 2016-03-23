using UnityEngine;
using System.Collections;

public class SeethaWarning : UFEScreen {
	public static bool boughtgadha = false;
	public static bool buynewWeaponOnce = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//	public void video(){
//		int coinsCount = PlayerPrefs.GetInt ("COINSI");
//		if (coinsCount >= 50) {
//			coinsCount = coinsCount - 50;
//			PlayerPrefs.SetInt("COINSI",coinsCount);
//			buynewWeaponOnce = true;
//			UFE.buyCheck = true;
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [7];
//			UFE.SetPlayer (1, character1);
//			boughtgadha = true;
//			IntroScreen.characterValue = 202;
//			SeethaPopUp.buynewUpdatedWeaponOnce = false;
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.successUI(0f);
//		} else {
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.waitUI(0f);
//		}
//	}
//	public void diamond(){
//		int diamondCount = PlayerPrefs.GetInt("DIAMOND");
//		if (diamondCount >= 2) {
//			diamondCount = diamondCount - 2;
//			PlayerPrefs.SetInt("DIAMOND",diamondCount);
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [7];
//			UFE.SetPlayer (1, character1);
//			boughtgadha = true;
//			buynewWeaponOnce = true;
//			UFE.buyCheck = true;	
//			IntroScreen.characterValue = 202;
//			SeethaPopUp.buynewUpdatedWeaponOnce = false;
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.successUI(0f);
//		} else {
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.alertUI(0f);
//		}
//	}
//	public void no(){
//		int newLife = (int)(PlayerPrefs.GetFloat ("HEALTH"));
//		
//		if (WeaponPopUp.buynewWeaponOnce == true) {
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [6];
//			UFE.SetPlayer (1, character1);
//			if (newLife <= 600 / 2) {
//				UFE.HideScreen (UFE.currentScreen);
//				UFE.updateEnergy (0f);
//			} else {
//				IntroScreen.characterValue = 100;
//				UFE.HideScreen(UFE.currentScreen);
//				UFE.StartGame (0);
//			}
//		} 
//		else if(SeethaPopUp.buynewUpdatedWeaponOnce == true)
//		{
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [8];
//			UFE.SetPlayer (1, character1);
//			if (newLife <= 700 / 2) {
//				UFE.HideScreen (UFE.currentScreen);
//				UFE.updateEnergy (0f);
//			} else {
//				IntroScreen.characterValue = 100;
//				UFE.HideScreen(UFE.currentScreen);
//				UFE.StartGame (0);
//			}
//		}
//		else {
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [0];
//			UFE.SetPlayer (1, character1);
//			if (newLife <= 500 / 2) {
//				UFE.HideScreen(UFE.currentScreen);
//				UFE.updateEnergy (0f);
//			}
//			else{
//				IntroScreen.characterValue = 100;
//				UFE.HideScreen(UFE.currentScreen);
//				UFE.StartGame (0);
//			}
//		}
//	}
}
