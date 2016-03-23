using UnityEngine;
using System.Collections;

public class SuccessUI : UFEScreen {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void okMthd()
	{
		int newLife = (int)(PlayerPrefs.GetFloat ("HEALTH"));
		if (newLife <= 500 / 2) {
			UFE.HideScreen (UFE.currentScreen);
			UFE.updateEnergy (0f);
		} 
		else {
			IntroScreen.characterValue = 100;
			UFE.HideScreen (UFE.currentScreen);
			UFE.StartGame (0);
		}
	}
}