using UnityEngine;
using System.Collections;

public class UpdateArmor : UFEScreen {

	public static bool buyArmourOnce = false;
	public static bool boughtArmour = false;


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
		PlayerPrefs.SetInt ("UARMR",1);
//		UFE.buyCheck = true;
		buyArmourOnce = true;
		CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
		CharacterInfo character1 = selectableCharacters [7];
		UFE.SetPlayer (1, character1);
		boughtArmour = true;
		UFE.StartGame (0);
	}
}
