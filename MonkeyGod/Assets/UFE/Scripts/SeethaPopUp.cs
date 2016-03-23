using UnityEngine;
using System.Collections;

public class SeethaPopUp : UFEScreen {

	public static bool boughtUpdatedGadha = false;
	public static bool buynewUpdatedWeaponOnce = false;
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
//			buynewUpdatedWeaponOnce = true;
//			UFE.buyCheck = true;
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [8];
//			UFE.SetPlayer (1, character1);
//			boughtUpdatedGadha = true;
//			IntroScreen.characterValue = 201;
//			WeaponPopUp.buynewWeaponOnce = false;
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.successUI(0f);
//		} else {
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.waitUI(0f);
//		}
//	}
//	public void diamonds(){
//		int diamondCount = PlayerPrefs.GetInt("DIAMOND");
//		if (diamondCount >= 2) {
//			diamondCount = diamondCount - 2;
//			PlayerPrefs.SetInt("DIAMOND",diamondCount);
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [8];
//			UFE.SetPlayer (1, character1);
//			boughtUpdatedGadha = true;
//			buynewUpdatedWeaponOnce = true;
//			UFE.buyCheck = true;	
//			IntroScreen.characterValue = 201;
//			WeaponPopUp.buynewWeaponOnce = false;
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.successUI(0f);
//		} else {
//			UFE.HideScreen(UFE.currentScreen);
//			UFE.alertUI(0f);
//		}
//	}
//	public void no(){
//		int newLife = (int)(PlayerPrefs.GetFloat ("HEALTH"));
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
