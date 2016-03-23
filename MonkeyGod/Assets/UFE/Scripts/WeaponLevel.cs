using UnityEngine;
using System.Collections;

public class WeaponLevel : UFEScreen {

	public static bool buyOnce = false;
	public static bool buynewWeaponOnce = false;
	public static bool boughtgadha = false;
	public static bool boughtUpdatedGadha = false;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ingnore(){

//		UFE.StartGame (0);
		CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
		CharacterInfo character1 = selectableCharacters [6];
		UFE.SetPlayer (1, character1);
		UFE.StartGame (0);
	}

	public void store(){

//		if (IntroScreen.characterValue == 3) {
////			UFE.buyCheck = true;
//			buyOnce = true;
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [6];
//			UFE.SetPlayer (1, character1);
//			boughtgadha = true;
//			UFE.StartGame (0);
//		} else if (IntroScreen.characterValue == 4) {
////			UFE.buyCheck = true;
//			buynewWeaponOnce = true;
//			CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
//			CharacterInfo character1 = selectableCharacters [8];
//			UFE.SetPlayer (1, character1);
//			boughtUpdatedGadha = true;
//			UFE.StartGame (0);
//		}
	}
}
