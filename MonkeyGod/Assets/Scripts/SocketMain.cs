using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

public class SocketMain : MonoBehaviour {

	[HideInInspector]public static SocketIOComponent socket;
	[HideInInspector]public JSONObject jsonObj;
	[HideInInspector]public string str;
	[HideInInspector] public Dictionary<string, string> userData;
	[HideInInspector]public string lb;
	[HideInInspector]public GameObject go;
	[HideInInspector]public static string userId;
	[HideInInspector] public Dictionary<string, string> data;
	[HideInInspector] public Dictionary<string, string> lbData;
	[HideInInspector] public Dictionary<string, string> scoreData;
	[HideInInspector] public static ArrayList nameArray;
	[HideInInspector] public static ArrayList scoreArray;
	[HideInInspector]public int i;
	[HideInInspector] public static int DISCONNECTERROR = 0;
	[HideInInspector] public static ArrayList rankArray;



	public static ArrayList LeaderFinalList; 
	public static Dictionary<string, string> lbDict; 
	public Dictionary<string,string> finalLBDict;
	[HideInInspector] public static ArrayList useridArray;

	[HideInInspector] public static ArrayList armourArray;
	[HideInInspector] public static ArrayList coinsArray;
	[HideInInspector] public static ArrayList weaponsArray;


	
	// Use this for initialization
		void Start () {
		useridArray = new ArrayList ();
		rankArray = new ArrayList ();
		LeaderFinalList = new ArrayList();
		lbDict = new Dictionary<string,string> ();
		finalLBDict = new Dictionary<string,string> ();
		nameArray = new ArrayList ();
		scoreArray = new ArrayList ();
		armourArray = new ArrayList ();
		weaponsArray = new ArrayList ();
		coinsArray = new ArrayList ();


			userData = new Dictionary<string,string> ();
			userData.Add ("appName", "MonkeyGod");
			userData.Add ("email", "test@test.com");
			userData.Add ("name", "nag");
			userData.Add ("pic", "not available");
			userData.Add ("country", "india");
			userData.Add ("city", "hyd");
			userData.Add ("deviceToken", "not available");
			userData.Add ("mobileId", "54854");
			userData.Add ("mobileModel", "samsung");
			userData.Add ("gender", "male");
			userData.Add ("os", "ios");

		str = "{\"appName\":\"MonkeyGod\",\"email\" : \"test@test.com\", \"name\" :  \"nag\",\"pic\" : \"not available\",\"country\" : \"india\",\"city\" :  \"hyd\",\"deviceToken\" : \"not existed\",\"mobileId\" : \"54854\",\"mobileModel\" : \"samsung\",\"gender\" :  \"male\",\"os\" :  \"android\"}";

		lbData = new Dictionary<string, string>();
		lbData.Add ("appName", "MonkeyGod");
		lbData.Add ("leaderBoardName", "MonkeyGodLeaderBoard");
		lbData.Add("startValue","0");
		lbData.Add ("endValue","9");

		scoreData = new Dictionary<string, string>();
		scoreData.Add("appName","MonkeyGod");
		scoreData.Add ("leaderBoardName", "MonkeyGodLeaderBoard");
		scoreData.Add("score","100");


		data = new Dictionary<string, string>();
		data["appName"] = "MonkeyGod";


			jsonObj = new JSONObject (str);
			go = GameObject.Find ("SocketIO");
			socket = go.GetComponent<SocketIOComponent> ();
	
			socket.On ("open", TestOpen);
			socket.On ("error", TestError);
			socket.On ("test", test);
			socket.On ("loginWithMail", loginWithMail);
			socket.On ("globalLeaderBoard", globalLeaderBoard);
			socket.On ("getUserInfo",getUserInfo);
			socket.On ("addScoreToLeaderBoard", addScoreToLeaderBoard);
			socket.On ("welcome", welcome);
			socket.On ("getSessionPowerInfo", getSessionPowerInfo);

	}

	// Update is called once per frame
	void Update () {
		i = PlayerPrefs.GetInt ("LBSocketCall");
		if (i == 1) {
			try{
			int coinsCount=PlayerPrefs.GetInt("COINSI");	
			int diamondCount = PlayerPrefs.GetInt ("DIAMOND");
			int bananaCount = PlayerPrefs.GetInt("BANANAS_COUNT");
			int totalCoinsCount = PlayerPrefs.GetInt("coinRandom");
			int videoWatchedCount = PlayerPrefs.GetInt("VIDEOWATCHCOUNT");
			data["Coins"] = coinsCount.ToString();
			data["Diamonds"] = diamondCount.ToString();
			data["Bananas"] = diamondCount.ToString();
			data["TotalCoins"] = totalCoinsCount.ToString();
			data["VideoCount"] = videoWatchedCount.ToString();
			data["givenPowerValue"] = "80";
			data["earnedPowerValue"] = "50";
			data["level"] = "1";

			socket.Emit ("getSessionPowerInfo", new JSONObject(data));
			int score = (int)PlayerPrefs.GetFloat("SCRORE");
			scoreData["score"] = score.ToString();
			socket.Emit ("addScoreToLeaderBoard", new JSONObject(scoreData));
			PlayerPrefs.SetInt("LBSocketCall",2);
			}catch{

			}
		}
		if (DISCONNECTERROR == 200) {
			PlayerPrefs.SetInt("disconnectError",0);
		} else {
			PlayerPrefs.SetInt("disconnectError",1);
		}
	}

