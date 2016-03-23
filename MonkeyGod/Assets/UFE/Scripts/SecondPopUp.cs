using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SecondPopUp : UFEScreen {
	private int Fight;
	private int characterUpgradeValue;
	private int level;

	public Texture2D fullTex;
	public Texture2D emptyTex;
	public Vector2 size = new Vector2(0,0);
	public float barDisplay;
	public bool displayProgressBar = false;
	int noOfSeconds = 0;
	public Font customFont;

	// Use this for initialization
	void Start () {
		string str = PlayerPrefs.GetString ("FIGHTSERVERVALUES");
		JSONObject jsonObj = new JSONObject (str);
		this.accessData (jsonObj);

		string level_fgt = PlayerPrefs.GetString("LEVEL");
		int fightTag = PlayerPrefs.GetInt ("FIGHTTAG");
		if (level_fgt.Equals ("LEVELI"))
		{
			if(fightTag==0){
			startProgressBar ();
			StartCoroutine (Ftree ());
			}
			else
			{
				startProgressBar ();
				StartCoroutine (startGame());
			}
		}
		else if (level_fgt.Equals ("LEVELII"))
		{
			startProgressBar ();
			StartCoroutine (startGame());
		}
		else if (level_fgt.Equals ("LEVELIII"))
		{
			startProgressBar ();
			StartCoroutine (startGame());
		}
	}

	// Update is called once per frame
	void Update() {
		if (displayProgressBar) {
			barDisplay = (noOfSeconds /2.1f);
		}
	}
	void OnGUI() {
		if (displayProgressBar) {
			GUI.BeginGroup (new Rect (Screen.width / 2f-Screen.width/1.2f/2, Screen.height / 1.15f, Screen.width/1.15f, Screen.height / 2));
			GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f, Screen.height / 11), emptyTex);
			GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f*(barDisplay),Screen.height / 11),fullTex);
			GUI.skin.label.normal.textColor = Color.white;
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			GUI.Label (new Rect(0,0,Screen.width/1.2f,Screen.height / 11), "LOADING");
			GUI.EndGroup ();
			
		}
	}
	public void wait_Mthd(){

	}
	private string Firstfightcoin="35";
	private string	Firstfightdiamond="1";
	void accessData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				if(key.Equals("Firstfightcoin")){
					Firstfightcoin	= obj.GetField("Firstfightcoin").ToString();
					Firstfightcoin=Firstfightcoin.Replace("\"",string.Empty).Trim();
				}
				else if(key.Equals("Firstfightdiamond")){
					Firstfightdiamond = obj.GetField("Firstfightdiamond").ToString();
					Firstfightdiamond = Firstfightdiamond.Replace("\"",string.Empty).Trim();
				}
			}
			break;
		case JSONObject.Type.ARRAY:
			foreach(JSONObject j in obj.list){
				accessData(j);
			}
			break;
		case JSONObject.Type.STRING:
			Debug.Log(obj.str);
			break;
		case JSONObject.Type.NUMBER:
			Debug.Log(obj.n);
			break;
		case JSONObject.Type.BOOL:
			Debug.Log(obj.b);
			break;
		case JSONObject.Type.NULL:
			Debug.Log("NULL");
			break;
			
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
	private int coinValue;
	public void tryAgain_Mthd(){
//		UFE.HideScreen (UFE.currentScreen);
		coinValue = 35;
		if (InternetStatus ()) {
			Vungle.playAd (true, "QuantumLeap"); 
			Vungle.onAdFinishedEvent += (adFinishedEventArgs) => {
				if (adFinishedEventArgs.IsCompletedView) {
					
					Fight = PlayerPrefs.GetInt ("FIGHTTAG");
					int coinsCount = PlayerPrefs.GetInt ("COINSI");
					string level_fgt = PlayerPrefs.GetString("LEVEL");
					if (level_fgt.Equals ("LEVELI"))
						level = 1;
					else if (level_fgt.Equals ("LEVELII"))
						level = 2;
					else if (level_fgt.Equals ("LEVELIII"))
						level = 3;

					switch (Fight) {
					case 0: 
//						if (coinsCount >= coinValue) {
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
//							}
//						else {
//							UFE.HideScreen (UFE.currentScreen);
//							UFE.waitUI (0f);
//							}
						break;
					case 1: 
//						if (coinsCount >= coinValue) {
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
//							} 
//						else {
//								UFE.HideScreen (UFE.currentScreen);
//								UFE.waitUI (0f);
//							}
						break;
					case 2: 
//						if (coinsCount >= coinValue) {
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
//							}
//						else {
//								UFE.HideScreen (UFE.currentScreen);
//								UFE.waitUI (0f);
//							}
						break;
					case 3: 
//						if (coinsCount >= coinValue) {
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
//							} 
//						else {
//								UFE.HideScreen (UFE.currentScreen);
//								UFE.waitUI (0f);
//							}
						break;
					case 4: 
//						if (coinsCount >= coinValue) {
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
//							} else {
//								UFE.HideScreen (UFE.currentScreen);
//								UFE.waitUI (0f);
//							}
						break;
					}
				}
				else {
//					UFE.tryAgainPopUp(0f);
				}
				
			};
		}else {
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
	private Text coinsText;
	private Text diamondText;
	private Text editText;
	
	IEnumerator Ftree()
	{
		yield return new WaitForSeconds(3f);
		UFE.HideScreen(UFE.currentScreen);
		UFE.weaponPopup (0f);
		coinsText = GameObject.Find("BuyWeaponPopUp(Clone)").transform.GetChild(2).GetChild(0).GetComponent<UnityEngine.UI.Text>();
		coinsText.text = Firstfightcoin;
		diamondText = GameObject.Find("BuyWeaponPopUp(Clone)").transform.GetChild(3).GetChild(0).GetComponent<UnityEngine.UI.Text>();
		diamondText.text = "  "+Firstfightdiamond;
		editText = GameObject.Find("BuyWeaponPopUp(Clone)").transform.GetChild(4).GetChild(0).GetComponent<UnityEngine.UI.Text>();
		editText.text = "wait";
	}
	public void stopProgressBar(){
		displayProgressBar = false;
	}
	public void startProgressBar(){
		displayProgressBar = true;
		noOfSeconds = 0;
		StartCoroutine(Example());
	}
	IEnumerator Example() {
		yield return new WaitForSeconds(1);
		noOfSeconds = noOfSeconds + 1;
		if(noOfSeconds<3){
			StartCoroutine(Example());
		}
		else {
			displayProgressBar = false;
			noOfSeconds = 0;
		}
	}
	IEnumerator startGame()
	{
		yield return new WaitForSeconds(3f);
		UFE.HideScreen(UFE.currentScreen);
		UFE.StartGame (0f);
	}
}
