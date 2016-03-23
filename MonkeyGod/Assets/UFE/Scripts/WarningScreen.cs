using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WarningScreen : UFEScreen {
	public Texture2D fullTex;
	public Texture2D emptyTex;
	public Vector2 size = new Vector2(0,0);
	public float barDisplay;
	public bool displayProgressBar = false;
	int noOfSeconds = 0;
	public Font customFont;
	private bool eventTriggerCheck = false;
	// Use this for initialization
	void Start () {
		eventTriggerCheck = false;
		string str = PlayerPrefs.GetString ("FIGHTSERVERVALUES");
		JSONObject jsonObj = new JSONObject (str);
		this.accessData (jsonObj);

	}
	void OnGUI() {
		if (displayProgressBar) {
			GUI.BeginGroup (new Rect (Screen.width / 2f-Screen.width/1.2f/2, Screen.height / 1.1f, Screen.width/1.15f, Screen.height / 2));
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
	// Update is called once per frame
	void Update () {
		if (displayProgressBar) {
			barDisplay = (noOfSeconds /2.1f);
		}
	}
	public void warning(){
		if (!eventTriggerCheck) {
			string level_fgt = PlayerPrefs.GetString("LEVEL");
			if (level_fgt.Equals ("LEVELI"))
			{
				startProgressBar ();
				StartCoroutine (Ftree ());
				eventTriggerCheck = true;
			}
			else if (level_fgt.Equals ("LEVELII"))
			{
				startProgressBar ();
				StartCoroutine (levelTwoFirstFight ());
				eventTriggerCheck = true;
			}
			else if (level_fgt.Equals ("LEVELIII"))
			{
				startProgressBar ();
				StartCoroutine (levelTwoFirstFight ());
				eventTriggerCheck = true;
			}
		}
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
private string Firstfightcoin="35";
private string	Firstfightdiamond="1";
	void accessData(JSONObject obj){
		switch(obj.type){
			case JSONObject.Type.OBJECT:
				for(int i = 0; i < obj.list.Count; i++){
					string key = (string)obj.keys[i];
					JSONObject j = (JSONObject)obj.list[i];
//					accessData(j);
					if(key.Equals("Firstfightcoin")){
						Firstfightcoin	= obj.GetField("Firstfightcoin").ToString();
						Firstfightcoin=Firstfightcoin.Replace("\"",string.Empty).Trim();
//						Debug.Log(Firstfightcoin);
					}
					else if(key.Equals("Firstfightdiamond")){
						Firstfightdiamond = obj.GetField("Firstfightdiamond").ToString();
						Firstfightdiamond = Firstfightdiamond.Replace("\"",string.Empty).Trim();
//						Debug.Log(Firstfightdiamond);
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
	IEnumerator levelTwoFirstFight()
	{
		yield return new WaitForSeconds(3f);
		UFE.HideScreen(UFE.currentScreen);
		UFE.StartGame (0f);
	}
}