	public void addScoreToLeaderBoard(SocketIOEvent e)
	{
//			Debug.Log ("[SocketIO] test received: " + e.name + " " + e.data);
			lbData["userId"]=userId;
			i = PlayerPrefs.GetInt ("LBSocketCall");
			if(i == 2){
			socket.Emit ("globalLeaderBoard", new JSONObject(lbData));
			PlayerPrefs.SetInt("LBSocketCall",0);
			}
	}
	public void getUserInfo(SocketIOEvent e)
	{		
//			Debug.Log ("[SocketIO] test received: " + e.name + " " + e.data);
			jsonObj = e.data["powers"];
			string str = jsonObj.ToString();
			PlayerPrefs.SetString("FIGHTSERVERVALUES",str);

			scoreData.Add ("userId",userId);
			lbData.Add("userId",userId);
			socket.Emit ("globalLeaderBoard", new JSONObject(lbData));
	}
	public void getSessionPowerInfo(SocketIOEvent e)
	{
//		Debug.Log ("[SocketIO] getSessionPowerInfo received: " + e.name + " " + e.data);

	}
	public void globalLeaderBoard(SocketIOEvent e)
	{
//			Debug.Log ("[SocketIO] test received: " + e.name + " " + e.data);
			jsonObj = new JSONObject ();
			jsonObj = e.data;
			jsonObj = jsonObj.GetField ("list");
			LeaderFinalList.Clear();
			nameArray.Clear();
			scoreArray.Clear();
			useridArray.Clear();
			rankArray.Clear();
			accessData (jsonObj);
			foreach(Dictionary<string,string> dict in LeaderFinalList)
			{
				if(dict.ContainsKey("name")){
				string name = dict["name"];
					nameArray.Add(name);
				}
				else
				{
					string name = "None";
					nameArray.Add(name);
				}
				if(dict.ContainsKey("score"))
				{
					string score = dict["score"];
					scoreArray.Add(score);
				}
				else{
					string score = "None";
					scoreArray.Add(score);
				}
				if(dict.ContainsKey("member"))
				{
					string member = dict["member"];
					useridArray.Add(member);
				}
				else{
					string member = "0";
					useridArray.Add(member);
				}
				if(dict.ContainsKey("rank"))
				{
					string rank = dict["rank"];
					rankArray.Add(rank);
				}
				else{
					string rank = "0";
					rankArray.Add(rank);
				}
			}
	}
	void accessData(JSONObject obj){
			switch(obj.type){
		case JSONObject.Type.OBJECT:
			Dictionary<string,string> dic = new Dictionary <string,string> ();
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				if(key.Equals("member")){
					JSONObject j = (JSONObject)obj.list[i];
					accessData(j);
					dic["member"] = obj.GetField("member").ToString();
				}else if(key.Equals("name")){
					JSONObject j = (JSONObject)obj.list[i];
					accessData(j);
					dic["name"] = obj.GetField("name").ToString();
				}
				else if(key.Equals("score")){
					JSONObject j = (JSONObject)obj.list[i];
					accessData(j);
					dic["score"] = obj.GetField("score").ToString();
				}
				else if(key.Equals("rank")){
					JSONObject j = (JSONObject)obj.list[i];
					accessData(j);
					dic["rank"] = obj.GetField("rank").ToString();
				}
		}
			LeaderFinalList.Add(dic);
			break;
		case JSONObject.Type.ARRAY:
			foreach(JSONObject j in obj.list){
				accessData(j);
			}
			break;
		case JSONObject.Type.STRING:
			break;
		case JSONObject.Type.NUMBER:
			break;
		case JSONObject.Type.BOOL:
			break;
		case JSONObject.Type.NULL:
			break;
			
		}
	}

	public void loginWithMail(SocketIOEvent e)
	{		
//			Debug.Log ("[SocketIO] loginWithMail received: " + e.name + " " + e.data ["userId"]);
			userId = e.data ["userId"].ToString();
			userId=userId.Replace("\"",string.Empty).Trim();
			data["userId"] = userId;
			socket.Emit("getUserInfo", new JSONObject(data));
	}
	public void test(SocketIOEvent e)
	{		
//			Debug.Log ("[SocketIO] test received: " + e.name + " " + e.data);
			DISCONNECTERROR = 200;
			socket.autoConnect = false;
			socket.Emit ("loginWithMail", new JSONObject(userData));
	}

	public void welcome(SocketIOEvent e)
	{
//			Debug.Log ("[SocketIO] test received: " + e.name + " " + e.data);
			DISCONNECTERROR = 200;
			socket.autoConnect = false;
			socket.Emit ("loginWithMail", jsonObj);

	}

	public void TestOpen(SocketIOEvent e)
	{
			Debug.Log ("[SocketIO] test received: " + e.name + " " + e.data);
			DISCONNECTERROR = 200;
			socket.autoConnect = false;
			socket.Emit ("loginWithMail", jsonObj);
	}
	public void TestError(SocketIOEvent e)
	{		
			DISCONNECTERROR = 404;
			Debug.Log ("[SocketIO] Error received: " + e.name + " " + e.data);

	}
}
