using UnityEngine;
using System.Collections;

public class IntroScreen : UFEScreen {

	public static int characterValue = 1;
	public static int hanumanValue = 0;
	public static bool charCheck = false;


	private int newLife;
	private int characterUpgradeValue;
	private int level;

	public virtual void GoToMainMenu(){
		int Fight=PlayerPrefs.GetInt ("FIGHTTAG");
		newLife = (int)(PlayerPrefs.GetFloat ("HEALTH"));
		string level_fgt = PlayerPrefs.GetString("LEVEL");
		if (level_fgt.Equals ("LEVELI"))
			level = 1;
		else if (level_fgt.Equals ("LEVELII"))
			level = 2;
		else if (level_fgt.Equals ("LEVELIII"))
			level = 3;

//		Fight = 0;
//		level = 3;
//		PlayerPrefs.SetInt ("FIGHTTAG", Fight);
//		PlayerPrefs.SetString("LEVEL","LEVELIII");
		//loading fight depending upon fight and levels

		switch (Fight) {
			case 0 :
			if(level == 3)
			{	
				hanumanValue = 25;
				characterValue = 19;
			}
			else if(level == 2)
			{
			characterValue = 10;
			hanumanValue = 9;
			}
			else
			{
			characterValue = 1;
			}
			break;
			case 1 : 
			if(level == 3)
			{
				hanumanValue = 23;
				characterValue = 20;
			}
			else if(level == 2)
			{
			characterValue = 11;
			hanumanValue = 14;
			WeaponPopUp.level2buygadha = false;
			}
			else{
			characterValue = 2;
			hanumanValue = 0;
			}
			break;
			case 2 : 
			if(level == 3)
			{
				hanumanValue = 24;
				characterValue = 21;
				level = 31;
			}
			else if(level == 2)
			{
			characterValue = 12;
			hanumanValue = 15;
			WeaponPopUp.level2buyarmour = false;
			}
			else{
			characterValue = 3;
			hanumanValue = 6;
			}
			break;
			case 3 : 
			if(level == 3)
			{
			}
			else if(level == 2)
			{
			characterValue = 13;
			hanumanValue = 16;
			WeaponPopUp.level2buygadha2 = false;
			}
			else{
			characterValue = 4;
			hanumanValue = 7;
			}
			break;
			case 4 : 
			if(level == 3)
			{
			}
			if(level == 2)
			{
				hanumanValue = 17;
				characterValue = 18;
				level=21;
			}
			else{
			characterValue = 5;
			hanumanValue = 8;
			}
			break;
			default :
			characterValue = 1;
			hanumanValue = 0;
			break;
		}
		UFE.StartVersusModeScreen ();
		UFE.StartPlayerVersusCpu ();
		CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
		CharacterInfo character1 = selectableCharacters [hanumanValue];
		CharacterInfo character2 = selectableCharacters [characterValue];
		UFE.SetPlayer (1, character1);
		UFE.SetPlayer (2, character2);

// loading stage for fights depending upon level
		if (level == 1)
			UFE.config.selectedStage = UFE.config.stages [0];
		else if (level == 2)
			UFE.config.selectedStage = UFE.config.stages [1];
		else if (level == 21)
			UFE.config.selectedStage = UFE.config.stages [2];
		else if (level == 3)
			UFE.config.selectedStage = UFE.config.stages [3];
		else if(level == 31)
			UFE.config.selectedStage = UFE.config.stages [4];


// loading Hanuman character by checking whether user bought weapon or not
		switch(characterValue)
		{
			// level 1 cases
		case 1 : 
			if(WeaponPopUp.buygadha1 == true)
			{
				characterUpgradeValue = 0;
				this.characterUpgrade();
			}
			else
				UFE.Warning (0f);
			break;
		case 2 : 
			if(WeaponPopUp.buygadha2 == true)
			{
				characterUpgradeValue = 6;
				this.characterUpgrade();
			}
			else
				UFE.secondPopUp(0f);
			break;
		case 3 : 
			if(WeaponPopUp.buyArmour1 == true)
			{
				characterUpgradeValue = 7;
				this.characterUpgrade();
			}
			else
				UFE.thirdPopUp(0f);
			break;
		case 4 : 
			if(WeaponPopUp.buygadha3 == true)
			{
				characterUpgradeValue = 8;
				this.characterUpgrade();
			}
			else
				UFE.fourthPopUp(0f);
			break;
		case 5 : 
			if(WeaponPopUp.buyArmour2 == true)
			{
				characterUpgradeValue = 9;
				this.characterUpgrade();
			}
			else
				UFE.fifthPopUp(0f);
			break;
		case 10 :
			if(WeaponPopUp.level2buygadha == true)
			{
				characterUpgradeValue = 14;
				this.characterUpgrade();
			}
			else
//				UFE.StartGame(0);
				UFE.WarningLevel2(0f);
			break;
		case 11 :
			if(WeaponPopUp.level2buyarmour == true)
			{
				characterUpgradeValue = 15;
				this.characterUpgrade();
			}
			else
				UFE.treemanWarning2Popup(0);
			break;
		case 12 :
			if(WeaponPopUp.level2buygadha2 == true)
			{
				characterUpgradeValue = 16;
				this.characterUpgrade();
			}
			else
				UFE.treemanWarning3Popup(0);
			break;
		case 13 :
			if(WeaponPopUp.level2buyarmour2 == true)
			{
				characterUpgradeValue = 17;
				this.characterUpgrade();
			}
			else
				UFE.treemanWarning4Popup(0);
			break;
		case 18 :
			if(WeaponPopUp.level2buyarmour3 == true)
			{
				characterUpgradeValue = 25;
				this.characterUpgrade();
			}
			else
				UFE.lankiniWarningPopUp(0);
			break;
		case 19 :
			if(WeaponPopUp.level3buygadha == true)
			{
				characterUpgradeValue = 23;
				this.characterUpgrade();
			}
			else
				UFE.WarningLevel3(0);
			break;
		case 20 :
			if(WeaponPopUp.level3buygadha2 == true)
			{
				characterUpgradeValue = 24;
				this.characterUpgrade();
			}
			else
				UFE.MahiravanaWarningPopup(0);
			break;
		case 21 :
			if(WeaponPopUp.level3buyarmour == true)
			{
				characterUpgradeValue = 22;
				this.characterUpgrade();
			}
			else
				UFE.indrajithWarningPopUp(0);
			break;
			default : 
				UFE.StartGame (0);
				break;
		}
	} 

	void characterUpgrade()
	{
		CharacterInfo[] selectableCharacters = UFE.GetVersusModeSelectableCharacters ();
		CharacterInfo character = selectableCharacters [characterUpgradeValue];
		UFE.SetPlayer (1, character);
		IntroScreen.characterValue = 100;
		if (newLife <= 500 / 2) {
			UFE.updateEnergy (0f);
		}
		else
			UFE.StartGame(0);
	}
}

