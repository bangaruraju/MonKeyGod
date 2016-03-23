using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScorecardScript : MonoBehaviour {

	public GameObject coinbuy_prefab,SuccessOrFail_prefab,StoreDiaDolCell,CoinDiaCell,CoinDiaArmrCell,CoinDiaWeapCell,
						Scorecard_prefab,unlimted_energy_prefab,ThereUGo;
	private Vector3 position;
	private string COINS = "COINSI";
	private Text desc_txt,btn_txt;
	private string OkOrStore = "OKORSTORE",IsFromCoinStore = "ISFROMCOINSTORE",ItemCost = "ITEMCOST",ItemDiaCost = "ITEMDIACOST";
	public int itemList;
	public Transform contentPanel;
	public Sprite StoreBG,WeaponBG,ArmourBG,CoinBG;
	public List<Sprite> ArmourSpriteList, GadaSpriteList;
	private List<GameObject> templist = new List<GameObject>();	
	private GameObject tempGObject;
	private List<string> armour_list = new List<string>(),weapon_list = new List<string>(),coins_list = new List<string>(),
			coin_dia_pack = new List<string>(){"HAND FULL COINS","BAG OF COINS","SACK OF COINS","CHEST OF COINS"},
			dia_dollar_pack = new List<string>();
		//	dia_dollar_pack = new List<string>(){"10+2","60+6","10+10","250+20","650+50"};
	private int enable_int = 0;
	private string static_data = "[{\"Armour1\":\"35+50+25\"},{\"Armour2\":\"75+100+50\"},{\"Armour3\":\"115+150+70\"},{\"Armour4\":\"150+70+89\"},{\"Armour5\":\"190+200+99\"},{\"weapons1\":\"35+50+25\"},{\"weapons2\":\"75+100+50\"},{\"weapons3\":\"115+150+70\"},{\"weapons4\":\"150+70+89\"},{\"weapons5\":\"190+200+99\"},{\"coins1\":\"25+2\"},{\"coins2\":\"50+4\"},{\"coins3\":\"70+7\"},{\"coins4\":\"90+15\"},{\"diamond1\":\"10+2\"},{\"diamond2\":\"60+6\"},{\"diamond3\":\"100+10\"},{\"diamond4\":\"250+20\"},{\"diamond5\":\"650+50\"}]";
	Button but;
	float timeLimit = 100.0f;
	public GameObject WaitScene;

	void accessData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
				for(int i = 0;i<obj.list.Count;i++){
					string key = (string)obj.keys[i];
					////armour
					if(key.Equals("Armour1") || key.Equals("Armour2") || key.Equals("Armour3") 
					   || key.Equals("Armour4") || key.Equals("Armour5"))
						armour_list.Add(obj.GetField(key).ToString());
				
					///weapon
					else if(key.Equals("weapons1") || key.Equals("weapons2") || key.Equals("weapons3")
					        || key.Equals("weapons4") || key.Equals("weapons5"))
						weapon_list.Add(obj.GetField(key).ToString());
				
					//coins
					else if(key.Equals("coins1") || key.Equals("coins2") || key.Equals("coins3")
					        || key.Equals("coins4") || key.Equals("coins5"))
						coins_list.Add(obj.GetField(key).ToString());

					//diamonds
					else if(key.Equals("diamond1") || key.Equals("diamond2") || key.Equals("diamond3") 
					        || key.Equals("diamond4") || key.Equals("diamond5"))
						dia_dollar_pack.Add(obj.GetField(key).ToString());

					JSONObject j = (JSONObject)obj.list[i];
					accessData(j);
				}
				break;
		case JSONObject.Type.ARRAY:
				foreach(JSONObject j in obj.list){
					accessData(j);
				}
				break;
		}
	}

	void Start () {
		PlayerPrefs.SetInt ("isGui", 1);
		position = new Vector3 (Screen.width/2,Screen.height/2,0.0f);
		string str = "";
//			PlayerPrefs.GetString ("STOREJSON");
//		if (str.Equals (string.Empty))
			str = static_data;
		JSONObject varia = new JSONObject (str);
		accessData (varia);
		if(PlayerPrefs.GetString("ISFROM-DIALESS-DIALOG").Equals("FALSE"))
			if (PlayerPrefs.GetString ("ISFROMARMOUR").Equals ("TRUE"))
				InitialiseArmourCells ();
			else if (PlayerPrefs.GetString ("ISFROMARMOUR").Equals ("FALSE"))
				InitialiseWeaponCells ();
			else if (PlayerPrefs.GetString ("IS-TO-INIT-COINPREFAB").Equals ("TRUE"))
				InitialiseCoinCells ();
			else
				InitialiseDiamondCells ();
	}
	
	public	void OnWeaponclick()
	{
		PlayerPrefs.SetString ("ISFROMARMOUR","FALSE");
		InitialiseWeaponCells ();
	}

	public	void OnArmourclick()
	{
		PlayerPrefs.SetString ("ISFROMARMOUR","TRUE");
		InitialiseArmourCells ();
	}

	public	void OnCoinsclick()
	{
		PlayerPrefs.SetString ("ISFROMARMOUR",null);
		InitialiseCoinCells ();
	}

	public	void OnDiamondclick()
	{
		PlayerPrefs.SetString ("ISFROMARMOUR",null);
		InitialiseDiamondCells ();
	}

	public void InitialiseWeaponCells(){
		Button db, ab, wb, cb;
		try{
			 db = this.transform.GetChild(0).GetChild(0).GetComponent<Button>();
			 ab = this.transform.GetChild(0).GetChild(1).GetComponent<Button>();
			 wb = this.transform.GetChild(0).GetChild(2).GetComponent<Button>();
			 cb = this.transform.GetChild(0).GetChild(3).GetComponent<Button>();
			db.interactable = true;
			ab.interactable = true;
			wb.interactable = false;
			cb.interactable = true;

		Image im = this.transform.GetChild(0).GetComponent<Image>();
		im.overrideSprite = WeaponBG;
		foreach (GameObject var in templist) {
			Destroy (var);
		}
		for (int i = 0;i < weapon_list.Count();i++) {
			string iii = weapon_list[i];
			string[] dfd = iii.Split ('"');
			string var = dfd[1];
			string[] arr = var.Split('+');
			string coin = arr[0];
			string coin_and_dia = arr[1]+"+"+arr[2];
			GameObject newButton = Instantiate (CoinDiaWeapCell) as GameObject;
			enable_int = PlayerPrefs.GetInt("FIGHTTAG");
			if(enable_int >= i){
				switch(i){
					case 0:
						if(PlayerPrefs.GetString("ISWEAPON0BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 1:
						if(PlayerPrefs.GetString("ISWEAPON1BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 2:
						if(PlayerPrefs.GetString("ISWEAPON2BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 3:
						if(PlayerPrefs.GetString("ISWEAPON3BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 4:
						if(PlayerPrefs.GetString("ISWEAPON4BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
				}
			}
			else{
				newButton.GetComponent<Button>().interactable = false;
				Button[] list = newButton.GetComponentsInChildren<Button>();
				foreach(Button but in list)
					but.interactable = false;
			}
			
			Image im1 = newButton.GetComponent<Image>();
			im1.overrideSprite = GadaSpriteList[i];
			newButton.transform.GetChild(1).GetComponentInChildren<Text>().text = coin_and_dia;
			newButton.transform.GetChild(2).GetComponentInChildren<Text>().text = coin+"+";
			templist.Add(newButton);
			Button dcb = newButton.transform.GetChild(1).GetComponent<Button>();
			dcb.onClick.AddListener(() => OnDiamondBuyclick(coin_and_dia,1));
			Button ccb = newButton.transform.GetChild(2).GetComponent<Button>();
			ccb.onClick.AddListener(() => OnCoinBuyclick(int.Parse(coin),1));
			Transform dump =  contentPanel;
			RectTransform rect = dump.parent.GetComponent<RectTransform>();
			rect.anchorMax = new Vector2(rect.anchorMax.x,0.6647f);
			newButton.transform.SetParent (dump,false);
		}
		PlayerPrefs.SetString ("ISFROMARMOUR","FALSE");
		}
		catch(System.Exception e){
			Debug.Log("EXPTN : "+ e);
		}
	}
	
	public void InitialiseArmourCells(){
		Button db, ab, wb, cb;
		try{
			 db = this.transform.GetChild(0).GetChild(0).GetComponent<Button>();
			 ab = this.transform.GetChild(0).GetChild(1).GetComponent<Button>();
			 wb = this.transform.GetChild(0).GetChild(2).GetComponent<Button>();
			 cb = this.transform.GetChild(0).GetChild(3).GetComponent<Button>();
			db.interactable = true;
			ab.interactable = false;
			wb.interactable = true;
			cb.interactable = true;

		Image im = this.transform.GetChild(0).GetComponent<Image>();
		im.overrideSprite = ArmourBG;
		foreach (GameObject var in templist) {
			Destroy (var);
		}
		for (int i = 0;i < armour_list.Count();i++) {

			string iii = armour_list[i];
			string[] dfd = iii.Split ('"');
			string var = dfd[1];
			string[] arr = var.Split('+');
			string coin = arr[0];
			string coin_and_dia = arr[1]+"+"+arr[2];
			GameObject newButton = Instantiate (CoinDiaArmrCell) as GameObject;
			enable_int = PlayerPrefs.GetInt("FIGHTTAG");
			if(enable_int >= i ){
				switch(i){
					case 0:
						if(PlayerPrefs.GetString("ISARMOUR0BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 1:
						if(PlayerPrefs.GetString("ISARMOUR1BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 2:
						if(PlayerPrefs.GetString("ISARMOUR2BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 3:
						if(PlayerPrefs.GetString("ISARMOUR3BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
					case 4:
						if(PlayerPrefs.GetString("ISARMOUR4BAGED").Equals("TRUE")){
							newButton.GetComponent<Button>().interactable = false;
							Button[] list = newButton.GetComponentsInChildren<Button>();
							foreach(Button but in list)
								but.interactable = false;
						}
						break;
				}
			}
			else{
				newButton.GetComponent<Button>().interactable = false;
				Button[] list = newButton.GetComponentsInChildren<Button>();
				foreach(Button but in list)
					but.interactable = false;
			}
			Image im1 = newButton.GetComponent<Image>();
			im1.overrideSprite = ArmourSpriteList[i];
			newButton.transform.GetChild(1).GetComponentInChildren<Text>().text = coin_and_dia;
			newButton.transform.GetChild(2).GetComponentInChildren<Text>().text = coin+"+";
			templist.Add(newButton);
			Button dcb = newButton.transform.GetChild(1).GetComponent<Button>();
			dcb.onClick.AddListener(() => OnDiamondBuyclick(coin_and_dia,0));
			Button ccb = newButton.transform.GetChild(2).GetComponent<Button>();
			ccb.onClick.AddListener(() => OnCoinBuyclick(int.Parse(coin),0));
			Transform dump =  contentPanel;
			RectTransform rect = dump.parent.GetComponent<RectTransform>();
			rect.anchorMax = new Vector2(rect.anchorMax.x,0.6647f);
			newButton.transform.SetParent (dump,false);
		}
		PlayerPrefs.SetString ("ISFROMARMOUR","TRUE");
		}
		catch(System.Exception e){
			Debug.Log("EXPTN : "+ e);
		}
	}
	
	public void InitialiseCoinCells() {
		Button db, ab, wb, cb;
		try{
			 db = this.transform.GetChild(0).GetChild(0).GetComponent<Button>();
			 ab = this.transform.GetChild(0).GetChild(1).GetComponent<Button>();
			 wb = this.transform.GetChild(0).GetChild(2).GetComponent<Button>();
			 cb = this.transform.GetChild(0).GetChild(3).GetComponent<Button>();
		db.interactable = true;
		ab.interactable = true;
		wb.interactable = true;
		cb.interactable = false;

		Image im = this.transform.GetChild(0).GetComponent<Image>();
		im.overrideSprite = CoinBG;
		foreach (GameObject var in templist) {
			Destroy (var);
		}
		for (int i = 0;i < coins_list.Count();i++) {
			string iii = coins_list[i];
			string[] dfd = iii.Split ('"');
			string var = dfd[1];
			string[] arr = var.Split('+');
			string coin = arr[0];
			string dia = arr[1];
			GameObject newButton = Instantiate (CoinDiaCell) as GameObject;
			newButton.transform.GetChild(1).GetComponentInChildren<Text>().text = coin_dia_pack[i];
			newButton.transform.GetChild(2).GetComponentInChildren<Text>().text = coin;
			newButton.transform.GetChild(3).GetComponentInChildren<Text>().text = dia;
			templist.Add(newButton);
			Button dcb = newButton.transform.GetComponent<Button>();
			dcb.onClick.AddListener(() => OnCoin4Diamondclick(var));
			Transform dump =  contentPanel;
			RectTransform rect = dump.parent.GetComponent<RectTransform>();
			rect.anchorMax = new Vector2(rect.anchorMax.x,0.755f);
			newButton.transform.SetParent (dump,false);
		 }
		}
		catch(System.Exception e){
			Debug.Log("EXPTN : "+ e);
		}
	}
	
	public void InitialiseDiamondCells(){
		Button db, ab, wb, cb;
		try{
		 db = this.transform.GetChild(0).GetChild(0).GetComponent<Button>();
		 ab = this.transform.GetChild(0).GetChild(1).GetComponent<Button>();
		 wb = this.transform.GetChild(0).GetChild(2).GetComponent<Button>();
		 cb = this.transform.GetChild(0).GetChild(3).GetComponent<Button>();
		db.interactable = false;
		ab.interactable = true;
		wb.interactable = true;
		cb.interactable = true;
		
		Image im = this.transform.GetChild(0).GetComponent<Image>();
		im.overrideSprite = StoreBG;
		foreach (GameObject var in templist) {
			Destroy (var);
		}
			for (int i = 0;i < dia_dollar_pack.Count();i++) {
				string iii = dia_dollar_pack[i];
				string[] dfd = iii.Split ('"');
				string var = dfd[1];
				string[] arr = var.Split('+');
				string dia = arr[0];
				string dollar = arr[1];
				GameObject newButton = Instantiate (StoreDiaDolCell) as GameObject;
				newButton.transform.GetChild(2).GetComponentInChildren<Text>().text = dia;
				newButton.transform.GetChild(3).GetComponentInChildren<Text>().text = dollar;
				templist.Add(newButton);
				Button dcb = newButton.transform.GetComponent<Button>();
				dcb.onClick.AddListener(() => OnDiamond4Dollarclick(var));
			Transform dump =  contentPanel;
			RectTransform rect = dump.parent.GetComponent<RectTransform>();
			rect.anchorMax = new Vector2(rect.anchorMax.x,0.755f);
			newButton.transform.SetParent (dump,false);
		 }
		}
		catch(System.Exception e){
			Debug.Log("EXPTN : "+ e);
		}
	}

	public	void OnCoinBuyclick(int var,int armORweap)
	{
		int coin_count = PlayerPrefs.GetInt (COINS);
		if (var > coin_count || coin_count == 0) {}
		else
		if(var == 35)
			if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR0BAGED","TRUE");
			else
				PlayerPrefs.SetString("ISWEAPON0BAGED","TRUE");
		else if(var == 75)
			if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR1BAGED","TRUE");
			else
				PlayerPrefs.SetString("ISWEAPON1BAGED","TRUE");
		else if(var == 115)
			if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR2BAGED","TRUE");
			else
				PlayerPrefs.SetString("ISWEAPON2BAGED","TRUE");
		else if(var == 150)
			if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR3BAGED","TRUE");
			else
				PlayerPrefs.SetString("ISWEAPON3BAGED","TRUE");
		else if(var == 190)
			if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR4BAGED","TRUE");
			else
				PlayerPrefs.SetString("ISWEAPON4BAGED","TRUE");
		PlayerPrefs.SetInt (ItemCost,var);
		Instantiate (coinbuy_prefab,position,Quaternion.identity);	
		Destroy (this.gameObject);
	}
	public	void OnOutsideclick(int var)
	{
		WaitAgain wg = new WaitAgain ();
		wg.OnResumeGame ();

		if (PlayerPrefs.GetInt ("DIAMOND") > 2) {
			PlayerPrefs.SetInt ("isGui", 0);
		}
		PlayerPrefs.SetString ("ISFROMARMOUR", null);
		Destroy (this.gameObject);
	}
	public	void OnDiamondBuyclick(string var,int armORweap)
	{
		string[] temp = var.Split ('+');
		int coin = int.Parse (temp [0]);
		int dia = int.Parse (temp [1]);
		PlayerPrefs.SetInt (ItemCost,coin);
		PlayerPrefs.SetInt (ItemDiaCost,dia);
		PlayerPrefs.SetString (IsFromCoinStore,"FALSE");
		GameObject tempTextBox = (GameObject)Instantiate (SuccessOrFail_prefab,position,Quaternion.identity);
		btn_txt = tempTextBox.transform.GetChild(0).GetChild(1).GetComponentInChildren<Text>();
		desc_txt = tempTextBox.transform.GetChild(0).GetChild(2).GetComponent<Text>();
		but = tempTextBox.transform.GetChild(0).GetChild(3).GetComponent<Button>();
		if (coin > PlayerPrefs.GetInt (COINS) || dia > PlayerPrefs.GetInt ("DIAMOND") || 
		    PlayerPrefs.GetInt (COINS) == 0 || PlayerPrefs.GetInt ("DIAMOND") == 0) {
			if(PlayerPrefs.GetInt (COINS) == 0 || coin > PlayerPrefs.GetInt (COINS)){
				desc_txt.text = "PLEASE PURCHASE \n COINS";
				PlayerPrefs.SetString (IsFromCoinStore,"TRUE");
			}
			else
				desc_txt.text = "PLEASE PURCHASE \n DIAMONDS";
			btn_txt.text = "STORE";
			PlayerPrefs.SetString (OkOrStore, "STORE");
		} else {
			if(var.Equals("50+25"))
				if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR0BAGED","TRUE");
				else
					PlayerPrefs.SetString("ISWEAPON0BAGED","TRUE");
			else if(var.Equals("100+50"))
				if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR1BAGED","TRUE");
				else
					PlayerPrefs.SetString("ISWEAPON1BAGED","TRUE");
			else if(var.Equals("150+70"))
				if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR2BAGED","TRUE");
				else
					PlayerPrefs.SetString("ISWEAPON2BAGED","TRUE");
			else if(var.Equals("170+89"))
				if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR3BAGED","TRUE");
				else
					PlayerPrefs.SetString("ISWEAPON3BAGED","TRUE");
			else if(var.Equals("200+99"))
				if(armORweap == 0)
				PlayerPrefs.SetString("ISARMOUR4BAGED","TRUE");
				else
					PlayerPrefs.SetString("ISWEAPON4BAGED","TRUE");
			PlayerPrefs.SetInt(COINS,PlayerPrefs.GetInt (COINS) - coin);
			PlayerPrefs.SetInt("DIAMOND",PlayerPrefs.GetInt ("DIAMOND") - dia);
			tempTextBox.transform.GetChild (0).GetChild (0).gameObject.SetActive(false);
			desc_txt.text = "YOUR TRANSACTION \n IS SUCCESSFUL";
			btn_txt.text = "OK";
			PlayerPrefs.SetString(OkOrStore,"OK");
			but.gameObject.SetActive(false);
		}
		Destroy (this.gameObject);
		PlayerPrefs.SetString ("ISFROMARMOUR", null);
		PlayerPrefs.SetString("ISFROM-DIALESS-DIALOG","TRUE");
	}
	public	void OnInstantBuyclick()
	{	
		Destroy (this.gameObject);
		Instantiate (Scorecard_prefab,position,Quaternion.identity);
	}
	public	void OnCoinAndVideoclick()
	{
		PlayerPrefs.SetString (IsFromCoinStore,"TRUE");
		int coin_count = PlayerPrefs.GetInt (COINS);
		GameObject tempTextBox = (GameObject)Instantiate (SuccessOrFail_prefab,position,Quaternion.identity);
		btn_txt = tempTextBox.transform.GetChild(0).GetChild(1).GetComponentInChildren<Text>();
		desc_txt = tempTextBox.transform.GetChild(0).GetChild(2).GetComponent<Text>();
		but = tempTextBox.transform.GetChild(0).GetChild(3).GetComponent<Button>();
		Destroy (this.gameObject);
		if (PlayerPrefs.GetInt (ItemCost) > coin_count || coin_count == 0) {
			desc_txt.text = "PLEASE PURCHASE \n COINS";
			btn_txt.text = "STORE";
			PlayerPrefs.SetString (OkOrStore, "STORE");
		} else {
			Vungle.playAd(true, "QuantumLeap"); 
			Vungle.onAdFinishedEvent += (adFinishedEventArgs) => {
				if(adFinishedEventArgs.IsCompletedView){
					PlayerPrefs.SetInt (COINS, coin_count - PlayerPrefs.GetInt (ItemCost));
					tempTextBox.transform.GetChild (0).GetChild (0).gameObject.SetActive(false);
					desc_txt.text = "YOUR TRANSACTION \n IS SUCCESSFUL";
					btn_txt.text = "OK";
					PlayerPrefs.SetString (OkOrStore, "OK");
					but.gameObject.SetActive (false);
				}
				else{
					
				}
			};
		}

		PlayerPrefs.SetString("ISFROM-DIALESS-DIALOG","TRUE");
	}
	public	void OnOkorStoreclick(int var)
	{
		Destroy (this.gameObject);
		PlayerPrefs.SetString ("ISFROMARMOUR", null);
		if (PlayerPrefs.GetString (OkOrStore).Equals ("STORE")) {
			if (var == 1)
			if (PlayerPrefs.GetString (IsFromCoinStore).Equals ("TRUE"))
				PlayerPrefs.SetString ("IS-TO-INIT-COINPREFAB", "TRUE");
			else
				PlayerPrefs.SetString ("IS-TO-INIT-COINPREFAB", "FALSE");
			Instantiate (Scorecard_prefab, position, Quaternion.identity);
			PlayerPrefs.SetString ("ISFROM-DIALESS-DIALOG", "FALSE");
		} else {

			Instantiate (ThereUGo, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		}
	}
	public	void OnDiamond4Dollarclick(string var)
	{
		print ("might working :"+var);
	}
	public	void OnWaitClick(int var)
	{
		GameObject timer = (GameObject)Instantiate (WaitScene, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		Destroy (this.gameObject);
	}

	public	void OnCoin4Diamondclick(string var)
	{
		string[] temp = var.Split ('+');
		int coin = int.Parse (temp [0]);
		int dia = int.Parse (temp [1]);
		GameObject tempTextBox = (GameObject)Instantiate (SuccessOrFail_prefab,position,Quaternion.identity);
		btn_txt = tempTextBox.transform.GetChild(0).GetChild(1).GetComponentInChildren<Text>();
		desc_txt = tempTextBox.transform.GetChild(0).GetChild(2).GetComponent<Text>();
		but = tempTextBox.transform.GetChild(0).GetChild(3).GetComponent<Button>();
		Destroy (this.gameObject);
		PlayerPrefs.SetString("ISFROM-DIALESS-DIALOG","TRUE");
		if (dia > PlayerPrefs.GetInt ("DIAMOND") || PlayerPrefs.GetInt ("DIAMOND") == 0) {
			desc_txt.text = "PLEASE PURCHASE \n DIAMONDS";
			btn_txt.text = "STORE";
			PlayerPrefs.SetString(OkOrStore,"STORE");
			PlayerPrefs.SetString("IS-TO-INIT-COINPREFAB","FALSE");
		} else {
			PlayerPrefs.SetInt(COINS,PlayerPrefs.GetInt (COINS) + coin);
			PlayerPrefs.SetInt("DIAMOND",PlayerPrefs.GetInt ("DIAMOND") - dia);
			tempTextBox.transform.GetChild (0).GetChild (0).gameObject.SetActive(false);
			desc_txt.text = "YOUR TRANSACTION \n IS SUCCESSFUL";
			btn_txt.text = "OK";
			PlayerPrefs.SetString(OkOrStore,"OK");
			but.gameObject.SetActive(false);
		}
	}

//	void OnLogin (bool success) {
//		
//		statusMsg = "";
//		if (success) {
//			GamedoniaUsers.GetMe(delegate(bool suc,GDUserProfile profile ) {
//				//Requesting pro.geducts		
//				//GamedoniaStore.RequestProducts (productsList, productsList.Length);
//
//				keys = new string[1];
//				//keys[0] = "android.test.purchased";
//				keys[0] = "android.test.purchased";
//				//keys[0] = "android.test.purchased";p.one
//				GamedoniaStore.RequestProducts(keys, keys.Length);
//			});
//	
//		}else {
//			errorMsg = GamedoniaBackend.getLastError().ToString();
//			Debug.Log(errorMsg);
//		}
//		
//	}
//	private void OnProductsRequested() {
//		if (GamedoniaStore.productsRequestResponse.success) {
//			//request Success...
//		} else {
//			//TODO process request products failure
//		}
//	}
//	private void OnProductPurchased() { 
//		PurchaseResponse purchase = GamedoniaStore.purchaseResponse;
//		//TODO: process the purchase details here
//		//OneTxt.text = "two suc 00";
//		if (purchase.success) {
//		} 
//		else {
//		}
//	}

}
