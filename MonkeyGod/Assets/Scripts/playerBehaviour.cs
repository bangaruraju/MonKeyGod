using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using System.Collections.Generic;

/*
	 *
	 *  Hanuman All Operations....Hanuman Triggers And Collisions..
	 * 	Handles All Audio Files Integrations..
	 * 	Handles All UI Content i.e Score and life Architechre and Health and RunEnergy based things..
	 *
	 */

//namespace UnityStandardAssets.Characters.ThirdPerson
//{
[RequireComponent(typeof(ThirdPersonUserControl))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class playerBehaviour : MonoBehaviour
{
	private bool isBridgeLevelIIZoom=false;
	private bool isBridgeLevelIIZoomForLandSevn=false;
	private bool isZoomed = false;
	private bool isJetPackZoomed =false;
	private bool isPlatformZoom = false;
	public Text coinText;
	public Text LankText;
	public Text DistanceText;
//	public GameObject plantobj;
	// AUDIO FILES
	AudioSource AudioSourceControl;
	AudioClip CollectAudioClip;
	AudioSource BoxTouchAudoSource;
	AudioClip BoxTouchClip;
	AudioSource ForceFieldAudoSource;
	AudioClip ForceFieldClip;
	AudioSource FallingFaltFormAudoSource;
	AudioClip FallingFaltFormClip;
	AudioSource JetPackAudoSource;
	AudioClip JetPackClip;
	AudioSource StoneBridgeFallAudoSource;
	AudioClip StoneBridgeFallClip;
	AudioSource PowerUpAudoSource;
	AudioClip PowerUpClip;
	AudioSource TopHeadTouchAudoSource;
	AudioClip SoldierTopTouchClip;
	AudioClip PlantTopTouchClip;
	AudioClip SpringTopTouchClip;
	AudioClip FallingTreeClip;
	AudioClip HealthReductionClip;
	AudioSource SkeletonAppearanceAudoSource;
	AudioClip FirstSkeletonAppearanceClip;
	AudioSource PlatformAudoSource;
	AudioClip WaterFallAudoClip;
	AudioClip XAxisPlatformAudoClip;
	AudioClip RotatePlatformAudoClip;
	AudioClip Puzzle1Clip;
	AudioClip Puzzle2Clip;
	AudioClip Puzzle3Clip;
	AudioClip Puzzle4Clip;
	
	
	
	
//	public Texture2D emptyTex;
	float diffInDistance = 0;
	float enemyDistance;
	public GameObject singleCoinObj1;
	private GameObject singleCoinObj2;
	private int swimpos = 0;
	private cameraShake camshake;
	private ThirdPersonUserControl m_Character_User_Ctrl;
	private ThirdPersonCharacter m_Character;
	private int coinTossValue = 0;
	private bool isLeft;
	private int count;
	private float Lankacount=0f;
	public static string backRestrict = "BACKRESTRICT";
	private int moveDirection = 0;
	public int hangingState = 0;
	public GameObject rock;
	public GameObject backwardRollingRock;
	Vector3 movement;// The vector to store the direction of the player's movement.
	// Reference to the animator component.
	public Rigidbody playerRigidbody;
	public float speed;
	Animator anim;
	private bool backAnimStatus = false;
	private bool slideAnimStatus = false;
	private bool isRock = false;
	private bool isFirstTile = true;
//	private bool treeColliderStatus = false;
	private int JumpSate = 0;
	private bool jumpOnce = false;
	private bool fallDownStopActions = false;
	private bool coinStatus = false;
	private bool playerStatusDied = false;
	private bool crossJump;
	private bool jump = true;
//	public GameObject restart;
//	public GameObject Hanuman;
	private bool isDead;
	private PowerupProgress powerupProgress;
	public GameObject smoke;
	private int Mjump = 0;
	public static bool DISTANCEVARY = false;
	public GameObject singleCoinObj;
	Vector3 singleCoinObjPosition;
	public GameObject bananaObj;
	bool IsCoin=true;
	
	System.DateTime currentDate;
	System.DateTime oldDate;
	public GameObject WaitScene;
	// ----------------------
	// Controller Variable
	// ----------------------
	
	public	TouchController	ctrl;
	
	
	// ----------------------
	// Constants
	// ----------------------
	
	public const int STICK_WALK = 0;
	public const int ZONE_RELOAD = 0;
	public const int ZONE_PAUSE = 1;
//	private bool isStraight = true;
//	private bool isStraight2 = true;
	private bool fallDown = false;
	private bool TileStartFallDown = false;
	public GameObject ps;
	public GameObject adiManav_Maneat_ps,bat_bomb_effect;
	private int jumpingState = 0;
	
	//	public GameObject coin;
	public GameObject[] coins;
	private int coinMove = 0;
	private int rollstate = 0;
	private int rollForstate = 0;
	private int slidingstate = 0;
//	private bool isDown = false;
//	private bool slidStatus = false;
//	private bool backRollStatus = false;
//	private bool oneCallStatusWalk = false;
//	private bool oneCallStatusJump = false;
//	private int playerSateValue = 0;
//	private int playerTempSateValue = 0;
//	CharacterController characterController;
//	CapsuleCollider playerCollider;
	private string GameOver = "GAMEOVERXI";
	private string COINS = "COINSI";
	public Text Life;
	private int movePosition = 0;
	private int ii = 0;
	private int mushposition;
	private bool leaderboardCheck = false;
	public GameObject leaderBoard;
	private GameObject lb;
	private FallingTree treeFall;
	private Camera cameraFreeWalk;
	public float zoomSpeed = 35f;
	public float minZoomFOV = 10f;
	public Texture2D leaderboardTexture;
	public Texture2D coinTexture;
	public Texture2D lifeTexture;
	public Texture2D lankaTexture;
	public Texture2D healthTexture;
	public Texture2D healthBGTexture;
	public Texture2D healthFGTexture;
	public Texture2D energyTexture;
	public Texture2D energyBGTexture;
	public Texture2D energyFGTexture;
	public Texture2D distTexture;
	public Texture2D diamond;
	public Font customFont;
	public GameObject loading_;
	private GameObject loading_Two;
	public float loading_br = 0;
	public GameObject runningEnergy;
	GameObject runEne;
	public float max_health = 500f;
	public int TILESCOUNT=22;
	public float cur_health = 0f;
	public static bool UI_DESABLE = false;
	public bool istexture = false;
	GameObject warningObj;
	public GameObject warning;
	bool warningStatus;
	private int cointIndex = 0;
	TreasureBox treasureBox;
	private bool LoadGameStatus = false;
	public GameObject encouragementUI;
	private GameObject encouragmentUI;
//	private int diamondCount = 0;
	private  GameObject gameOverTile;
	private  GameObject gameOver;
	public GameObject loadingBar_Main;
	public GameObject loadingBar;
	
	private bool internetCheck = true;
	public GameObject homeSceneUI;
	GameObject homescene;
	public Texture2D homeBtn;
	public GameObject[] batman;


	private GameObject DiamondEnergy;
	public GameObject DiamondEnergyPrefb;
	public string DIAMOND="DIAMOND";
	
	private GameObject tempTextBox;
	public GameObject purchase_diamond;
	private Text btn_txt, desc_txt;
	private float high_mag = 0f;
	private Vector3 euler0;
	
	bool hangOnce;
	RaycastHit hangingRaycast;
	LayerMask layer ;
//	private bool IScartPrefab;


	private bool LEVELIIIZOOM=false;
	private bool LEVELIIIZOOMliftsprefab=false,movetowarsH = false;
	private List<GameObject> bee = new List<GameObject> ();

	private bool MoveFight=false;
	public Texture loadingTexture;

	
	//	public GameObject MoveUpCube;
	//	private GameObject MoveUpCube1;
	//	private bool MoveUpCubeTag = false;
	//	private bool MoveUpCubeTag1 = false;
	//	private bool Water = false;
	//	private Transform MoveUpPosition;
	
	
	
	public void ZoomIn ()
	{
		isZoomed = true;
	}
	
	public void ZoomOut ()
	{
		isZoomed = false;
	}
	
	
	
	
	/*
			 * All UI Presence..
			 */
	void OnGUI ()
	{
		
		if (internetCheck == false) {
			GUI.skin.label.normal.textColor = Color.red;
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			GUI.Label (new Rect (Screen.width / 3f, Screen.height / 1.4f, Screen.width / 2, Screen.height / 8), "No Internet Available");
		}
		
		int gameOver = PlayerPrefs.GetInt (GameOver);
		if (gameOver == 0) {
			Life.text = "3";
		}
		
		if (gameOver == 1) {
			Life.text = "2";
		}
		
		if (gameOver == 2) {
			Life.text = "1";
		}
		int isGuiVisible = PlayerPrefs.GetInt ("isGui");
		if (isGuiVisible == 0) {
			
			
			float cur_health = PlayerPrefs.GetFloat ("RE");
			float health = PlayerPrefs.GetFloat ("HEALTH");
			GUI.skin.label.normal.textColor = Color.white;
			GUI.BeginGroup (new Rect (Screen.width / 50f, Screen.height / 120, Screen.width / 8, Screen.height / 8));
			GUI.DrawTexture (new Rect (0, 0, Screen.width / 8, Screen.height / 8), coinTexture, ScaleMode.ScaleToFit, true, 0f);
			GUI.skin.label.fontSize = 20;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			coinText.text=PlayerPrefs.GetInt(COINS)+"";	
			GUI.Label (new Rect (coinTexture.width / 8, 0, Screen.width / 8, Screen.height / 8), coinText.text);
			GUI.EndGroup ();
			
			GUI.BeginGroup (new Rect (Screen.width / 6f, Screen.height / 25f, Screen.width / 15, Screen.height / 15));
			GUI.DrawTexture (new Rect (0, 0, Screen.width / 15, Screen.height / 15), lifeTexture, ScaleMode.ScaleToFit, true, 0f);
			GUI.skin.label.fontSize = 20;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			GUI.Label (new Rect (0, 0, Screen.width / 15, Screen.height / 15), Life.text);//lifeTexture.width/6,lifeTexture.height/6
			GUI.EndGroup ();
			GUI.BeginGroup (new Rect (Screen.width / 4f, Screen.height / 120, Screen.width / 8, Screen.height / 8));
			GUI.DrawTexture (new Rect (0, 0, Screen.width / 8, Screen.height / 8), lankaTexture, ScaleMode.ScaleToFit, true, 0f);
			GUI.skin.label.fontSize = 20;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			GUI.Label (new Rect (lankaTexture.width / 8, 0, Screen.width / 8, Screen.height / 8), LankText.text);
			GUI.EndGroup ();
			GUI.BeginGroup (new Rect (Screen.width / 2.5f, Screen.height / 80f, Screen.width / 6, Screen.height / 6));
			GUI.DrawTexture (new Rect (0, 0, Screen.width / 6, Screen.height / 6), distTexture, ScaleMode.ScaleToFit, true, 0f);
			GUI.skin.label.fontSize = 35;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			GUI.Label (new Rect (0, distTexture.height / 3.5f, Screen.width / 6, Screen.height / 6), DistanceText.text);
			GUI.EndGroup ();
			
			GUI.BeginGroup (new Rect (Screen.width / 1.75f, Screen.height / 30f, Screen.width / 10, Screen.height / 10));
			GUI.DrawTexture (new Rect (0, 0, Screen.width / 15, Screen.height / 15), diamond, ScaleMode.ScaleToFit, true, 0f);
			GUI.skin.label.fontSize = 20;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.font = customFont;
			
			//				coinText.text=;	
			GUI.Label (new Rect (diamond.width / 4, diamond.height / 4, Screen.width / 12, Screen.height / 15), PlayerPrefs.GetInt(DIAMOND) + "");//lifeTexture.width/6,lifeTexture.height/6
			GUI.EndGroup ();
			
			GUI.DrawTexture (new Rect (Screen.width / 1.56f, Screen.height / 30f, Screen.width / 15f, Screen.height / 15f), healthTexture, ScaleMode.ScaleToFit, true, 0f);
			GUI.BeginGroup (new Rect (Screen.width / 1.42f, Screen.height / 18f, healthBGTexture.width / 5, healthBGTexture.height));
			GUI.DrawTexture (new Rect (0, 0, healthBGTexture.width / 5, healthBGTexture.height), healthBGTexture, ScaleMode.StretchToFill, true, 0f);
			GUI.DrawTexture (new Rect (0, 0, healthBGTexture.width / 5 * (health / 500), healthBGTexture.height), healthFGTexture, ScaleMode.StretchToFill, true, 0f);
			GUI.EndGroup ();
			GUI.DrawTexture (new Rect (Screen.width / 1.22f, Screen.height / 30f, Screen.width / 15f, Screen.height / 15f), energyTexture, ScaleMode.ScaleToFit, true, 0f);
			GUI.BeginGroup (new Rect (Screen.width / 1.14f, Screen.height / 19f, energyBGTexture.width / 5, energyBGTexture.height));
			GUI.DrawTexture (new Rect (0, 0, energyBGTexture.width / 5, energyBGTexture.height), energyBGTexture, ScaleMode.StretchToFill, true, 0f);
			GUI.DrawTexture (new Rect (0, 0, energyBGTexture.width / 5 * (cur_health / 500), energyBGTexture.height), energyFGTexture, ScaleMode.StretchToFill, true, 0f);
			GUI.EndGroup ();
			
			GUI.skin.button = GUIStyle.none;
			//				if (GUI.Button (new Rect (Screen.width / 1.25f, Screen.height / 7, Screen.width / 5, Screen.height / 12), leaderboardTexture)) {
			//					leaderboardCheck = true;//!leaderboardCheck;
			//					StartCoroutine (lbTimer ());
			//				}
			
			if (GUI.Button(new Rect(Screen.width/50f, Screen.height/8,Screen.width/5,Screen.height/12), homeBtn))
			{
				PlayerPrefs.SetInt ("isGui", 1);
				PlayerPrefs.SetInt ("UI_DESABLE",2);
				homescene = (GameObject)Instantiate (homeSceneUI, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			}
			if (PlayerPrefs.GetInt ("homeSceneUI") == 2) {
				PlayerPrefs.SetInt ("homeSceneUI", 0);
				PlayerPrefs.SetInt ("isGui", 1);
				PlayerPrefs.SetInt ("UI_DESABLE",2);
				GameObject homescene = (GameObject)Instantiate (homeSceneUI, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			}
			
			
			if(TileManager.Instance.gapCount == TILESCOUNT )
				GUI.Label (new Rect (0, 0, Screen.width / 1.2f, Screen.height / 11f), ".");
			
			
			if (istexture) {
				
				GUI.BeginGroup (new Rect (Screen.width / 7f, Screen.height / 1.18f, Screen.width / 1.15f, Screen.height / 2));
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 1.2f, Screen.height / 11), healthBGTexture);
				GUI.DrawTexture (new Rect (0, 0, Screen.width / 1.2f * (loading_br / 800), Screen.height / 11), healthFGTexture);
				
				GUI.skin.label.normal.textColor = Color.white;
				GUI.skin.label.fontSize = 30;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				GUI.skin.label.font = customFont;
				GUI.Label (new Rect (0, 0, Screen.width / 1.2f, Screen.height / 11f), "LOADING");
				GUI.EndGroup ();
				
			}


			if(MoveFight){
				GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), loadingTexture, ScaleMode.StretchToFill);
				GUI.BeginGroup (new Rect (Screen.width / 2f-Screen.width/1.2f/2, Screen.height / 1.1f, Screen.width/1.15f, Screen.height / 2));
				GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f, Screen.height / 11), healthBGTexture);
				GUI.DrawTexture (new Rect (0, 0, Screen.width/1.2f*(health/0.9f),Screen.height / 11),healthFGTexture);
				GUI.skin.label.normal.textColor = Color.white;
				GUI.skin.label.fontSize = 30;
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				GUI.skin.label.font = customFont;
				GUI.Label (new Rect(0,0,Screen.width/1.2f,Screen.height / 11), "Please Wait..");
				GUI.EndGroup();
				
			}
		}
	}
	/*
		 * Leaderbord Display..
		 */
	IEnumerator lbTimer(){
		yield return new WaitForSeconds (1f);
		int error = PlayerPrefs.GetInt("disconnectError");
		if (lb == null && leaderboardCheck) {
			if(error==1){
				internetCheck = false;
				StartCoroutine(internetTimer());
			}else{
				lb = (GameObject)Instantiate (leaderBoard, new Vector3 (0f, 0f, 0f), Quaternion.identity);
				UI_DESABLE=false;
		//		PlayerPrefs.SetInt ("UI_DESABLE",1);
				PlayerPrefs.SetInt("isGui",1);
				internetCheck = true;
			}
			
		}
	}
	IEnumerator internetTimer(){
		yield return new WaitForSeconds (5f);
		internetCheck = true;
	}
	
	/*
			 * Health Based Increments & Decrements..
			 */
	void IncreamentHealth ()
	{
		cur_health = PlayerPrefs.GetFloat ("RE");
		cur_health += 1;
		float calc_health = cur_health / max_health;
		if (cur_health <= 0) {
			cur_health = 0;
		}
		TileScript.RUNENERGY = false;
	}
	
	void decreaseHealth ()
	{
		cur_health = PlayerPrefs.GetFloat ("RE");
		cur_health -= 0.1f;
		//cur_health -= 1f;
		float calc_health = cur_health / max_health;
		PlayerPrefs.SetFloat ("RE", cur_health);
		cur_health = PlayerPrefs.GetFloat ("RE");
		if (cur_health <= 50 && cur_health > 0) {
			cur_health = 0;
			if (runEne == null)
				runEne = (GameObject)Instantiate (runningEnergy, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			//			PlayerPrefs.SetInt ("isGui", 1);
			//			UI_DESABLE = false;
			//			PlayerPrefs.SetInt ("UI_DESABLE", 1);
			WaitAgain wg = new WaitAgain ();
			wg.OnPauseGame ();
			try{
				disableShieldFast ();
			}catch{
				
			}
		}
		TileScript.RUNENERGY = false;
	}
	
	/*
			 * Rotatating Camera...
			 */
	IEnumerator movePlayer ()
	{
		yield return new WaitForSeconds (0f);
		PlayerPrefs.SetInt ("RotateCameraStatus", 1);
		//		Camera.main.GetComponent<CameraController> ().rotateCamera = false;
		//		Camera.main.GetComponent<CameraController> ().currentCamPos = true;
	}
	
	IEnumerator StopFallDownBridgeSound ()
	{
		yield return new WaitForSeconds (0.5f);
		if (StoneBridgeFallAudoSource.isPlaying)
			StoneBridgeFallAudoSource.Stop ();
	}
	
	IEnumerator Adiman_Sound (AudioSource a,AudioClip c)
	{
		yield return new WaitForSeconds (0.1f);
		try{
		a.clip = c;
		a.Play ();
		}catch{

		}
	}
	
	IEnumerator PlayCoinSound (AudioSource a)
	{
		yield return new WaitForSeconds (0.1f);
		try{
		a.Play ();
		}catch{

		       }
	}
	
	IEnumerator PlaypowerUpSound (AudioSource a)
	{
		yield return new WaitForSeconds (0.1f);
		try{
		a.Play ();
		}catch{
		}
	}
	
	IEnumerator PlaypowerUpSound_STOP (AudioSource a)
	{
		yield return new WaitForSeconds (0.1f);
		try{
		a.Stop ();
		}catch{

		}
	}
	
	//	void Awake() {
	//		DontDestroyOnLoad(transform.gameObject);
	//	}
	
	
	IEnumerator LoadAudioFiles(){
		
		yield return new WaitForSeconds (0.5f);
		AudioSourceControl = (AudioSource)gameObject.AddComponent<AudioSource> ();
		CollectAudioClip = (AudioClip)Resources.Load ("SingleSounds/b1_eat");
		AudioSourceControl.clip = CollectAudioClip;
		BoxTouchAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		BoxTouchClip = (AudioClip)Resources.Load ("SingleSounds/rollthree");
		JetPackAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		JetPackClip = (AudioClip)Resources.Load ("SingleSounds/Jetpack");
		JetPackAudoSource.clip = JetPackClip;
		JetPackAudoSource.volume = 0.9f;
		JetPackAudoSource.pitch = 0.7f;
		StoneBridgeFallAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		StoneBridgeFallClip = (AudioClip)Resources.Load ("SingleSounds/Crumbling Stone Bridge");
		StoneBridgeFallAudoSource.clip = StoneBridgeFallClip;
		FallingFaltFormAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		FallingFaltFormClip = (AudioClip)Resources.Load ("SingleSounds/Hanuman Falls Off Platform");
		FallingFaltFormAudoSource.clip = FallingFaltFormClip;
		ForceFieldAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		ForceFieldClip = (AudioClip)Resources.Load ("SingleSounds/Forcefield");
		ForceFieldAudoSource.clip = ForceFieldClip;
		ForceFieldAudoSource.loop = true;
		ForceFieldAudoSource.volume = 0.6f;
		ForceFieldAudoSource.pitch = 0.5f;
		TopHeadTouchAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		HealthReductionClip = (AudioClip)Resources.Load ("SingleSounds/Health Reduction");
		SoldierTopTouchClip = (AudioClip)Resources.Load ("SingleSounds/Killing Adi Manav and Man Eating Plant");
		PlantTopTouchClip = (AudioClip)Resources.Load ("SingleSounds/rollthree");
		SpringTopTouchClip = (AudioClip)Resources.Load ("SingleSounds/All Springs");
		FallingTreeClip = (AudioClip)Resources.Load ("SingleSounds/Falling Tree");
		HealthReductionClip = (AudioClip)Resources.Load ("SingleSounds/Health Reduction");
		SkeletonAppearanceAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		FirstSkeletonAppearanceClip = (AudioClip)Resources.Load ("SingleSounds/Skeleton Appearance");
		SkeletonAppearanceAudoSource.clip = FirstSkeletonAppearanceClip;
		PowerUpAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		PowerUpClip = (AudioClip)Resources.Load ("SingleSounds/Powerup Collection Sound");
		PowerUpAudoSource.clip = PowerUpClip;
		PlatformAudoSource = (AudioSource)gameObject.AddComponent<AudioSource> ();
		WaterFallAudoClip = (AudioClip)Resources.Load ("PlatFormSounds/Waterfall");
		XAxisPlatformAudoClip = (AudioClip)Resources.Load ("PlatFormSounds/X Axis Moving Platform");
		RotatePlatformAudoClip = (AudioClip)Resources.Load ("PlatFormSounds/Rotating Platforms");
		Puzzle1Clip = (AudioClip)Resources.Load ("PlatFormSounds/Puzzle 1");
		Puzzle2Clip = (AudioClip)Resources.Load ("PlatFormSounds/Puzzle 2");
		Puzzle3Clip = (AudioClip)Resources.Load ("PlatFormSounds/Puzzle 3");
		Puzzle4Clip = (AudioClip)Resources.Load ("PlatFormSounds/Puzzle 4");
		PlatformAudoSource.loop = true;
		
	}
	
	
	void homeScneUi(){
		
		if (PlayerPrefs.GetInt ("homeSceneUI") == 0) {
			PlayerPrefs.SetInt ("isGui", 1);
			GameObject homescene = (GameObject)Instantiate (homeSceneUI, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		} else {
			PlayerPrefs.SetInt ("isGui", 0);
		}
	}
	
	
	
	/*
		 * Tiles Creation calling to Tilemanager & Audio files Integartion while starting...
		 */
	void Start ()
	{
		
//		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetInt ("FIGHTTAG", 3);

//		GameObject GO=GameObject.Find ("Main Camera");
//		Destroy(GO.GetComponent<CameraController>());


		// 5TILE = 1000M//

		TILESCOUNT = 11;
		PlayerPrefs.SetInt ("Video", 0);
		AudioListener.volume = 1;
		
		if (!PlayerPrefs.GetString ("sysString").Equals ("")) {
			//Store the current time when it starts
			currentDate = System.DateTime.Now;
			//Grab the old time from the player prefs as a long
			long temp = System.Convert.ToInt64 (PlayerPrefs.GetString ("sysString"));
			//Convert the old time from binary to a DataTime variable
			System.DateTime oldDate = System.DateTime.FromBinary (temp);
			//Use the Subtract method and store the result as a timespan variable
			System.TimeSpan difference = currentDate.Subtract (oldDate);
			if (CountDownTimer.waitTime > difference.TotalSeconds) {
				PlayerPrefs.SetInt ("isGui", 1);
				//					PlayerPrefs.SetInt ("WAITSCREN", 1);
				GameObject timer = (GameObject)Instantiate (WaitScene, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			} else {
				
				if (PlayerPrefs.GetInt ("isWaiting") == 1) {
					PlayerPrefs.SetInt ("isWaiting", 0);
					Time.timeScale = 1;
					PlayerPrefs.SetInt ("UI_DESABLE", 0);
					PlayerPrefs.SetInt ("isGui", 0);
					
					string waitScene = PlayerPrefs.GetString ("WaitScene");
					if (waitScene.Equals ("LifeOver")) {
						PlayerPrefs.SetFloat ("HEALTH", 500);
						PlayerPrefs.SetInt ("GAMEOVERXI", 2);
					} else if (waitScene.Equals ("RunEnergy")) {
						PlayerPrefs.SetFloat ("RE", 500);
						PlayerPrefs.SetInt ("walkStickStatus", 0);
					}
				}
				
				homeScneUi ();
			}
		} else {
			homeScneUi ();
		}
		
		euler0 = transform.eulerAngles;
		
		//			PlayerPrefs.DeleteAll ();
		//			PlayerPrefs.SetInt (COINS, 0);
		
		//			PlayerPrefs.SetInt ("ISFIRST", 0);
		
		//			PlayerPrefs.SetInt ("FIGHTTAG", 0);
		//			PlayerPrefs.SetInt ("FIGHTTAGBOOL", 0);
		
		
		//			if (PlayerPrefs.GetInt ("homeSceneUI") == 0) {
		//				PlayerPrefs.SetInt ("isGui", 1);
		//				GameObject homescene = (GameObject)Instantiate (homeSceneUI, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		//			} else {
		//				PlayerPrefs.SetInt("isGui",0);
		//			}
		
		//First Loop
		//			PlayerPrefs.SetInt ("isFirstTimeKillAdimanav", 0);
		//			PlayerPrefs.SetInt ("Seetha01", 0);
		
		
		
		Vungle.init ("", "56729342cd9418774900002c", "");
		
		
		PlayerPrefs.SetFloat ("RE", max_health);
		PlayerPrefs.SetInt ("Swith", 0);
		//			PlayerPrefs.SetInt ("isGui", 0);
		
		layer = 13 << LayerMask.NameToLayer ("HangLayer");
		
		
		if (PlayerPrefs.GetInt ("ISFIRST") == 0) {
			PlayerPrefs.DeleteAll ();
			PlayerPrefs.SetInt ("ISFIRST", 1);
			PlayerPrefs.SetFloat ("HEALTH", 500);
			PlayerPrefs.SetFloat ("RE", 500);
			PlayerPrefs.SetInt (DIAMOND, 100);
//							PlayerPrefs.SetString("LEVEL","LEVELI");

//							PlayerPrefs.SetString("LEVEL","LEVELII");
			PlayerPrefs.SetString("LEVEL","LEVELIII");
			//				PlayerPrefs.SetString("LEVEL","LEVELIV");
			//				PlayerPrefs.SetString("LEVEL","LEVELV");
		}
		
		
		count = (PlayerPrefs.GetInt (COINS));
		
		//		string level = PlayerPrefs.GetString ("LEVEL");
		//		if (!level.Equals ("LEVELII")) {
		
		StartCoroutine (LoadAudioFiles());
		
		
		//	}
		
		
		PlayerPrefs.SetFloat ("loading_br", 0);
		istexture = true;
		PlayerPrefs.SetInt ("UI_DESABLE", 0);
		PlayerPrefs.SetInt ("walkStickStatus", 0);
		UI_DESABLE = false;
		cur_health = max_health;
		cur_health = PlayerPrefs.GetFloat ("RE");
		decreaseHealth ();
		diffInDistance = 0;
		PlayerPrefs.SetInt ("BACKRESTRICKT", 0);
		Time.timeScale = 1;
		PlayerPrefs.SetInt ("RotateCameraStatus", 0);
		PlayerPrefs.SetInt ("UI_DESABLE", 0);
		iSPowerUp = false;
		powerupProgress = GetComponent<PowerupProgress> ();
		cameraFreeWalk = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		Lifes ();
		camshake = GetComponent <cameraShake> ();
		LIFE_INDEX = 0;
		mushposition = 0;
//		restartInt = 0;
		PlayerPrefs.SetInt (backRestrict, 0);
		m_Character_User_Ctrl = GetComponent<ThirdPersonUserControl> ();
		m_Character = GetComponent<ThirdPersonCharacter> ();
		coinTossValue = 0;
		DISTANCEVARY = false;
		coinText.text = "" + count;
		int gameOver = PlayerPrefs.GetInt (GameOver);
		if (gameOver == 0) {
			Life.text = "3";
		}
		if (gameOver == 1) {
			Life.text = "2";
		}
		if (gameOver == 2) {
			Life.text = "1";
		}
		movePosition = 0;
		ii = 0;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		isDead = false;
		for (int i=0; i<3; i++) {
			coins [i].SetActive (false);
		}
		playerRigidbody = GetComponent <Rigidbody> ();
		anim = GetComponent <Animator> ();
		SetCountText ();
//		playerSateValue = 0;
//		playerTempSateValue = 0;
//		characterController = GetComponent<CharacterController> ();
//		playerCollider = GetComponent <CapsuleCollider> ();
		int UARMR = PlayerPrefs.GetInt ("UARMR");
		if (UARMR == 1) {
			Transform playerObj = playerRigidbody.gameObject.transform.GetChild (2);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (true);
			playerRigidbody.gameObject.transform.GetChild (7).gameObject.SetActive (true);
			playerRigidbody.gameObject.transform.GetChild (8).gameObject.SetActive (true);
		} else {
			Transform playerObj = playerRigidbody.gameObject.transform.GetChild (2);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (false);
			playerRigidbody.gameObject.transform.GetChild (7).gameObject.SetActive (false);
			playerRigidbody.gameObject.transform.GetChild (8).gameObject.SetActive (false);
		}
		int FIGHTTAG = PlayerPrefs.GetInt ("FIGHTTAG");
		if (FIGHTTAG != 0) {
			playerRigidbody.MovePosition (new Vector3 (5f, 0f, 0f));
			movePosition = movePosition + 1;
		}
		enemyDistance = PlayerPrefs.GetFloat ("enemyDistance");
		Lankacount = playerRigidbody.transform.position.magnitude - diffInDistance + enemyDistance;
		PlayerPrefs.SetString ("LEVELTILESCREATED", "");
		
		
		
		
		//	Load Tiles ....
		
		StartCoroutine (Load_From_Start());
		//		TrainingRoom_async = Application.LoadLevelAsync("TrainingRoom");
		//		TrainingRoom_async.allowSceneActivation = false;
	}
	public AsyncOperation TrainingRoom_async;
	
	IEnumerator  Load_From_Start(){
		yield return new WaitForSeconds (0.2f);
		PlayerPrefs.SetString("LEVELTILESCREATED","YES");
		PlayerPrefs.SetInt("isGui",0);
		PlayerPrefs.SetInt ("UI_DESABLE",0);


		if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI")) {
		TileManager.Instance.level1Prefabs ();
		}
		else if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELII")) {
			TileManager.Instance.level2Prefabs ();
		}else if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELIII")) {
			TileManager.Instance.level3Prefabs ();
		}
		
		isLevelCreated = true;
		PlayerPrefs.SetInt ("UI_DESABLE", 2);
		int Fightabc2 = PlayerPrefs.GetInt ("FIGHTTAGBOOL");
		if (Fightabc2 == 100) {
			for (int i=0; i< 2; i++) {
				TileManager.Instance.SpawnTile ();
			}
		} else {
			
			StartCoroutine (LoadMore (0, 0.2f));
			
			
			//			for (int i=0; i< 1; i++) {
			
			//			}
			
		}
		PlayerPrefs.SetInt("isGui",0);
		PlayerPrefs.SetInt ("UI_DESABLE",0);
		//		TileManager.Instance.level2Prefabs ();
		StartCoroutine (playerkinematic());
		
	}
	
	
//	void oneCall ()
//	{
//		oneCallStatusWalk = false;
//	}
	/*
			 * Loading bar displacement while creating TILES..
			 */
	void FixedUpdate ()
	{
		loading_br = PlayerPrefs.GetFloat ("loading_br");
		if (loading_br >= 0 && loading_br < 800) {

			loading_br = loading_br + 1;
			PlayerPrefs.SetFloat ("loading_br", loading_br);
			if (loading_br == 800) {
				istexture = false;
				
				//				if(PlayerPrefs.GetInt ("homeSceneUI") == 1)
				if (homescene == null)
					PlayerPrefs.SetInt ("UI_DESABLE", 0);
				//				PlayerPrefs.SetInt ("UI_DESABLE", 0);
				
			}
		}
		
		
	}
	
	void destroyWarning ()
	{
		if (warningObj != null)
			Destroy (warningObj);
		warningStatus = false;
	}
	IEnumerator  playerkinematic(){
		yield return new WaitForSeconds (5f);
		playerRigidbody.isKinematic = false;
		playerRigidbody.transform.position = new Vector3 (0.0f,5.0f,-0.2f);
		
	}
	
	
	void ReduceHealth(){
		
		PlayerPrefs.SetString("HEALTHREDUCE","");
		this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 3, this.playerRigidbody.transform.position.y-10, this.playerRigidbody.transform.position.z);
		GameObject DestroyEffect = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
		StartCoroutine (destroyPS (DestroyEffect));
		GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlus, new Vector3 (this.playerRigidbody.position.x - 3f, this.playerRigidbody.position.y-2f, this.playerRigidbody.position.z), Quaternion.identity);
		HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
		StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
		PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
		Lifes ();
		//		TopHeadTouchAudoSource.clip = HealthReductionClip;
		//		TopHeadTouchAudoSource.Play ();
		StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
	}
	
	public bool isLevelCreated=false;
	private bool ISPlatThere=false;
	/*
			 * All Hanuman Actions...
			 */
	void Update ()
	{
		//		System.GC.Collect();
		if (Time.frameCount % 30 == 0)
		{
			//			Debug.Log("## GC");
			System.GC.Collect();
		}
		//		PlayerPrefs.SetInt ("DIAMOND",100);


		if (PlayerPrefs.GetInt ("Video") == 1) {
			
			try {
				Destroy (lifeover);
				PlayerPrefs.SetInt ("Video", 0);
			} catch {
			}
		}

		
		if (PlayerPrefs.GetString ("HEALTHREDUCE").Equals ("TRUE")) {
			
			ReduceHealth();
		}
		
		
		if(PlayerPrefs.GetInt ("leaderBoardUI")==1)
		{
			leaderboardCheck = true;//!leaderboardCheck;
			StartCoroutine(lbTimer());
			PlayerPrefs.SetInt ("leaderBoardUI",0);
		}
		//			int DiamondsDisplay=PlayerPrefs.GetInt ("DiamondsDisplay");
		//			if (DiamondsDisplay == 100) {
		//				if (DiamondEnergy == null){
		//					if(!PlayerPrefs.GetString("FROMHOME").Equals("true"))
		//					{
		//						DiamondEnergy = (GameObject)Instantiate (purchase_diamond, new Vector3 (Screen.width / 2f, Screen.height / 2f, 0), Quaternion.identity);
		//						btn_txt = DiamondEnergy.transform.GetChild(0).GetChild(1).GetComponentInChildren<Text>();
		//						desc_txt = DiamondEnergy.transform.GetChild(0).GetChild(2).GetComponent<Text>();
		//						if(PlayerPrefs.GetInt("DIAMOND") < 2){
		//							desc_txt.text = "YOU DON'T HAVE ENOUGH \n DIAMONDS";
		//							btn_txt.text = "STORE";
		//							PlayerPrefs.SetString("OKORSTORE","STORE");
		//							PlayerPrefs.SetString("ISFROM-DIALESS-DIALOG","TRUE");
		//						}
		//						else{
		//							//sucess
		//							if(PlayerPrefs.GetString("ISFOR-RE").Equals("TRUE")){
		//								PlayerPrefs.SetFloat ("RE",500);
		//								PlayerPrefs.SetInt("DIAMOND",PlayerPrefs.GetInt("DIAMOND") - 2);
		//							}
		//							else{
		//								PlayerPrefs.SetInt("UI_DESABLE",0);
		//								Time.timeScale =1;
		//								PlayerPrefs.SetInt("isGui",0);
		//								PlayerPrefs.SetFloat("HEALTH",500);PlayerPrefs.SetFloat ("RE",500);
		//								PlayerPrefs.SetInt (GameOver, 2);
		//								PlayerPrefs.SetInt("DIAMOND",PlayerPrefs.GetInt("DIAMOND") - 2);
		//							}
		//							PlayerPrefs.SetString("OKORSTORE","OK");
		//							PlayerPrefs.SetString("ISFROM-DIALESS-DIALOG","TRUE");
		//							desc_txt.text = "YOUR TRANSACTION IS \n SUCCESSFULL";
		//							btn_txt.text = "OK";
		//							Button but = DiamondEnergy.transform.GetChild(0).GetChild(3).GetComponentInChildren<Button>();
		//							but.gameObject.SetActive(false);
		//						}
		//					}else{
		//						StoreUI();
		//					}
		//					PlayerPrefs.SetInt ("DiamondsDisplay",0);
		//				}
		//			}
		//			SetCountText ();
		//			int COINSDISPLAYCHECK=PlayerPrefs.GetInt ("COINSDISPLAYCHECK");
		//			if (DiamondsDisplay == 100) {
		//				count=PlayerPrefs.GetInt(COINS);
		//				SetCountText();
		//				PlayerPrefs.SetInt ("COINSDISPLAYCHECK",0);
		//
		//			}
		
		//		if (MoveUpCubeTag) {
		//			
		//			if(CFInput.GetAxis("Vertical") == 0 || CFInput.GetAxis("Horizontal") == 0){
		//
		//				try{
		//					MoveUpCube1.transform.position = Vector3.Lerp (MoveUpCube1.transform.position,new Vector3(MoveUpPosition.position.x,MoveUpPosition.position.y+2,MoveUpPosition.position.z), 0.2f * Time.deltaTime);
		//					transform.position = MoveUpCube1.transform.position;
		//				}
		//				catch{
		//				}	
		//			}
		//		}
		
		if (swimpos == 1) {
			if (m_Character.toggleTag == true) {
				transform.position = Vector3.Lerp (transform.position, new Vector3 (this.playerRigidbody.position.x + 4f, this.playerRigidbody.position.y , 0), 2f * Time.deltaTime);
			} else {
				int walkStickStatus = PlayerPrefs.GetInt ("walkStickStatus2");
				if (walkStickStatus == 0)
					transform.position = Vector3.Lerp (transform.position, new Vector3 (this.playerRigidbody.position.x + 4f, this.playerRigidbody.position.y, 0), 2f * Time.deltaTime);
				else
					transform.position = Vector3.Lerp (transform.position, new Vector3 (this.playerRigidbody.position.x - 4f, this.playerRigidbody.position.y, 0), 2f * Time.deltaTime);
			}
		} else if (swimpos == 2) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (this.playerRigidbody.position.x - 4f, this.playerRigidbody.position.y, 0), 2f * Time.deltaTime);
		} else if (swimpos == 3) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (this.playerRigidbody.position.x + 4f, this.playerRigidbody.position.y, 0), 2f * Time.deltaTime);
		}
		if (PlayerPrefs.GetInt ("walkStickStatus") == 1)
			Invoke ("decreaseHealth", 0f);
		int cur_health = (int)PlayerPrefs.GetFloat ("RE");
		if (cur_health <= 100 && !warningStatus) {
			warningStatus = true;
			if (warningObj == null)
				warningObj = (GameObject)Instantiate (warning, new Vector3 (playerRigidbody.position.x + 1, playerRigidbody.position.y + 4, playerRigidbody.position.z), Quaternion.identity);
		} else {
			if (warningObj != null) {
				warningObj.transform.position = new Vector3 (playerRigidbody.position.x + 1, playerRigidbody.position.y + 4, playerRigidbody.position.z);
			}
		}
		if (cur_health <= 50) {
			Invoke ("destroyWarning", 0f);
		}
		RaycastHit LHit;
		Debug.DrawRay (transform.position + transform.TransformDirection (new Vector3 (0f, 1.7f, 0f)), transform.TransformDirection (new Vector3 (0f, 0f, 0.3f)), Color.red);
		if (Physics.Raycast (transform.position + transform.TransformDirection (new Vector3 (3f, 2f, 2f)), transform.TransformDirection (new Vector3 (-3f, 0f, 0f)), out LHit, 10.0f)) {
			if (LHit.collider.gameObject.tag == "FTree") {
				//					Debug.DrawRay (transform.position + transform.TransformDirection (new Vector3 (3f, 2f, 2f)), transform.TransformDirection (new Vector3 (-3f, 0f, 0f)), Color.white);
				treeFall = (FallingTree)(LHit.collider.gameObject.transform.parent.parent.parent).GetComponent (typeof(FallingTree));
				treeFall.IsTreeFalling (true);
				//				TopHeadTouchAudoSource.clip = FallingTreeClip;
				//				TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,FallingTreeClip));
			}
		}
		else if(Physics.Raycast(transform.position + transform.TransformDirection (new Vector3 (0f, 1.7f, 0f)), transform.TransformDirection (new Vector3 (0f, 0f, 0.3f)), out hangingRaycast,1f,layer))
		{
			if(hangingRaycast.collider.gameObject.layer==13){
				if(!hangOnce){
					Debug.Log("HangLayer mesh touched");
					anim.SetTrigger ("Hang");
					StartCoroutine (moveUp());
					hangOnce = true;
				}
			}
		}
		
		
		if (isZoomed == true) {
			//			Debug.Log("isZoomed");
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 60, Time.deltaTime * 1f);
		} else if(ISPlatThere == true){
			//			Debug.Log("Plat IS there");
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 100, Time.deltaTime * 2f);
		}
		//		else if (isBridgeLevelIIZoom == true) {
		//			Debug.Log("isBridgeLevelIIZoom");
		//
		//			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 30, Time.deltaTime * 1f);
		//		}
		else if(LEVELIIIZOOM == true){
			//			Debug.Log("Plat IS there");
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 80, Time.deltaTime * 3f);
		}
		else if(LEVELIIIZOOMliftsprefab == true){
			//			Debug.Log("Plat IS there");
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 115, Time.deltaTime * 3f);
		}
		else if (isBridgeLevelIIZoomForLandSevn == true || isBridgeLevelIIZoom == true) {
			//			Debug.Log("LOGIC ZOOMIN");
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 70, Time.deltaTime * 2f);
		} else if (isJetPackZoomed == true) {
			//			Debug.Log("isJetPackZoomed");
			
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 140f, Time.deltaTime * 1f);
		} else if (isPlatformZoom == true) {
			//			Debug.Log("isPlatformZoom");
			
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 150, Time.deltaTime * 1f);
		} else {
			//			Debug.Log("FINAL");
			
			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 36, Time.deltaTime * 1f);
		}
		float hvale = PlayerPrefs.GetFloat ("MUSHROOMDIRECTION");
		if (hvale > 0.0f) {
			mushposition = 1;
		}
		if (hvale < 0.0f) {
			mushposition = 2;
		}
//		if (playerSateValue != playerTempSateValue)
//			oneCallStatusJump = false;
			if (PlayerPrefs.GetInt ("FIGHTTAGBOOL") == 100)
			DISTANCEVARY = true;
		else
			DISTANCEVARY = false;
//		Debug.Log ("DISTANCEVARY : "+DISTANCEVARY);
		if (!DISTANCEVARY) {
			float cout = PlayerPrefs.GetFloat ("AIMIII");
			if (cout == 0) {
				enemyDistance = PlayerPrefs.GetFloat ("enemyDistance");
				Lankacount = playerRigidbody.transform.position.magnitude - diffInDistance + enemyDistance;
				//				PlayerPrefs.SetString("LEVEL","LEVELII");
				string level = PlayerPrefs.GetString ("LEVEL");
				if (level.Equals ("LEVELI")) {
					Lankacount = 4f * Lankacount;
				} else if (level.Equals ("LEVELII") || level.Equals ("LEVELIII")) {
					Lankacount = 2f * Lankacount;
				}
			} else {
				enemyDistance = PlayerPrefs.GetFloat ("enemyDistance");
				Lankacount = playerRigidbody.transform.position.magnitude - diffInDistance + enemyDistance;
				string level = PlayerPrefs.GetString ("LEVEL");
				if (level.Equals ("LEVELI")) {
					Lankacount = 4f * Lankacount;
				} else if (level.Equals ("LEVELII")|| level.Equals ("LEVELIII")) {
					Lankacount = 2f * Lankacount;
				}
				//				Lankacount = 4f * Lankacount;
			}
			if (Lankacount < 0)
				Lankacount = 0;

			LankText.text = "" + (100000 - ((int)Lankacount - 5)).ToString ();
			PlayerPrefs.SetFloat("TOLANKA",(100000 - ((int)Lankacount - 5)));
			if (Lankacount >= high_mag && this.transform.right.z <= 0) {
				high_mag = Lankacount;
				DistanceText.text = "" + ((int)Lankacount).ToString ();
				PlayerPrefs.SetFloat ("SCRORE", Lankacount);
			}
		} else {
			PlayerPrefs.SetFloat("AIMIII",PlayerPrefs.GetFloat ("SCRORE"));
			Lankacount=PlayerPrefs.GetFloat("AIMIII");
//			Debug.Log("Lankacount "+Lankacount);

			LankText.text = ""+(int)PlayerPrefs.GetFloat ("TOLANKA");
			DistanceText.text = "" + (int)PlayerPrefs.GetFloat ("SCRORE");
		}
		if (coinMove == 1) {
			for (int i=0; i<3; i++) {
				Vector3 newposition = coins [i].transform.position;
				newposition.y = newposition.y + 0.1f;
				newposition.x = newposition.x - 0.2f;
				coins [i].transform.position = newposition;
			}
		}
		if (Mjump == 1) {
			Move (0f, 20f);
		}
		if (Mjump == 2) {
			Move (30f, -20f);
		}
		if (fallDown) {
			Move (0.1f, -2f);
		}
		if (TileStartFallDown) {
			Move (0f, -1f);
		}
		if (rollstate == 1) {
			playerRigidbody.AddForce (-35f, 0f, 0f);
		}
		if (rollForstate == 1) {
			Move (0.06f, 0f);
		}
		if (slidingstate == 1 && !fallDown) {
			Move (0.01f, 0f);
		}
		if (jumpingState == 1) {
			if (crossJump)
				Move (8f, 15f);
			else
				Move (0f, 15f);
		}
		if (jumpingState == 2) {
			if (crossJump) {
				Move (5f, -3f);
			} else {
				Move (0f, -3f);
			}
		}
		if (hangingState != 0)
		if (hangingState == 1) {
			//Move (0.001f, 0.0f);
			if (hangOnce = true) {
				Move (0.01f, 0.5f);
				StartCoroutine (positionAfterHang (hangingRaycast));
			}
			else
				Move (0.001f, 0.0f);
		}
		if (hangingState == 2)
			Move (0.1f, 0.7f);
		if (hangingState == 3)
			Move (0.000f, 0.000f);
		if (hangingState == 4)
			Move (1f, 0);
		if (hangingState == 5)
			Move (0f, 0);
	}
	
	
	IEnumerator moveUp()
	{
		yield return new WaitForSeconds (0f);
		hangingState = 1;
	}
	
	IEnumerator positionAfterHang (RaycastHit hangingRaycast)
	{
		yield return new WaitForSeconds (0.5f);
		hangingState = 0;
		hangOnce = false;
		try{
			//this.playerRigidbody.transform.position = hangingRaycast.collider.transform.parent.position;
			this.playerRigidbody.transform.position = hangingRaycast.collider.transform.position;
			this.playerRigidbody.isKinematic = true;
			StartCoroutine(changeKinematicFn());
		}
		catch
		{
			Debug.Log ("Hanging exception");
		}
	}
	IEnumerator changeKinematicFn()
	{
		yield return new WaitForSeconds (0.1f);
		this.playerRigidbody.isKinematic = false;
	}
	
	IEnumerator Ftree (RaycastHit LHit)
	{
		yield return new WaitForSeconds (0.8f);
		treeFall = (FallingTree)(LHit.collider.gameObject.transform.parent.parent.parent).GetComponent (typeof(FallingTree));
		treeFall.IsTreeFalling (true);
	}
	
	IEnumerator JumpUp ()
	{
		yield return new WaitForSeconds (.1f);
		this.playerRigidbody.velocity += new Vector3 (1f, 5f, 0f);
	}
	
	IEnumerator JumpDown ()
	{
		yield return new WaitForSeconds (0.3f);
		anim.SetBool ("IsJumpDown", true);
		anim.SetBool ("IsJump", false);
		this.playerRigidbody.velocity += new Vector3 (0f, -50f, 0f);
		StartCoroutine (JumpDownFalse ());
	}
	
	IEnumerator JumpDownFalse ()
	{
		yield return new WaitForSeconds (.5f);
		anim.SetBool ("IsJumpDown", false);
		yield return new WaitForSeconds (1f);
		jump = true;
	}
	
	IEnumerator kneelUp ()
	{
		yield return new WaitForSeconds (.1f);
		anim.SetBool ("IsKneeldown", false);
	}
	
	void StoreUI(){
		DiamondEnergy = (GameObject)Instantiate (DiamondEnergyPrefb, new Vector3 (Screen.width / 2f, Screen.height / 2f, 0), Quaternion.identity);
		PlayerPrefs.SetString ("ISFROM-DIALESS-DIALOG", "FALSE");
		PlayerPrefs.SetString("IS-TO-INIT-COINPREFAB","FALSE");
		PlayerPrefs.SetString ("FROMHOME","");
		PlayerPrefs.SetString ("ISFROMARMOUR",null);
		PlayerPrefs.SetString ("IS-TO-INIT-COINPREFAB",null);
	}
	
	void Move (float h, float v)
	{
		if (!isDead) {
			movement.Set (h, v, 0f);
			movement = movement.normalized * speed * Time.deltaTime;
			playerRigidbody.AddForce (100f * h, 100f * v, 0f);
		}
	}
	
	void SetCountText ()
	{
		coinText.text = "" + count;
		PlayerPrefs.SetInt (COINS, count);
	}
	
	IEnumerator destroyPS (GameObject gameObject)
	{
		yield return new WaitForSeconds (1f);
		ps.GetComponent<ParticleSystem> ().Stop ();
		GameObject.Destroy (gameObject);
	}
	
	IEnumerator destroyHealthPS (GameObject gameObject)
	{
		yield return new WaitForSeconds (2f);
		GameObject.Destroy (gameObject);
	}
	
	IEnumerator destroyGameObject (GameObject gameObject)
	{
		yield return new WaitForSeconds (0.3f);
		Destroy (gameObject);
	}
	
	IEnumerator disableJetPack (GameObject obj)
	{
		yield return new WaitForSeconds (20f);
		isJetPackZoomed = false;
		obj.SetActive (false);
		iSPowerUp = false;
		m_Character.JetPackStatus = false;
		m_Character.JetPackHeightStatus = false;
		Physics.gravity = new Vector3 (0, -9.8f, 0);
		playerRigidbody.useGravity = true;
		powerupProgress.stopProgressBar ();
		GameObject gameObj = GameObject.FindGameObjectWithTag ("JETPACK BOTTOM");
		GameObject gameObj1 = GameObject.FindGameObjectWithTag ("JETPACK TOP");
		Destroy (gameObj);
		Destroy (gameObj1);

		if (runEne == null)
			runEne = (GameObject)Instantiate (runningEnergy, new Vector3 (0f, 0f, 0f), Quaternion.identity);
		//			PlayerPrefs.SetInt ("isGui", 1);
		//			UI_DESABLE = false;
		//			PlayerPrefs.SetInt ("UI_DESABLE", 1);
		WaitAgain wg = new WaitAgain ();
		wg.OnPauseGame ();
		try{
			disableShieldFast ();
		}catch{
			
		}


	}
	IEnumerator HanumanFromJetPack ()
	{
		yield return new WaitForSeconds (0.2f);
//		Time.timeScale = 1.0f;
		PlayerPrefs.SetInt ("isGui", 0);
		PlayerPrefs.SetInt ("UI_DESABLE", 0);
		PlayerPrefs.SetInt ("walkStickStatus",1);
//		GameObject player = GameObject.FindGameObjectWithTag ("Player");
//		TouchController tcScript2 = player.GetComponent<TouchController> ();
//		tcScript2.enabled = true;
	}
	
	IEnumerator StoneFallDown (GameObject stone)
	{
		yield return new WaitForSeconds (0.2f);
		StoneFallDown StoneFallDown = stone.GetComponent<StoneFallDown> ();
		StoneFallDown.StoneFallingStatus = true;
		StoneFallDown.destroyStone = true;
	}
	
	IEnumerator closeTreasureBox ()
	{
		yield return new WaitForSeconds (2.0f);
		treasureBox.CloseTreasureBox ();
	}
	
	IEnumerator OpenTreasureBox ()
	{
		cointIndex = cointIndex + 1;
		if (singleCoinObj2)
			Destroy (singleCoinObj2);
		singleCoinObj2 = Instantiate (singleCoinObj1) as GameObject;
		float cc = Random.Range (-0.2f, 0.2f);
		singleCoinObj2.transform.position = new Vector3 (treasureBox.transform.position.x + cc, treasureBox.transform.position.y + 1, 0);
		yield return new WaitForSeconds (0.1f);
		if (cointIndex == 20) {
			StartCoroutine (closeTreasureBox ());
			cointIndex = 0;
			if (singleCoinObj2)
				Destroy (singleCoinObj2);
		} else {
			StartCoroutine (OpenTreasureBox ());
		}
	}
	
	//		IEnumerator destroyMoveUpCube ()
	//		{
	//			yield return new WaitForSeconds (12f);
	//			GameObject.Destroy (MoveUpCube1);
	//			MoveUpCubeTag = false;
	//		}
	IEnumerator placeKinamatic (){
		yield return new WaitForSeconds (0.4f);
		playerRigidbody.isKinematic=true;
	}
	IEnumerator RemoveKinamatic (){
		yield return new WaitForSeconds (15f);
		Debug.Log ("RemoveKinamatic");
		playerRigidbody.isKinematic=false;
	}
	IEnumerator removeKinamatic (){
		yield return new WaitForSeconds (0.2f);
		playerRigidbody.isKinematic=false;
	}
	
	void OnCollisionEnter (Collision collision)
	{
		

		if (collision.gameObject.name == "Cube_Doble") {

			try{
				if(collision.transform.root.GetChild(8).gameObject.name== "LevelIIIFMan2 (3)(Clone)")

			{
					collision.transform.root.GetChild(8).gameObject.transform.rotation= Quaternion.Euler (0, 90, 0);
			}
			}catch{
			}
			try{
				if(collision.transform.root.GetChild(8).gameObject.name== "Red_Mny_02_Prefab(Clone)")
				
			{
					collision.transform.root.GetChild(8).gameObject.transform.rotation= Quaternion.Euler (0, 90, 0);
			}
			}catch{
			}
			try{
				if(collision.transform.root.GetChild(8).gameObject.name== "bear_claw(Clone)")
				
			{
					collision.transform.root.GetChild(8).gameObject.transform.rotation= Quaternion.Euler (0, 90, 0);
			}
			}catch{
			}




		}
		if (collision.transform.tag == "CartCollider") {
			collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			StartCoroutine (placeKinamatic ());
			StartCoroutine (RemoveKinamatic ());
		} else if (collision.transform.name == "StopPower") {
			disableShieldFast ();
		} else if (collision.collider.gameObject.tag == "TreasureChest") {
			GameObject go = (GameObject)collision.collider.gameObject.transform.parent.gameObject;
			treasureBox = go.transform.FindChild ("TreasureChest").GetComponent<TreasureBox> ();
			if (!treasureBox.tboxState) {
				treasureBox.OpenTreasureBox ();
				StartCoroutine (OpenTreasureBox ());
				treasureBox.tboxState = true;
				count = count + 10;
				SetCountText ();
			}
		} else if (POWERTAG == "JetPack") {
			if (collision.gameObject.name.Equals ("GO")) {
				collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			}
			if (collision.gameObject.name.Equals ("GO(1)")) {
				collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			}
			if (collision.gameObject.name.Equals ("GO(2)")) {
				collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			}
			if (collision.gameObject.name.Equals ("GO(3)")) {
				collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			}
			if (collision.gameObject.name.Equals ("GO(4)")) {
				collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			}
			if (collision.gameObject.name.Equals ("HGO(1)")) {
				collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			}
		} 
		//		else {
		//				if (collision.gameObject.name.Equals ("GO")) {
		//					collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		//				}
		//				if (collision.gameObject.name.Equals ("GO(1)")) {
		//					collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		//				}
		//				if (collision.gameObject.name.Equals ("GO(2)")) {
		//					collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		//				}
		//				if (collision.gameObject.name.Equals ("GO(3)")) {
		//					collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		//				}
		//				if (collision.gameObject.name.Equals ("GO(4)")) {
		//					collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		//				}
		//				if (collision.gameObject.name.Equals ("HGO(1)")) {
		//					collision.transform.gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		//				}
		//			}
		
		else if (collision.gameObject.name.Equals ("XMovingPlatPrefabSmall(Clone)")) {
			PlatformAudoSource.clip = XAxisPlatformAudoClip;
			if (!PlatformAudoSource.isPlaying) {
				PlatformAudoSource.Stop ();
				PlatformAudoSource.Play ();
			}
		} else if (collision.gameObject.name.Equals ("Wodden_Bridge_Prefab(Clone)")) {
			PlatformAudoSource.clip = WaterFallAudoClip;
			if (!PlatformAudoSource.isPlaying) {
				PlatformAudoSource.Stop ();
				PlatformAudoSource.Play ();
			}
		} else if (collision.gameObject.name.Equals ("RotatePlatPrefab(Clone)")) {
			PlatformAudoSource.clip = RotatePlatformAudoClip;
			if (!PlatformAudoSource.isPlaying) {
				PlatformAudoSource.Stop ();
				PlatformAudoSource.Play ();
			}
		} else if (collision.gameObject.name.Equals ("-Z2_Prefab (1)(Clone)") ||
		           collision.gameObject.name.Equals ("-Z2_Prefab1(Clone)") ||
		           collision.gameObject.name.Equals ("2Plat_Prefab(Clone)") ||
		           collision.gameObject.name.Equals ("adimanv_New(Clone)") ||
		           collision.gameObject.name.Equals ("Combi1_Plat_Prefab(Clone)") ||
		           collision.gameObject.name.Equals ("Combi2_Plat_prefab(Clone)") ||
		           collision.gameObject.name.Equals ("Combi5_Prefab(Clone)") ||
		           collision.gameObject.name.Equals ("Curve_Bridge_plat_Prefab(Clone)") ||
		           collision.gameObject.name.Equals ("Curve_Bridge_plat_Prefab2(Clone)") ||
		           collision.gameObject.name.Equals ("enemy1(Clone)") ||
		           collision.gameObject.name.Equals ("Enemy4Prefab 1(Clone)") ||
		           collision.gameObject.name.Equals ("enemy5Prefab 1(Clone)") ||
		           collision.gameObject.name.Equals ("Enemy_SecondPrefab 1(Clone)") ||
		           collision.gameObject.name.Equals ("Enemy_ThirdPrefab 1(Clone)") ||
		           collision.gameObject.name.Equals ("Floater_Plat_Prefab(Clone)") ||
		           collision.gameObject.name.Equals ("Height1_Prefab(Clone)") ||
		           collision.gameObject.name.Equals ("L1_Prefab (1)(Clone)") ||
		           collision.gameObject.name.Equals ("Maneat_new(Clone)") ||
		           collision.gameObject.name.Equals ("Mush1_Prefab(Clone)") ||
		           collision.gameObject.name.Equals ("Single_A3_prefab(Clone)") ||
		           collision.gameObject.name.Equals ("SpringSeqPrefab(Clone)") ||
		           collision.gameObject.name.Equals ("Start(Clone)") ||
		           collision.gameObject.name.Equals ("Start (1)(Clone)") ||
		           collision.gameObject.name.Equals ("Stone_Bridge_plat_prefab2 1(Clone)") ||
		           collision.gameObject.name.Equals ("Water_Plat_Prefab 1(Clone)") ||
		           collision.gameObject.name.Equals ("Wodden_Bridge_Prefab1(Clone)")) {
			PlatformAudoSource.Stop ();
		} else if (collision.gameObject.name.Equals ("Combi3_plat_Prefab 1(Clone)")) { 
			PlatformAudoSource.clip = Puzzle1Clip;
			if (!PlatformAudoSource.isPlaying) {
				PlatformAudoSource.Stop ();
				PlatformAudoSource.Play ();
			}
		} else if (collision.gameObject.name.Equals ("Combi3_plat_Prefab 2(Clone)")) {
			PlatformAudoSource.clip = Puzzle2Clip;
			if (!PlatformAudoSource.isPlaying) {
				PlatformAudoSource.Stop ();
				PlatformAudoSource.Play ();
			}
		} else if (collision.gameObject.name.Equals ("Combi3_plat_Prefab 3(Clone)")) {
			PlatformAudoSource.clip = Puzzle3Clip;
			if (!PlatformAudoSource.isPlaying) {
				PlatformAudoSource.Stop ();
				PlatformAudoSource.Play ();
			}
		} else if (collision.gameObject.name.Equals ("Combi3_plat_Prefab 4(Clone)")) {
			PlatformAudoSource.clip = Puzzle4Clip;
			if (!PlatformAudoSource.isPlaying) {
				PlatformAudoSource.Stop ();
				PlatformAudoSource.Play ();
			}
		} 
		//		else if (collision.gameObject.name.Equals ("Branch1_prefab(Clone)") ||
		//			collision.gameObject.name.Equals ("Branch2_prefab(Clone)") ||
		//			collision.gameObject.name.Equals ("Branch3_prefab(Clone)") ||
		//			collision.gameObject.name.Equals ("Branch4_prefab(Clone)") ||
		//			collision.gameObject.name.Equals ("Branch5_prefab(Clone)") ||
		//			collision.gameObject.name.Equals ("Branch6_prefab(Clone)") ||
		//
		//			collision.gameObject.name.Equals ("Branch7_prefab(Clone)")) {
		////
		////			if (!m_Character.audioSource.isPlaying) {
		////				m_Character.audioSource.Play ();
		////			}
		////			m_Character.BGSoungTag = false;
		////
		////
		////			PlatformAudoSource.Stop ();
		//////			ISPlatThere=false;
		////			// Solving Camera ISsues...
		//////			transform.eulerAngles = euler0;
		//////			isBridgeLevelIIZoom=false;
		//////			Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x,10,Camera.main.transform.eulerAngles.z);
		//////			Camera.main.GetComponent<CameraController> ().rotateCamera = false;
		//////			IScartPrefab=false;
		//////
		//////			cameraFreeWalk.fieldOfView = Mathf.Lerp (cameraFreeWalk.fieldOfView, 36, Time.deltaTime * 1f);
		////
		////			
		//		}
		else if (collision.gameObject.name.Equals ("Admanv-L2-Prefab(Clone)")) {
			try{
				collision.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
			}catch{
				
			}
			ISPlatThere=false;
		}
		else if (collision.gameObject.name.Equals ("land1_rope_prefab(Clone)")) {
			
			try{
				//			collision.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
				collision.transform.GetChild(3).gameObject.SetActive(true);
				collision.transform.GetChild(4).gameObject.SetActive(true);
				collision.transform.GetChild(5).gameObject.SetActive(true);
			}catch{
				
			}
			
			//
			//
			//			if(m_Character.isSwimStarted)
			//				return;
			//
			//			m_Character.audioSource.Pause();
			//			m_Character.BGSoungTag = true;
			//
			//			PlatformAudoSource.clip = Puzzle15Clip;
			//			
			//			if (!PlatformAudoSource.isPlaying) {
			//				PlatformAudoSource.Stop ();
			//				PlatformAudoSource.Play ();
			//			}
			ISPlatThere=false;
		}
		else if (collision.gameObject.name.Equals ("land2_bridge_prefab(Clone)")) {
			try{
				collision.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
				collision.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
				collision.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
			}catch{
				
			}
			
			//
			//			if(m_Character.isSwimStarted)
			//				return;
			//
			//
			//			m_Character.audioSource.Pause();
			//			m_Character.BGSoungTag = true;
			//
			////			isBridgeLevelIIZoom=true;
			//
			//			PlatformAudoSource.clip = Puzzle10Clip;
			//			
			//			if (!PlatformAudoSource.isPlaying) {
			//				PlatformAudoSource.Stop ();
			//				PlatformAudoSource.Play ();
			//			}
			ISPlatThere=false;
		}
		else if (collision.gameObject.name.Equals ("land3_cart_prefab(Clone)")) {
			//
			//			if(m_Character.isSwimStarted)
			//				return;
			//
			//
			//			m_Character.audioSource.Pause();
			//			m_Character.BGSoungTag = true;
			//
			//			SkeletonAppearanceAudoSource.Play ();
			//			//			if (!Camera.main.GetComponent<CameraController> ().currentCamPos) {
			//
			////			if(!IScartPrefab)
			////			{
			////			Camera.main.GetComponent<CameraController> ().rotateCamera = true;
			////			Camera.main.GetComponent<CameraController> ().currentCamPos = true;
			////			}
			//
			//
			//			PlatformAudoSource.clip = Puzzle14Clip;
			//			
			//			if (!PlatformAudoSource.isPlaying) {
			//				PlatformAudoSource.Stop ();
			//				PlatformAudoSource.Play ();
			//			}
			//
			ISPlatThere=false;
		}
		else if (collision.gameObject.name.Equals ("land4_prefab(Clone)")) {
			try{
				collision.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true);
			}catch{
				
			}
			
			
			//
			//
			//			if(m_Character.isSwimStarted)
			//				return;
			//
			//			m_Character.audioSource.Pause();
			//			m_Character.BGSoungTag = true;
			//
			//			PlatformAudoSource.clip = Puzzle7Clip;
			//			
			//			if (!PlatformAudoSource.isPlaying) {
			//				PlatformAudoSource.Stop ();
			//				PlatformAudoSource.Play ();
			//			}
			//
			ISPlatThere=false;
		}
		else if (collision.gameObject.name.Equals ("land5_Treasure_prefab(Clone)")) {
			//
			//
			//			if(m_Character.isSwimStarted)
			//				return;
			//
			//
			//			m_Character.audioSource.Pause();
			//			m_Character.BGSoungTag = true;
			//
			//
			////			isBridgeLevelIIZoom=true;
			//
			//			PlatformAudoSource.clip = Puzzle11Clip;
			//			
			//			if (!PlatformAudoSource.isPlaying) {
			//				PlatformAudoSource.Stop ();
			//				PlatformAudoSource.Play ();
			//			}
			//
			ISPlatThere=false;
		}
		else if (collision.gameObject.name.Equals ("land6_FAN_prefab(Clone)")) {
			try{
				collision.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
				collision.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
				collision.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
				collision.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);
			}catch{
				
			}
			//
			//			if(m_Character.isSwimStarted)
			//				return;
			//
			//			m_Character.audioSource.Pause();
			//			m_Character.BGSoungTag = true;
			//
			//
			//			if (!PlatformAudoSource.isPlaying) {
			//				PlatformAudoSource.Stop ();
			//				PlatformAudoSource.Play ();
			//			}
			ISPlatThere=false;
		}
		else if (collision.gameObject.name.Equals ("land7_prefab(Clone)")) {
			try{
				collision.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);
			}catch{
				
			}
			
			//
			//			if(m_Character.isSwimStarted)
			//				return;
			//
			//			m_Character.audioSource.Pause();
			//			m_Character.BGSoungTag = true;
			//
			//
			////			isBridgeLevelIIZoomForLandSevn=true;
			//
			//			PlatformAudoSource.clip = Puzzle13Clip;
			//			
			//			if (!PlatformAudoSource.isPlaying) {
			//				PlatformAudoSource.Stop ();
			//				PlatformAudoSource.Play ();
			//			}
			ISPlatThere=false;
		}
		else if(collision.gameObject.name.Equals ("B12_prefab(Clone)")){
			
			//				collision.transform.GetChild(4).gameObject.SetActive(true);
			//				collision.transform.GetChild(5).gameObject.SetActive(true);
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
		}else if(collision.gameObject.name.Equals ("zip_line_prefab(Clone)")){
			
			//				collision.transform.GetChild(4).gameObject.SetActive(true);
			//				collision.transform.GetChild(5).gameObject.SetActive(true);
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
		}else if(collision.gameObject.name.Equals ("Double_T_prefab 1(Clone)")){
			
			//				collision.transform.GetChild(4).gameObject.SetActive(true);
			//				collision.transform.GetChild(5).gameObject.SetActive(true);
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
		}
		else if(collision.gameObject.name.Equals ("Wall_prefab(Clone)")){

//				collision.transform.GetChild(4).gameObject.SetActive(true);
//				collision.transform.GetChild(5).gameObject.SetActive(true);
		try{
				enableEnmyMotion(collision.gameObject);

			}catch{
				
			}
		}else if(collision.gameObject.name.Equals ("T2_prefab(Clone)")){

			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}

			try{
				collision.transform.GetChild(4).gameObject.SetActive(true);
				collision.transform.GetChild(5).gameObject.SetActive(true);
				collision.transform.GetChild(6).gameObject.SetActive(true);
				
				collision.transform.GetChild(7).gameObject.SetActive(true);
				collision.transform.GetChild(8).gameObject.SetActive(true);
				collision.transform.GetChild(9).gameObject.SetActive(true);
				collision.transform.GetChild(10).gameObject.SetActive(true);
				
				
			}catch{
				
			}
		}else if(collision.gameObject.name.Equals ("P1_prefab(Clone)")){

			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}


			try{
				collision.transform.GetChild(7).gameObject.SetActive(true);
				collision.transform.GetChild(8).gameObject.SetActive(true);
				collision.transform.GetChild(9).gameObject.SetActive(true);
				collision.transform.GetChild(10).gameObject.SetActive(true);
				
			}catch{
				
			}
		}else if(collision.gameObject.name.Equals ("R1_prefab(Clone)")){

			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
			try{
				collision.transform.GetChild(4).gameObject.SetActive(true);
				collision.transform.GetChild(5).gameObject.SetActive(true);
				collision.transform.GetChild(6).gameObject.SetActive(true);
				collision.transform.GetChild(7).gameObject.SetActive(true);
				collision.transform.GetChild(8).gameObject.SetActive(true);
				collision.transform.GetChild(9).gameObject.SetActive(true);
				collision.transform.GetChild(10).gameObject.SetActive(true);
				
			}catch{
				
			}
		}else if(collision.gameObject.name.Equals ("L3_prefab(Clone)")){
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
			try{
				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
			}catch{
				
			}
			try{
				collision.transform.GetChild(5).gameObject.SetActive(true);
				collision.transform.GetChild(6).gameObject.SetActive(true);
				
			}catch{
				
			}
			
			
		}else if(collision.gameObject.name.Equals ("lifts_prefab(Clone)")){
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
			try{
				//				Debug.Log("lifts_prefab");
				for(int i=0;i<5;i++){
					collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(true);
				}
				
				//				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true);
			}catch{
				
			}
			
			try{
				collision.transform.GetChild(9).gameObject.SetActive(true);
				collision.transform.GetChild(10).gameObject.SetActive(true);
				collision.transform.GetChild(11).gameObject.SetActive(true);
				collision.transform.GetChild(12).gameObject.SetActive(true);
				collision.transform.GetChild(13).gameObject.SetActive(true);
				
			}catch{
				
			}
			
			
		}else if(collision.gameObject.name.Equals ("r+t_prefab(Clone)")){

			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
			try{
				
				for(int i=1;i<6;i++){
					collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(true);
				}
				
				
				
				collision.transform.GetChild(0).GetChild(2).GetChild(3).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
				
				for(int i=0;i<5;i++){
					collision.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(true);
				}
				
				//				collision.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(5).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
			}catch{
				
			}
			
			try{
				collision.transform.GetChild(8).gameObject.SetActive(true);
				collision.transform.GetChild(9).gameObject.SetActive(true);
				collision.transform.GetChild(10).gameObject.SetActive(true);
				collision.transform.GetChild(11).gameObject.SetActive(true);
				
				
			}catch{
				
			}
			
		}else if(collision.gameObject.name.Equals ("ST1_prefab(Clone)")){
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
			try{
				for(int i=2;i<8;i++){
					collision.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
				}
				
			}catch{
				
			}
			

			
		}else if(collision.gameObject.name.Equals ("T1_prefab(Clone)")){
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
			try{
				collision.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
				//					collision.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
				//					collision.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).GetChild(0).GetChild(2).gameObject.SetActive(true);
				//					
				//				collision.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
				//				collision.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).GetChild(1).GetChild(2).gameObject.SetActive(true);
				
				
			}catch{
				Debug.Log("EE");
				
			}
		}else if(collision.gameObject.name.Equals ("W1_prefab(Clone)")){
			try{
				enableEnmyMotion(collision.gameObject);
				
			}catch{
				
			}
			try{
				for(int i=1;i<11;i++){
					collision.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(1).GetChild(i).gameObject.SetActive(true);
				}

				
			}catch{
				
			}
		}

		else if (collision.transform.tag == "PathRemoval")
			return;
		else if (collision.gameObject.CompareTag ("JETPACK TOP")) {
			m_Character.JetPackHeightStatus = true;
		}
		else if (collision.gameObject.tag == "FTree") {
			playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.position.x - 5f, this.playerRigidbody.position.y, this.playerRigidbody.position.z);
			camshake.DoShake ();
			int HeathDec = Random.Range (15, 25);
			PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
			GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlus, new Vector3 (this.playerRigidbody.position.x + 0.5f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
			HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
			StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
			Lifes ();
		}
		else if (collision.transform.tag == "HangingCube") {
			
			playerRigidbody.useGravity = false;
			GameObject mygameobject = new GameObject ();
			Vector3 hangPosition = collision.transform.position;
			//hanging...
			Vector3 hangingPosition = hangPosition;
			hangingPosition.x = hangingPosition.x + 0.2f;
			hangingPosition.y = hangingPosition.y + 0.8f;
			GameObject hanging = (GameObject)Instantiate (mygameobject, hangingPosition, Quaternion.identity);
			BoxCollider hangingBoxCollider = hanging.AddComponent<BoxCollider> ();
			hangingBoxCollider.isTrigger = true;
			hangingBoxCollider.size = new Vector3 (0.5f, 0.5f, 5f);
			hanging.tag = "Hanging";
			//hang move forward...
			Vector3 hangMoveFwdPosition = hangPosition;
			hangMoveFwdPosition.y = hangMoveFwdPosition.y + 3.8f;
			GameObject hangMoveFwdObj = (GameObject)Instantiate (mygameobject, hangMoveFwdPosition, Quaternion.identity);
			BoxCollider hangMoveFwdBoxCollider = hangMoveFwdObj.AddComponent<BoxCollider> ();
			hangMoveFwdBoxCollider.isTrigger = true;
			hangMoveFwdBoxCollider.size = new Vector3 (1.232778f, 0.01604557f, 2.301941f);
			hangMoveFwdObj.tag = "HangMoveForward";
		}
		else if (collision.transform.tag == "SmallSoldierCollider") {
			coinTossValue = 0;
			singleCoinObjPosition = new Vector3 (collision.transform.position.x, collision.transform.position.y + 0.5f, playerRigidbody.transform.position.z);
			BlastCoins (collision.gameObject.GetComponent<Collider> ());
			coinStatus = true;
			playerRigidbody.velocity = new Vector3 (0, -10, 0);
			collision.transform.parent.gameObject.SetActive (false);
			StartCoroutine (coinStatusFalse ());
		}
		else if (collision.gameObject.CompareTag ("PickUpCoin")) {
			//			AudioSourceControl.Play ();
			StartCoroutine(PlayCoinSound(AudioSourceControl));
			enablePs (collision.gameObject);
			count = count + 1;
			SetCountText ();
			collision.gameObject.SetActive (false);
		}
		else if (collision.gameObject.CompareTag ("Banana")) {
			//			AudioSourceControl.Play ();
			StartCoroutine(PlayCoinSound(AudioSourceControl));
			enablePs (collision.gameObject);
			collision.gameObject.SetActive (false);
			float cur_health = PlayerPrefs.GetFloat ("RE");
			if (cur_health < 500) {
				cur_health = cur_health + 0.05f;
				PlayerPrefs.SetFloat ("RE", cur_health);
				TileScript.RUNENERGY = true;
				TileScript.RUNENERGYCOUNT = 0;
			} else {
				PlayerPrefs.SetFloat ("RE", 500);
			}
		}
		else if (collision.transform.tag == "SmallSoldier") {
			
		}
		
		else if (collision.transform.tag == "Tree") {
			moveDirection = 4;
			if (m_Character_User_Ctrl.SlidingStatus)
				collision.transform.GetComponent<Collider> ().isTrigger = true;
		}
		else if (collision.transform.tag == "AdiManav") {
			//			TopHeadTouchAudoSource.clip = SoldierTopTouchClip;
			//			TopHeadTouchAudoSource.Play ();
			StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,SoldierTopTouchClip));
			enablePs (collision.gameObject);
			singleCoinObjPosition = new Vector3 (collision.transform.position.x, collision.transform.position.y + 0.5f, playerRigidbody.transform.position.z);
			BlastCoins (collision.gameObject.GetComponent<Collider> ());
			coinStatus = true;
			playerRigidbody.velocity = new Vector3 (0, -10, 0);
			try{
			collision.transform.parent.gameObject.GetComponent<SmallSoldierBehaviour> ().isMove = false;
			}catch{
			}
			StartCoroutine (adiManavDie (collision.transform.parent.gameObject, collision));
			collision.transform.gameObject.SetActive (false);
			StartCoroutine (coinStatusFalse ());
			Instantiate (smoke, collision.transform.position, Quaternion.identity);
			//			StartCoroutine (firstTimeKillAdimanav ());
			string level_fgt = PlayerPrefs.GetString("LEVEL");
			if (level_fgt.Equals ("LEVELI")){
				StartCoroutine (firstTimeKillAdimanav ());
			}
			else if (level_fgt.Equals ("LEVELII")){
				
			}
		}
		
		else if (collision.transform.tag == "ManEatCollider") {
			if (!coinStatus) {
				playerStatusDied = true;
				playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.position.x - 5f, this.playerRigidbody.position.y, this.playerRigidbody.position.z);
				camshake.DoShake ();
				int HeathDec = Random.Range (15, 25);
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlus, new Vector3 (this.playerRigidbody.position.x + 0.5f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
				Lifes ();
				enablePs (collision.gameObject);
			}
		}
		else if (collision.gameObject.name == "batmanEnable") {
			GameObject obj = collision.transform.root.GetChild(8).gameObject;
			StartCoroutine(batmanCreation(new Vector3(obj.transform.position.x,obj.transform.position.y,obj.transform.position.z),obj));
		}
		else if (collision.gameObject.name == "batmanEnable2") {
			Destroy(batman_obj);
			GameObject obj = collision.transform.root.GetChild(9).gameObject;
			StartCoroutine(batmanCreation(new Vector3(obj.transform.position.x,obj.transform.position.y,obj.transform.position.z),obj));
		}
		else if (collision.gameObject.name == "batmanEnable3") {
			Destroy(batman_obj);
			GameObject obj = collision.transform.root.GetChild(10).gameObject;
			StartCoroutine(batmanCreation(new Vector3(obj.transform.position.x,obj.transform.position.y,obj.transform.position.z),obj));
		}
	}
	GameObject batman_obj;
	private IEnumerator batmanCreation (Vector3 pos,GameObject obj1)
	{
		yield return new WaitForSeconds(0.1f);
		if (!batman_obj) {
			int random_enemy=Random.Range(0,batman.Length);
			random_enemy=0;
			batman_obj = (GameObject)Instantiate (batman[random_enemy], pos, Quaternion.identity);

			if(random_enemy == 0)
			{
				batman_obj.transform.position= new Vector3 (this.batman_obj.transform.position.x, this.batman_obj.transform.position.y+3f, this.batman_obj.transform.position.z);
			}

			batman_obj.transform.rotation = Quaternion.Euler (0, -90, 0);
			try{
				batman_obj.gameObject.transform.SetParent (obj1.transform);
			}catch{

			}
		}
	}
	
	void enablePs (GameObject gameObject)
	{
		GameObject ps_Gobj = (GameObject)Instantiate (ps, transform.position, Quaternion.identity);
		StartCoroutine (destroyPS (ps_Gobj));
	}
	
	IEnumerator adiManavDie (GameObject adiManav, Collision collision)
	{
		yield return new WaitForSeconds (0.05f);
//		collision.transform.parent.gameObject.transform.localScale = new Vector3 (30, 25, 30);
//		collision.transform.parent.gameObject.transform.position = new Vector3 (playerRigidbody.transform.position.x, collision.transform.position.y - 4f, playerRigidbody.transform.position.z);
//		yield return new WaitForSeconds (0.05f);
//		collision.transform.parent.gameObject.transform.localScale = new Vector3 (30, 20, 30);
//		collision.transform.parent.gameObject.transform.position = new Vector3 (playerRigidbody.transform.position.x, collision.transform.position.y - 0.1f, playerRigidbody.transform.position.z);
//		yield return new WaitForSeconds (0.05f);
//		collision.transform.parent.gameObject.transform.localScale = new Vector3 (30, 15, 30);
//		collision.transform.parent.gameObject.transform.position = new Vector3 (playerRigidbody.transform.position.x, collision.transform.position.y - 0.1f, playerRigidbody.transform.position.z);
//		yield return new WaitForSeconds (0.05f);
//		collision.transform.parent.gameObject.transform.localScale = new Vector3 (30, 10, 30);
//		collision.transform.parent.gameObject.transform.position = new Vector3 (playerRigidbody.transform.position.x, collision.transform.position.y - 0.1f, playerRigidbody.transform.position.z);
//		yield return new WaitForSeconds (0.05f);
//		collision.transform.parent.gameObject.transform.localScale = new Vector3 (30, 5, 30);
//		collision.transform.parent.gameObject.transform.position = new Vector3 (playerRigidbody.transform.position.x, collision.transform.position.y - 0.1f, playerRigidbody.transform.position.z);
		Destroy (adiManav.gameObject);
	}
	
	IEnumerator coinJumpFast (Rigidbody gameObjectsRigidBody)
	{
		yield return new WaitForSeconds (0.2f);
		Vector3 movement;
		coinTossValue += 100;
		movement = new Vector3 (coinTossValue, 50.0f, 0.0f);
		if (gameObjectsRigidBody != null)
			gameObjectsRigidBody.AddForce (movement);
	}
	
//	IEnumerator createRockObj (Transform t)
//	{
//		if (!isRock) {
//			isRock = true;
//			Vector3 rockPosition = t.gameObject.transform.position;
//			GameObject rockObj = (GameObject)Instantiate (rock, rockPosition, Quaternion.identity);
//			yield return new WaitForSeconds (6f);
//			isRock = false;
//		}
//	}
	IEnumerator destroyPS1 ()
	{
		yield return new WaitForSeconds (1.0f);
		m_Character.FishTouchTag = false;
	}
	
	void coinAdded (Collision collision, int noCoins)
	{
		if (!playerStatusDied) {
			coinStatus = true;
			playerRigidbody.velocity = new Vector3 (0, -10, 0);
			collision.transform.parent.gameObject.SetActive (false);
			enablePs (collision.gameObject);
			coinMove = 1;
			for (int i=0; i<3; i++) {
				coins [i].SetActive (true);
				coins [i].transform.position = new Vector3 (playerRigidbody.transform.position.x + (i * 2), playerRigidbody.transform.position.y + (i * 2), playerRigidbody.transform.position.z);
			}
			Invoke ("coinSetFalse", 1.5f);
			count = count + noCoins;
			SetCountText ();
			StartCoroutine (coinStatusFalse ());
		}
	}
	
	void OnCollisionStay (Collision collisionInfo)
	{
		if (collisionInfo.transform.tag == "Tree") {
			moveDirection = 4;
			if (m_Character_User_Ctrl.SlidingStatus)
				collisionInfo.transform.GetComponent<Collider> ().isTrigger = true;
		}else if (collisionInfo.gameObject.name.Equals ("land3_cart_prefab(Clone)")) {
			//      Debug.Log("ON LAND_CART FLOOR!!!");
			transform.eulerAngles = euler0;
		}
	}
	
	void OnCollisionExit (Collision collision)
	{
		if (collision.transform.tag == "Tree") {
			moveDirection = 0;
		}
		else if(collision.gameObject.name == "z2_path")
		{
			Destroy(collision.transform.root.GetChild(10).gameObject);
		}
		
	}
	
	void startMushroomJump ()
	{
		this.playerRigidbody.velocity = new Vector3 (1f, 18f, 0f);
	}
	
	void createSignleCoin ()
	{
		GameObject coinObj;
		singleCoinObjPosition.x = singleCoinObjPosition.x + 1f;
		if (IsCoin)
			coinObj = (GameObject)Instantiate (singleCoinObj, singleCoinObjPosition, Quaternion.identity);
		else
			coinObj = (GameObject)Instantiate (bananaObj, singleCoinObjPosition, Quaternion.identity);
		Rigidbody gameObjectsRigidBody = coinObj.GetComponent<Rigidbody> ();
		if (!IsCoin)
			gameObjectsRigidBody.transform.Rotate (new Vector3 (0, 0, 0));
		StartCoroutine (coinJumpFast (gameObjectsRigidBody));
	}
	
//	private void plantObjectFalse ()
//	{
//		
//		plantobj.SetActive (false);
//	}
	
	private static bool iSPowerUp = false;
	private bool HanumanShieldActivateStatus = false;
	public static string POWERTAG = "";
	
	IEnumerator FallDown (GameObject obj)
	{
		//2 LEVELI
		yield return new WaitForSeconds (0f);
		
		DestroyObject (obj);
		
	}
	
//	private bool Tilecreation = false;
//	
//	private void  PathCreation ()
//	{
//		Tilecreation = true;
//	}
	
	IEnumerator firstTimeKillAdimanav ()
	{
		yield return new WaitForSeconds (1f);
		int isFirstTimeKillAdimanav = PlayerPrefs.GetInt ("isFirstTimeKillAdimanav");
		if (isFirstTimeKillAdimanav == 0) {
			Time.timeScale = 0;
			encouragmentUI = (GameObject)Instantiate (encouragementUI, new Vector3 (0f, 0f, 0f), Quaternion.identity);
			PlayerPrefs.SetInt ("isGui", 1);
			PlayerPrefs.SetInt ("isFirstTimeKillAdimanav", 1);
		} else {
		}
	}
	int coinRandom=0,bananaRandom=0,random;
	
	void swiptoinitial ()
	{
		swimpos = 0;
	}
	
	
	IEnumerator isBridgeLevelIIZoomFalse ()
	{
		yield return new WaitForSeconds (0f);
		isBridgeLevelIIZoom = false;
		isBridgeLevelIIZoomForLandSevn=false;
		LEVELIIIZOOM = false;
		LEVELIIIZOOMliftsprefab = false;
	}
	
	
	IEnumerator PlatisBridgeLevelIIZoomFalse ()
	{
		yield return new WaitForSeconds (2f);
		ISPlatThere = false;
	}
	IEnumerator MakeKinematicFalse ()
	{
		yield return new WaitForSeconds (1f);
		playerRigidbody.isKinematic=false;
	}
	
	IEnumerator ISRightFlagTrigFn(){
		yield return new WaitForSeconds (0.1f);
		ISRightFlagTrig = true;
	}
	bool ISRightFlagTrig=true;
	
	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "batbomb") {
			if (!HanumanShieldActivateStatus) {
				GameObject DestroyEffect = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (DestroyEffect));
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x+2f , this.playerRigidbody.position.y+1.5f, this.playerRigidbody.position.z-1f), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 10);
				Lifes ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				transform.eulerAngles = euler0;
			}
		}

		if (other.transform.name == "PlayerStableCollider" ){
			other.enabled = false;
			playerRigidbody.isKinematic=true;
			this.transform.position = new Vector3(transform.position.x,transform.position.y,other.gameObject.transform.parent.GetChild(1).position.z);
			this.transform.parent = null;
			StartCoroutine(MakeKinematicFalse());
		}

		if (other.transform.tag == "LeveliiiZoom" ){
			LEVELIIIZOOM=true;
		}
		if (other.transform.tag == "LEVELIIIZOOMliftsprefab" ){
			LEVELIIIZOOMliftsprefab=true;
		}
		if (other.transform.tag == "Uler" ){
			transform.eulerAngles = euler0;
		}

		if (other.transform.tag == "Logic7zoom" ){
			isBridgeLevelIIZoomForLandSevn=true;
		}
		if (other.transform.tag == "PlatDetailRayCheck" ){
			isBridgeLevelIIZoom = true;
			
		}
		
		if (other.transform.tag == "RemoveZoomIn" ) {
			//			isBridgeLevelIIZoom = true;
			StartCoroutine (isBridgeLevelIIZoomFalse ());
		}
		if (other.transform.tag == "PlatDetailRay") {
			//			isBridgeLevelIIZoom=true;
			ISPlatThere=true;
			StartCoroutine (PlatisBridgeLevelIIZoomFalse ());
			//			Ray ray = new Ray(this.transform.position, Vector3.right);
			//			RaycastHit hitInfo = new RaycastHit();
			////			Debug.DrawRay (transform.position + transform.TransformDirection (new Vector3 (0f, 1.7f, 0f)), transform.TransformDirection (new Vector3 (0f, 0f, 0.3f)), Color.red);
			//		
			////			if(Physics.Raycast(transform.position + transform.TransformDirection (new Vector3 (0f, 1.7f, 0f)), transform.TransformDirection (new Vector3 (0f, 0f, 0.3f)), out hangingRaycast,1f,layer)){
			//			if (Physics.Raycast(ray, out hitInfo)){
			////			try{
			////				Debug.Log("NEXT !!! "+hitInfo.distance );
			////			}catch{
			////				}
			//				if(hitInfo.distance < 2)
			////					
			//						//					hitInfo.collider.transform.parent.GetChild(2).gameObject.SetActive(true);
			////					Debug.Log("NEXT !!! "+hitInfo.collider.transform.name );
			//
			//
			//
			//
			//			}
		}
		
		if (other.transform.tag == "Lava") {
			PlayerPrefs.SetString("HEALTHREDUCE","");
			GameObject DestroyEffect = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
			StartCoroutine (destroyPS (DestroyEffect));
			GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x+2f , this.playerRigidbody.position.y, this.playerRigidbody.position.z), Quaternion.identity);
			HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
			StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
			PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 50);
			Lifes ();
			//			TopHeadTouchAudoSource.clip = HealthReductionClip;
			//			TopHeadTouchAudoSource.Play ();
			StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
		}
		else if (other.transform.tag == "CartanimCompleted") {
			this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x, this.playerRigidbody.transform.position.y, -0.2f);
		}
		else if (other.transform.tag == "LEVELIIIBOTTOMSTONE") {
			
//			if(ISRightFlagTrig)
//			{
			if (!HanumanShieldActivateStatus) {
				ISRightFlagTrig=false;
				
//				this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
				
				//			this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 1, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
				GameObject DestroyEffect = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (DestroyEffect));
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x+2f , this.playerRigidbody.position.y+1.5f, this.playerRigidbody.position.z), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 10);
				Lifes ();
				//			TopHeadTouchAudoSource.clip = HealthReductionClip;
				//			TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				StartCoroutine(ISRightFlagTrigFn());
				transform.eulerAngles = euler0;
//				Debug.Log(other.transform.parent.parent.gameObject.name);
				try{
				if(other.transform.parent.parent.gameObject.name != "Final_Small_01:Hand_Rigg_Import:joint15")
				{
				this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 2.5f, this.playerRigidbody.transform.position.y, -0.2f);
				
				}else if(other.transform.gameObject.name.Equals("Particle System")){
						this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 0.2f, this.playerRigidbody.transform.position.y, -0.2f);
					}
				}catch{
					this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 2.5f, this.playerRigidbody.transform.position.y, -0.2f);
				}

			}
//			}
		}
		
		else if (other.transform.tag == "StoneTrig") {
			this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 1, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
			GameObject DestroyEffect = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
			StartCoroutine (destroyPS (DestroyEffect));
			GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x+2f , this.playerRigidbody.position.y, this.playerRigidbody.position.z), Quaternion.identity);
			HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
			StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
			PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 50);
			Lifes ();
			//			TopHeadTouchAudoSource.clip = HealthReductionClip;
			//			TopHeadTouchAudoSource.Play ();
			StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
		}
		
		if (other.gameObject.tag == "BridgeanimfalselevelII") {
			StartCoroutine (removeKinamatic ());
			//      playerRigidbody.isKinematic=false;
			transform.eulerAngles = euler0;
			isBridgeLevelIIZoom=false;
			//			for(int i=30 ; i>10 ; i++){
			Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x,10,Camera.main.transform.eulerAngles.z);
			//			}
			Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x,10,Camera.main.transform.eulerAngles.z);
			Camera.main.GetComponent<CameraController> ().rotateCamera = false;
//			IScartPrefab=true;
		}
		//		if (other.gameObject.tag == "BridgeanimfalselevelII") {
		//			playerRigidbody.isKinematic=false;
		//			transform.eulerAngles = euler0;
		//			isBridgeLevelIIZoom=false;
		//			Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x,10,Camera.main.transform.eulerAngles.z);
		//			//			Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x,0,Camera.main.transform.eulerAngles.z);
		//			//			transform.position = playerRigidbody.transform.position + offset + new Vector3(-15,0,15);
		//			Camera.main.GetComponent<CameraController> ().rotateCamera = false;
		//			
		//			
		//		}
		else if(other.gameObject.tag == "Bridge"){
			//				other.transform.parent.gameObject.GetComponent<Animator> ().SetTrigger ("Bridgedown");
			isBridgeLevelIIZoom=true;
			//        BridgeLevelIIZoom();
		}
		//			if(other.gameObject.tag == "cartMoveTag"){
		//				other.transform.parent.gameObject.GetComponent<Animator> ().SetTrigger ("cartMove");
		//			}
		else if (other.transform.gameObject.tag == "SplineCntrl") {
			GetSplineOBJ(other.transform.gameObject);
		}
		
		else if (other.gameObject.tag == "ComboSlide") {
			this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 1f, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
			
		}
		else if (other.transform.tag == "LeftFlagTrig") {
			
			if(ISRightFlagTrig)
			{
				ISRightFlagTrig=false;
				
				this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 3, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
				GameObject DestroyEffect = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (DestroyEffect));
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x - 2f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 50);
				Lifes ();
				//			TopHeadTouchAudoSource.clip = HealthReductionClip;
				//			TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				
				StartCoroutine(ISRightFlagTrigFn());
			}
		}
		else if (other.transform.tag == "RightFlagTrig") {
			
			
			if(ISRightFlagTrig)
			{
				ISRightFlagTrig=false;
				
				this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x + 3, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
				GameObject DestroyEffect = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (DestroyEffect));
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x - 2f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
				
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 50);
				Lifes ();
				//			TopHeadTouchAudoSource.clip = HealthReductionClip;
				//			TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				
				StartCoroutine(ISRightFlagTrigFn());
			}
		}
		
		else if (other.gameObject.tag == "Diamond") {
			GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
			//			Invoke ("destroyPS", 1f);
			StartCoroutine (destroyPS (ps_Gobj));
			Destroy (other.gameObject);
			//				diamondCount ++;
			//				diamondCount=diamondCount+
			int diamond=PlayerPrefs.GetInt(DIAMOND);
			diamond=diamond+1;
			PlayerPrefs.SetInt(DIAMOND ,diamond);
			
		}
		else if (other.gameObject.tag == "PlatformTouch") {
			GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
			//			Invoke ("destroyPS", 1f);
			StartCoroutine (destroyPS (ps_Gobj));
			PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
			GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlus, new Vector3 (this.playerRigidbody.position.x - 10f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
			//			Invoke ("destroyPS", 1f);
			HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
			StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
			Lifes ();
			//			TopHeadTouchAudoSource.clip = HealthReductionClip;
			//			TopHeadTouchAudoSource.Play ();
			StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
			this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 15f, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
		}
		else if (other.gameObject.tag == "Combithree") {
			
		}
		else if (other.gameObject.tag == "Swith_two") {
			PlayerPrefs.SetInt ("Swith", 0);
		}
		else if (other.gameObject.tag == "Swith") {
			PlayerPrefs.SetInt ("Swith", 1);
		}
		else if (other.gameObject.tag == "fish") {
			
			if(!m_Character.isSwimStarted && !m_Character.isVineTouched){
				return;
			}
			
			if(!ForceFieldAudoSource.isPlaying){


				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 50);
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x + 0.5f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));


				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 50);
				Lifes ();
				//				TopHeadTouchAudoSource.clip = HealthReductionClip;
				//				TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				swimpos = 1;
				
				GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (ps_Gobj));
				StartCoroutine (destroyPS1 ());
			}
		}
		else if (other.gameObject.tag == "fish1") {
			
			if(!ForceFieldAudoSource.isPlaying){
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
				Lifes ();
				//				TopHeadTouchAudoSource.clip = HealthReductionClip;
				//				TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				swimpos = 2;
				
				GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (ps_Gobj));
			}
		}
		else if (other.gameObject.tag == "fish2") {
			if(!ForceFieldAudoSource.isPlaying){
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
				Lifes ();
				//				TopHeadTouchAudoSource.clip = HealthReductionClip;
				//				TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				swimpos = 3;
				
				GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (ps_Gobj));
			}
		}
		Invoke ("swiptoinitial", 0.5f);
		if (other.gameObject.tag == "FTree") {
			if(!HanumanShieldActivateStatus){
				//				TopHeadTouchAudoSource.clip = HealthReductionClip;
				//				TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (ps_Gobj));
				int walkStickStatus = PlayerPrefs.GetInt ("walkStickStatus2");
				if (walkStickStatus == 0)
					this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 3, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
				else {
					this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x + 3, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
				}
				camshake.DoShake ();
				int HeathDec = Random.Range (15, 25);
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlus, new Vector3 (this.playerRigidbody.position.x + 0.5f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
				Lifes ();
			}
		}
		else if (other.transform.tag == "StoneFallDown") {
			//			if (!StoneBridgeFallAudoSource.isPlaying)
			//				StoneBridgeFallAudoSource.Play ();
			StartCoroutine (StoneFallDown (other.transform.gameObject));
		}
		
		else if (other.transform.name == "RotateCamera") {
			disableShieldFast ();
			PlayerPrefs.SetInt ("UI_DESABLE", 2);
			//			SkeletonAppearanceAudoSource.Play ();
			//			if (!Camera.main.GetComponent<CameraController> ().currentCamPos) {
			Camera.main.GetComponent<CameraController> ().rotateCamera = true;
			Camera.main.GetComponent<CameraController> ().currentCamPos = true;
			//			}
			StartCoroutine (movePlayer ());
			
		}
		else if (other.transform.name == "RotateCamera_Cart") {
			//			disableShieldFast ();
			//			PlayerPrefs.SetInt ("UI_DESABLE", 2);
			//			SkeletonAppearanceAudoSource.Play ();
			isBridgeLevelIIZoomForLandSevn=false;
			isBridgeLevelIIZoom=false;
			//			if (!Camera.main.GetComponent<CameraController> ().currentCamPos) {
			Camera.main.GetComponent<CameraController> ().rotateCamera = true;
			Camera.main.GetComponent<CameraController> ().currentCamPos = true;
//			IScartPrefab=false;
			
			
			//			}
			//			StartCoroutine (movePlayer ());
		}
		
		else if (other.transform.tag == "removetilesobjs") {
			Debug.Log("removetilesobjs");
			for (int i =TileManager.Instance.leftTilesFinal.Count -1; i>=0; i--) {
				GameObject go = (GameObject)TileManager.Instance.leftTilesFinal [i];
				TileManager.Instance.leftTilesFinal.RemoveAt (i);
				StartCoroutine (FallDown (go));
			}
		}
		else if (other.transform.tag == "DynamicRemoval") {

			int index = PlayerPrefs.GetInt ("PathRemovalLEFT");
			if (index == 0) {
				TileManager.Instance.leftTilesFinal.Add (other.transform.parent.gameObject);
			}
		}
		else if (other.transform.tag == "Dynamic") {

			int index = PlayerPrefs.GetInt ("PathRemovalLEFT");
		}
		//			if (other.transform.tag == "Water") {
		//				m_Character.swimStatus = true;
		//				anim.SetBool ("HanuSwim", true);
		//			}
		else if (other.transform.tag == "isJetPackZoomed") {
			isJetPackZoomed=true;
		}
		
		else if (other.transform.tag == "SwimUp") {
			if (m_Character.swimStatus) {
				m_Character.swimUpStatus = true;
				anim.SetBool ("HanuSwim", false);
			}
		}
		else if (other.transform.tag == "MUSS") {
			// MUSROOM FRON & BACK COLLIDER
			if (HanumanShieldActivateStatus) {
				enablePs (other.transform.gameObject);
				singleCoinObjPosition = new Vector3 (other.transform.position.x, other.transform.position.y + 0.5f, playerRigidbody.transform.position.z);
				BlastCoins (other.gameObject.GetComponent<Collider> ());
				coinStatus = true;
				other.transform.parent.gameObject.SetActive (false);
				StartCoroutine (coinStatusFalse ());
				Instantiate (smoke, other.transform.position, Quaternion.identity);
			}
		}
		else if (other.transform.tag == "Heart") {
			if (iSPowerUp)
				disableShieldFast ();
			iSPowerUp = true;
			//			PowerUpAudoSource.Play ();
			StartCoroutine(PlaypowerUpSound(PowerUpAudoSource));
			POWERTAG = "Heart";
			enablePs (other.transform.gameObject);
			heartPowerUp (other.transform.gameObject);
			enablePs (other.transform.gameObject);
			other.gameObject.SetActive (false);
			
		}
		else if (other.transform.tag == "FirstAid") {
			if (iSPowerUp)
				disableShieldFast ();
			iSPowerUp = true;
			//			PowerUpAudoSource.Play ();
			StartCoroutine(PlaypowerUpSound(PowerUpAudoSource));
			POWERTAG = "FirstAid";
			enablePs (other.transform.gameObject);
			firstaidPowerUp (other.transform.gameObject);
			if (PlayerPrefs.GetFloat ("HEALTH") < 500)
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") + 100);
			GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusPositive, new Vector3 (this.playerRigidbody.position.x + 3f, this.playerRigidbody.position.y + 1f, this.playerRigidbody.position.z), Quaternion.identity);
			//			Invoke ("destroyPS", 1f);
			HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, -180f, 0f));
			StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
			
			//				powerupProgress.startProgressBar();
			enablePs (other.transform.gameObject);
			other.gameObject.SetActive (false);
		}
		//			if (other.transform.tag == "JetPack") {
		//				POWERTAG="JetPack";
		//				enablePs(other.transform.gameObject);
		//				jetpackPowerUp(other.transform.gameObject);
		//			}
		else if (other.transform.tag == "JetPack") {
			isJetPackZoomed=true;
			if (iSPowerUp)
				disableShieldFast ();
			iSPowerUp = true;
			//			PowerUpAudoSource.Play ();
			StartCoroutine(PlaypowerUpSound(PowerUpAudoSource));
			JetPackAudoSource.Play ();
			POWERTAG = "JetPack";
			enablePs (other.transform.gameObject);
			jetpackPowerUp (other.transform.gameObject);
			m_Character.JetPackStatus = true;
			PlayerPrefs.SetInt ("JetPackStatus", 1);
			
			Transform playerObj = playerRigidbody.gameObject.transform.GetChild (0).GetChild (0).GetChild (2).GetChild (1);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (true);
			StartCoroutine (disableJetPack (playerChildObj));
			Transform topJetPack = playerRigidbody.gameObject.transform;
			GameObject mygameobject = new GameObject ();
			BoxCollider hangingBoxCollider = mygameobject.AddComponent<BoxCollider> ();
			hangingBoxCollider.isTrigger = false;
			hangingBoxCollider.size = new Vector3 (1000.5f, 0.5f, 6f);
			mygameobject.transform.position = new Vector3 (topJetPack.position.x + 500f, topJetPack.position.y - 10f, topJetPack.position.z);
			mygameobject.tag = "JETPACK BOTTOM";
			mygameobject.name="JB";
			GameObject mygameobject1 = new GameObject ();
			BoxCollider hangingBoxCollider1 = mygameobject1.AddComponent<BoxCollider> ();
			hangingBoxCollider1.isTrigger = false;
			hangingBoxCollider1.size = new Vector3 (1000.5f, 0.5f, 6f);
//			Debug.Log(topJetPack.position.y);
			mygameobject1.transform.position = new Vector3 (topJetPack.position.x + 500f,  60.0f, topJetPack.position.z);
			mygameobject1.tag = "JETPACK TOP";
			mygameobject1.name="JT";
			
			powerupProgress.startProgressBar ();
			enablePs (other.transform.gameObject);
			other.gameObject.SetActive (false);
		}
		else if (other.transform.tag == "HyperJump") {
			if (iSPowerUp)
				disableShieldFast ();
			iSPowerUp = true;
			POWERTAG = "HyperJump";
			//			PowerUpAudoSource.Play ();
			StartCoroutine(PlaypowerUpSound(PowerUpAudoSource));
			enablePs (other.transform.gameObject);
			m_Character.hyperJumpStatus = true;
			hyerjumpPowerUp (other.transform.gameObject);
			Transform playerObj = playerRigidbody.gameObject.transform.GetChild (0).GetChild (0).GetChild (0).GetChild (0).GetChild (0).GetChild (0);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (true);
			Transform playerObj1 = playerRigidbody.gameObject.transform.GetChild (0).GetChild (0).GetChild (1).GetChild (0).GetChild (0).GetChild (0);
			GameObject playerChildObj1 = playerObj1.gameObject;
			playerChildObj1.SetActive (true);
			StartCoroutine (disableShield (playerChildObj));
			StartCoroutine (disableShield (playerChildObj1));
			
			powerupProgress.startProgressBar ();
			enablePs (other.transform.gameObject);
			other.gameObject.SetActive (false);
		}
		else if (other.transform.tag == "ForceField") {
			if (iSPowerUp)
				disableShieldFast ();
			iSPowerUp = true;
			//			PowerUpAudoSource.Play ();
			StartCoroutine(PlaypowerUpSound(PowerUpAudoSource));
			//			ForceFieldAudoSource.Play ();
			StartCoroutine(PlaypowerUpSound(ForceFieldAudoSource));
			POWERTAG = "ForceField";
			enablePs (other.transform.gameObject);
			HanumanShieldActivateStatus = true;
			Transform playerObj = gameObject.transform.GetChild (4);
			//        GameObject playerChildObj = playerObj.GetChild(4);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (true);
			//          HanumanShield
			StartCoroutine (disableShield (playerChildObj));
			forcefieldPowerUp (other.transform.gameObject);
			
			powerupProgress.startProgressBar ();
			enablePs (other.transform.gameObject);
			other.gameObject.SetActive (false);
		}
		else if (other.transform.tag == "plantopentag") {
			if(!HanumanShieldActivateStatus){
				//				TopHeadTouchAudoSource.clip = HealthReductionClip;
				//				TopHeadTouchAudoSource.Play ();
				StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
				GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (ps_Gobj));
				this.playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.transform.position.x - 3, this.playerRigidbody.transform.position.y, this.playerRigidbody.transform.position.z);
				camshake.DoShake ();
				int HeathDec = Random.Range (15, 25);
				PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 50);
				GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x + 0.5f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z-4.0f), Quaternion.identity);
				HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
				StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
				Lifes ();
			}
		}
		else if (other.transform.tag == "maneatforce") {
			if (HanumanShieldActivateStatus) {
				enablePs (other.transform.gameObject);
				coinTossValue = 0;
				other.gameObject.SetActive (false);
				singleCoinObjPosition = new Vector3 (other.transform.position.x, other.transform.position.y + 0.5f, playerRigidbody.transform.position.z);
				BlastCoins (other);
				Instantiate (smoke, other.transform.position, Quaternion.identity);
			} else {
				other.isTrigger = false;
			}
		}
		else if (other.transform.tag == "plantclosetag") {
			enablePs (other.transform.gameObject);
			other.transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.gameObject.SetActive (false);
			//			TopHeadTouchAudoSource.clip = SoldierTopTouchClip;
			//			TopHeadTouchAudoSource.Play ();
			StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,SoldierTopTouchClip));
			coinTossValue = 0;
			other.gameObject.SetActive (false);
			singleCoinObjPosition = new Vector3 (other.transform.position.x, other.transform.position.y + 0.5f, playerRigidbody.transform.position.z);
			BlastCoins (other);
			Instantiate (smoke, other.transform.position, Quaternion.identity);
		}
		else if (other.transform.tag == "Mushroom") {
			TopHeadTouchAudoSource.clip = SpringTopTouchClip;
			TopHeadTouchAudoSource.Play ();
			StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,SpringTopTouchClip));
			other.transform.parent.gameObject.GetComponent<Animator> ().SetTrigger ("Mshrm");
			//        playerRigidbody.position = new Vector3(other.transform.parent.position.x, other.transform.parent.position.y + 0.8f,other.transform.parent.position.z);
			SphereCollider sphere = other.transform.parent.gameObject.GetComponent<SphereCollider> ();
			sphere.radius = 0.03f;
			Invoke ("startMushroomJump", 0.4f);
		}
		else if (other.transform.tag == "Xaxis") {
			ZoomIn ();
		}
		else if (other.transform.tag == "SmallSoldier") {
			
			if (HanumanShieldActivateStatus) {
				GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
				StartCoroutine (destroyPS (ps_Gobj));
				singleCoinObjPosition = new Vector3 (other.transform.position.x, other.transform.position.y + 0.5f, playerRigidbody.transform.position.z);
				BlastCoins (other.gameObject.GetComponent<Collider> ());
				coinStatus = true;
				other.transform.gameObject.SetActive (false);
				StartCoroutine (coinStatusFalse ());
				Instantiate (smoke, other.transform.position, Quaternion.identity);
				//				StartCoroutine (firstTimeKillAdimanav ());
				string level_fgt = PlayerPrefs.GetString("LEVEL");
				if (level_fgt.Equals ("LEVELI")){
					StartCoroutine (firstTimeKillAdimanav ());
				}
				else if (level_fgt.Equals ("LEVELII")){
					
				}
			} else {
				if (!coinStatus) {
					//					TopHeadTouchAudoSource.clip = HealthReductionClip;
					//					TopHeadTouchAudoSource.Play ();
					StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,HealthReductionClip));
					GameObject ps_Gobj = (GameObject)Instantiate (adiManav_Maneat_ps, transform.position, Quaternion.identity);
					StartCoroutine (destroyPS (ps_Gobj));
					playerStatusDied = true;
					playerRigidbody.transform.position = new Vector3 (this.playerRigidbody.position.x - 5f, this.playerRigidbody.position.y, this.playerRigidbody.position.z);
					camshake.DoShake ();
					int HeathDec = Random.Range (15, 25);
					PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
					GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlus, new Vector3 (this.playerRigidbody.position.x + 0.5f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
					HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
					StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
					Lifes ();
				}
			}
		}
		else if (other.transform.tag == "ManEatCollider") {
			if (!coinStatus) {
				playerStatusDied = true;
				enablePs (other.transform.gameObject);
			}
		}
		else if (other.transform.tag == "StopSlid") {
			m_Character_User_Ctrl.SlidingStatus = true;
		}
		else if (other.transform.tag == "Distance") {
			DISTANCEVARY = true;
		}
		else if (other.transform.tag == "Box") {
		}
		else if (other.transform.tag == "OverheadStone") {
			BoxTouchAudoSource.clip = BoxTouchClip;
			BoxTouchAudoSource.Play ();
			enablePs (other.transform.gameObject);
			coinTossValue = 0;

			other.gameObject.SetActive (false);
			singleCoinObjPosition = new Vector3 (other.transform.position.x, other.transform.position.y + 0.5f, playerRigidbody.transform.position.z);
			float diff = 0.0f;
//			int random_Coin_Banana = Random.Range (0, 2);
//			IsCoin = (random_Coin_Banana == 0);
			
			if(IsCoin)
			{
				IsCoin=false;
				int coinCount = PlayerPrefs.GetInt("coinRandom");
				coinRandom = Random.Range(3,7);
				coinCount = coinCount+coinRandom;
				PlayerPrefs.SetInt("coinRandom",coinCount);
				random = coinRandom;
			}
			else{
				IsCoin=true;
				int bananaCount = PlayerPrefs.GetInt("bananaRandom");
				bananaRandom = Random.Range(3,7);
				bananaCount = bananaCount+bananaRandom;
				PlayerPrefs.SetInt("bananaRandom",bananaRandom);
				random = bananaRandom;
			}
			
			//			int random = Random.Range (5, 11);
			for (int i=0; i<random; i++) {
				diff += 0.1f;
				Invoke ("createSignleCoin", diff);
			}

			Destroy(other.gameObject);
			
		}
		else if (other.transform.tag == "enemyScene") {
			if (ii == 0) {
				disableShieldFast ();
//				Debug.Log("Lankacount AT ENAMYSCENE :  "+Lankacount);
				PlayerPrefs.SetFloat ("AIMIII", Lankacount);

				PlayerPrefs.SetInt (COINS, count);
				//				Application.LoadLevel ("TrainingRoom");
				//				Debug.Log("AUDIO "+m_Character.audioSource);
				//				m_Character.audioSource.Stop();
				//				Destroy (m_Character.audioSource);
//				foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) {
//
//					if(o.gameObject.name.Equals("Main Camera")){
//						try{
//						Destroy(o.GetComponent<CameraController>());
//						}catch{
//
//						}
//					}
//					else{
//						Destroy(o);
//					}
//
//					//					try{
//					//					if(o.transform.parent.gameObject !=null)
//					//					{
//					//					Debug.Log(o.transform.parent.gameObject);
//					////					if(!o.name.Equals("Main Camera"))
//					//					Destroy(o.transform.parent.gameObject);
//					//					}else{
//					//						Debug.Log(o);
//					//						//					if(!o.name.Equals("Main Camera"))
//					//						Destroy(o);
//					//					}
//					//					}catch{
////					Debug.Log(o);
//					//					if(!o.name.Equals("Main Camera"))
//					
//					//					}
//				}
				PlayerPrefs.SetString("SceneTO","UFE");
//				Application.LoadLevel ("NewScene");
				//				Resources.UnloadUnusedAssets();
				
				//				TrainingRoom_async.allowSceneActivation = true;
				//				Application.LoadLevel ("NewScene");

				MoveFight = true;
				Application.LoadLevel ("TrainingRoom");
				//				Application.LoadLevel("TrainingRoom");
				ii = 1;
			}
		}
		else if (other.transform.tag == "MoveDown") {
			moveDirection = 1;
		}
		else if (other.transform.tag == "fallDown") {
			fallDown = true;
			fallDownStopActions = true;
			StartCoroutine (fallDownFalse ());
		}
		else if (other.transform.tag == "MoveStraight") {
			moveDirection = 0;
		}
		else if (other.transform.tag == "MoveUp") {
			moveDirection = 2;
		}
		else if (other.transform.tag == "ResetRotation") {
			moveDirection = 3;
		}
		else if (other.transform.tag == "PickUpCoin") {
			enablePs (other.transform.gameObject);
			count = count + 1;
			SetCountText ();
			other.transform.gameObject.SetActive (false);
		}
		
		else if (other.transform.tag == "Hanging") {
			if (hangingState == 0)
				StartCoroutine (hangUpX ());
		}
		else if (other.transform.tag == "gameOver") {
			if (StoneBridgeFallAudoSource.isPlaying)
				StoneBridgeFallAudoSource.Stop ();
			FallingFaltFormAudoSource.Play ();
			if (other.tag != "Path") {
				if (!LoadGameStatus) {
					gameOverTile = other.transform.gameObject;
					int gameOver = PlayerPrefs.GetInt (GameOver);
					Lifes ();
					Invoke ("LoadGame", 0.0f);
				}
			}
			
			
			
		}
		else if (other.transform.tag == "HangMoveForward") {
			playerRigidbody.useGravity = false;
			if (hangingState != 0)
				
				StartCoroutine (hangUp ());
		}
		else if (other.transform.tag == "TileStartFallDown") {
			TileStartFallDown = true;
			StartCoroutine (tileStartFallDownFalse ());
		}
		else if (other.transform.tag == "RockUp") {
			
			slideAnimStatus = true;
			backAnimStatus = true;
			StartCoroutine (RockUp ());
		}
		else if (other.transform.tag == "RockDown") {
			
			slideAnimStatus = true;
			backAnimStatus = true;
			StartCoroutine (RockDown ());
		}
		
		else if (other.transform.tag == "BackRestrict") {
			PlayerPrefs.SetInt (backRestrict, 1);
		}
		
		else if (other.transform.tag == "mashroom") {
			anim.SetTrigger ("HanuJumpForw");
			other.transform.gameObject.GetComponent<Animator> ().SetTrigger ("MuAnim");
			this.playerRigidbody.velocity = new Vector3 (0f, 20f, 0f);
			Invoke ("stopMushroomJump", 1f);
		}
		
		else if (other.transform.tag == "spring") {
			
			//anim.SetTrigger ("HanuJumpForw");
			//			TopHeadTouchAudoSource.clip = SpringTopTouchClip;
			//			TopHeadTouchAudoSource.Play ();
			StartCoroutine(Adiman_Sound(TopHeadTouchAudoSource,SpringTopTouchClip));
			other.transform.gameObject.GetComponent<Animator> ().SetTrigger ("SpringAnim");
			
			Invoke ("startspringAnim", 0.1f);
			Invoke ("stopspringJump", 0.8f);
			
			
		}
	}
	private void GetSplineOBJ(GameObject gobj){
		SplineController sc = gobj.GetComponent<SplineController>();
		//      sc.AutoStart = false;
		sc.enabled=true;
		//      sc.WrapMode = eWrapMode.LOOP;
		//      sc.FollowSpline ();
	}
	
	void disableShieldFast ()
	{
		//			Debug.Log ("GAMEOBJ *********************************" +obj);
		
		if (POWERTAG == "Heart") {
		} else if (POWERTAG == "FirstAid") {
		} else if (POWERTAG == "JetPack") {
			
			m_Character.JetPackStatus = false;
			Transform playerObj = playerRigidbody.gameObject.transform.GetChild (0).GetChild (0).GetChild (2).GetChild (1);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (false);
			//				disableJetPack(playerChildObj);
			playerChildObj.SetActive (false);
			m_Character.JetPackStatus = false;
			m_Character.JetPackHeightStatus = false;
			Physics.gravity = new Vector3 (0, -9.8f, 0);
			playerRigidbody.useGravity = true;
			GameObject gameObj = GameObject.FindGameObjectWithTag ("JETPACK BOTTOM");
			GameObject gameObj1 = GameObject.FindGameObjectWithTag ("JETPACK TOP");
			Destroy (gameObj);
			Destroy (gameObj1);
			powerupProgress.stopProgressBar ();
			JetPackAudoSource.Stop ();
			POWERTAG = "";
		} else if (POWERTAG == "HyperJump") {
			m_Character.hyperJumpStatus = false;
			Transform playerObj = playerRigidbody.gameObject.transform.GetChild (0).GetChild (0).GetChild (0).GetChild (0).GetChild (0).GetChild (0);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (false);
			Transform playerObj1 = playerRigidbody.gameObject.transform.GetChild (0).GetChild (0).GetChild (1).GetChild (0).GetChild (0).GetChild (0);
			GameObject playerChildObj1 = playerObj1.gameObject;
			playerChildObj1.SetActive (false);
			powerupProgress.stopProgressBar ();
		} else if (POWERTAG == "ForceField") {
			HanumanShieldActivateStatus = false;
			Transform playerObj = gameObject.transform.GetChild (4);
			//        GameObject playerChildObj = playerObj.GetChild(4);
			GameObject playerChildObj = playerObj.gameObject;
			playerChildObj.SetActive (false);
			powerupProgress.stopProgressBar ();
			//			ForceFieldAudoSource.Stop ();
			StartCoroutine(PlaypowerUpSound_STOP(ForceFieldAudoSource));
		}
	}
	
	IEnumerator disableShield (GameObject obj)
	{
		yield return new WaitForSeconds (20f);
		HanumanShieldActivateStatus = false;
		//		ForceFieldAudoSource.Stop ();
		StartCoroutine(PlaypowerUpSound_STOP(ForceFieldAudoSource));
		obj.SetActive (false);
		iSPowerUp = false;
		m_Character.hyperJumpStatus = false;
		powerupProgress.stopProgressBar ();
	}
	
	private void startspringAnim ()
	{
		this.playerRigidbody.velocity = new Vector3 (0f, 23.5f, 0f);
	}
	
//	private int restartInt = 0;
	
	void heartPowerUp (GameObject heart)
	{
		//			powerupProgress.stopProgressBar ();
		Destroy (heart);
	}
	
	void firstaidPowerUp (GameObject firstaid)
	{
		//			powerupProgress.stopProgressBar ();
		Destroy (firstaid);
	}
	
	void jetpackPowerUp (GameObject jetpack)
	{
		//			powerupProgress.startProgressBar ();
		Destroy (jetpack);
	}
	
	void hyerjumpPowerUp (GameObject hyerjump)
	{
		//			powerupProgress.startProgressBar ();
		Destroy (hyerjump);
	}
	
	void forcefieldPowerUp (GameObject forcefield)
	{
		//			powerupProgress.startProgressBar ();
		Destroy (forcefield);
	}
	
	public GameObject HealthPlus;
	public GameObject HealthPlusPositive;
	public GameObject HealthPlusFiveH;
	
	void gotoGameScene ()
	{
		//			if (restartInt == 0) {
		Handheld.Vibrate ();
		int HeathDec = Random.Range (15, 25);
		PlayerPrefs.SetFloat ("HEALTH", PlayerPrefs.GetFloat ("HEALTH") - 100);
		Lifes ();
	}
	
	void ShowHealth ()
	{
		
		GameObject HealthPlus_Gobj = (GameObject)Instantiate (HealthPlusFiveH, new Vector3 (this.playerRigidbody.position.x + 0.5f, this.playerRigidbody.position.y + 2.5f, this.playerRigidbody.position.z), Quaternion.identity);
		//			Invoke ("destroyPS", 1f);
		HealthPlus_Gobj.transform.Rotate (new Vector3 (0f, 0f, 0f));
		StartCoroutine (destroyHealthPS (HealthPlus_Gobj));
	}
	
	
	
	void LoadGame ()
	{
		
		disableShieldFast ();
		int FIGHTTAG=PlayerPrefs.GetInt ("FIGHTTAG");
		if(FIGHTTAG == 0){
			PlayerPrefs.SetInt (COINS,0);
		}
		
		
		
		
		Invoke ("ShowHealth", 4f);
		for (int i =0; i<5; i++) {
			Invoke ("gotoGameScene", 4f);
		}
		
		
		//			Debug.Log ("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ ::  "+TileManager.Instance.TotalTilesFinal.Count);
		
		StartCoroutine (DeleteTiles (0f));
		
		
		
		
		playerRigidbody.useGravity = true;
		playerRigidbody.drag = 2;
		LoadGameStatus = true;
		isPlatformZoom = true;
		gameOver = gameOverTile;
		Vector3 gameOverposition = gameOverTile.transform.position;
		GameObject gameOverEnd = (GameObject)Instantiate (new GameObject (), gameOverposition, Quaternion.identity);
		gameOverEnd.transform.SetParent (gameOver.transform);
		//			gameOverposition.x = gameOverposition.x - 35;
		//			gameOverposition.y = gameOverposition.y - 75;
		gameOverposition.x = playerRigidbody.position.x - 20;
		gameOverposition.y = playerRigidbody.position.y - 40;
		gameOverposition.z = playerRigidbody.position.z;
		GameObject gameOverEnd2 = (GameObject)Instantiate (new GameObject (), gameOverposition, Quaternion.identity);
		gameOverEnd2.transform.SetParent (gameOverEnd.transform);
		TileManager.Instance.currentTile = gameOver;
		TileManager.Instance.isFirstTile = true;
		TileManager.Instance.gapCount = 0;
		
		
		PlayerPrefs.SetInt ("BACKRESTRICKT", 100);
		//			PlayerPrefs.SetFloat ("AIMIII",0);
		
		//			for (int i = 0; i<5; i++) {
		//				PlayerPrefs.SetInt ("LoadgameEnemyPrevention",1);
		//				TileManager.Instance.SpawnTile ();
		//			}
		
		
		
		
		StartCoroutine (loadingBar_Load (1.5f));
		
		
//		if (TileManager.FIGHTTAG == 0) {

			Platform_Index=0;
			for (int i=0; i< 3; i++) {
				TileManager.Instance.SpawnTile ();
			}
			//				StartCoroutine(LoadStartingTiles());
			
			PlayerPrefs.SetInt ("UI_DESABLE", 2);
			
			StartCoroutine (LoadMore (2, 2f));
			
//			StartCoroutine (Wait_LoadMore (2, 7.5f));
			
			//
			
			
			
//		} else if (TileManager.FIGHTTAG == 1) {
//			//
//			
//			for (int i=0; i< 3; i++) {
//				TileManager.Instance.SpawnTile ();
//			}
//			//				StartCoroutine(LoadStartingTiles());
//			
//			PlayerPrefs.SetInt ("UI_DESABLE", 2);
//			StartCoroutine (LoadMore (2, 7f));
////			StartCoroutine (Wait_LoadMore (2, 7.5f));
//			
//		} else if (TileManager.FIGHTTAG == 2) {
//			
//			for (int i=0; i< 3; i++) {
//				TileManager.Instance.SpawnTile ();
//			}
//			PlayerPrefs.SetInt ("UI_DESABLE", 2);
//			StartCoroutine (LoadMore (2, 7f));
////			StartCoroutine (Wait_LoadMore (2, 7.5f));
//			
//		} else if (TileManager.FIGHTTAG == 3) {
//			
//			for (int i=0; i< 3; i++) {
//				TileManager.Instance.SpawnTile ();
//			}
//			PlayerPrefs.SetInt ("UI_DESABLE", 2);
//			StartCoroutine (LoadMore (2, 7f));
////			StartCoroutine (Wait_LoadMore (2, 7.5f));
//			
//		} else if (TileManager.FIGHTTAG == 4) {
//			
//			for (int i=0; i< 3; i++) {
//				TileManager.Instance.SpawnTile ();
//			}
//			PlayerPrefs.SetInt ("UI_DESABLE", 2);
//			StartCoroutine (LoadMore (2, 7f));
////			StartCoroutine (Wait_LoadMore (2, 7.5f));
//			
//		}
		Invoke ("setPlatZoom", 3f);
		//m_Character.falldownTag = true;
		
	}
	public IEnumerator DeleteTiles (float index)
	{
		yield return new WaitForSeconds (index);
		for (int i =TileManager.Instance.TotalTilesFinal.Count -1; i>=0; i--) {
			GameObject go = (GameObject)TileManager.Instance.TotalTilesFinal [i];
			TileManager.Instance.TotalTilesFinal.RemoveAt (i);
			//						DestroyObject(go);
			StartCoroutine (FallDown (go));
		}
		
	}
	
	IEnumerator  loadingBar_Load (float index)
	{
		yield return new WaitForSeconds (index);
		PlayerPrefs.SetInt ("UI_DESABLE", 2);
		PlayerPrefs.SetFloat ("loading_br", 0);
		istexture = true;
	}
	
	IEnumerator  DestroyLoader ()
	{
		yield return new WaitForSeconds (4f);
		PlayerPrefs.SetInt ("UI_DESABLE", 0);
		//			Destroy (loadingBar);
		
		
	}
	
	IEnumerator LoadStartingTiles ()
	{
		for (int i=0; i<3; i++) {
			yield return new WaitForSeconds (0.5f);
			TileManager.Instance.SpawnTile ();
			
		}
	}
	
	IEnumerator  Wait_LoadMore (int index, float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		for (int i=0; i< 28; i++) {
			StartCoroutine (LoadMore (2, 0.2f));
		}
	}
	
	public void  LM (int index, float waitTime)
	{
		TileManager.Instance.SpawnTile ();
		
		if(Platform_Index < TILESCOUNT)
			StartCoroutine (LoadMore (0, 0.2f));
	}
	
	private int Platform_Index=0;
	
	IEnumerator  LoadMore (int index, float waitTime)
	{
		Platform_Index = Platform_Index + 1;
//		if (TileManager.FIGHTTAG == 0 || TileManager.FIGHTTAG == 1 ||TileManager.FIGHTTAG == 2||TileManager.FIGHTTAG == 3||TileManager.FIGHTTAG == 4) {
			//				TileManager.Instance.First_Enenmy_Position_Main____ -index
			yield return new WaitForSeconds (waitTime);
			LM(index,waitTime);
			
			
			
//		} 
//		else if () {
//			//				TileManager.Instance.Second_Enenmy_Position_Main____ -index
//			yield return new WaitForSeconds (waitTime);
//			LM(index,waitTime);
//			
//		} else if () {
//			//				TileManager.Instance.Third_Enenmy_Position_Main____ -index
//			yield return new WaitForSeconds (waitTime);
//			LM(index,waitTime);
//			
//		} else if () {
//			//				TileManager.Instance.Fourth_Enenmy_Position_Main____ -index
//			yield return new WaitForSeconds (waitTime);
//			LM(index,waitTime);
//			
//		} else if () {
//			//				TileManager.Instance.Fifth_Enenmy_Position_Main____ -index
//			yield return new WaitForSeconds (waitTime);
//			LM(index,waitTime);
//			
//		}
		
		
	}
	
	
	void setPlatZoom ()
	{
		diffInDistance = playerRigidbody.transform.position.magnitude;
		PlayerPrefs.SetInt ("LoadgameEnemyPrevention", 0);
		Invoke ("LoadGameFalse", 3f);
		isPlatformZoom = false;
		m_Character.falldownTag = true;
	}
	
	void LoadGameFalse ()
	{
		playerRigidbody.drag = 0;
		LoadGameStatus = false;
	}
	
	void OnTriggerStay (Collider other)
	{
		//			if (other.transform.tag == "Water") {
		//				//				Debug.Log("Water");
		//				m_Character.swimStatus = true;
		//				anim.SetBool ("HanuSwim", true);
		//			}
		if (other.tag == "PathRemoval")
			return;
		if (other.transform.tag == "RockUp") {
			
			slideAnimStatus = true;
			backAnimStatus = true;
			isRock = true;
		}
		if (other.transform.tag == "RockDown") {
			
			slideAnimStatus = true;
			backAnimStatus = true;
			isRock = true;
		}
		if (other.transform.tag == "BackRestrict") {
			PlayerPrefs.SetInt (backRestrict, 1);
		}
		
	}
	
	IEnumerator RockUp ()
	{
		if (!isFirstTile) {
			if (!isRock) {
				isRock = true;
				Vector3 position = playerRigidbody.position;
				yield return new WaitForSeconds (.2f);
				
				position.x = position.x;
				position.y = position.y + 15;
				position.z = -1;
				//				Debug.Log (position);
				GameObject smallEnemyObj = (GameObject)Instantiate (rock, position, Quaternion.identity);
				yield return new WaitForSeconds (6f);
				smallEnemyObj.SetActive (false);
				
			}
		} else {
			yield return new WaitForSeconds (5f);
			isFirstTile = false;
		}
	}
	
	IEnumerator RockDown ()
	{
		if (!isRock) {
			isRock = true;
			//			yield return new WaitForSeconds(.5f);
			Vector3 position = playerRigidbody.position;
			yield return new WaitForSeconds (.2f);
			
			position.x = position.x + 30;
			position.y = position.y + 15;
			position.z = -1;
			//			Debug.Log(position);
			GameObject smallEnemyObj = (GameObject)Instantiate (backwardRollingRock, position, Quaternion.identity);
			yield return new WaitForSeconds (6f);
			smallEnemyObj.SetActive (false);
			
		}
	}
	
	IEnumerator hangUpX ()
	{
		//		Debug.Log ("hangUpX");
		//yield return new WaitForSeconds(0.3f);
		anim.SetTrigger ("Hang");
		hangingState = 1;
		yield return new WaitForSeconds (.3f);
		hangingState = 2;
	}
	
	IEnumerator fallDownFalse ()
	{
		yield return new WaitForSeconds (.3f);
		fallDown = false;
		//		anim.SetBool("IsWalking", true);
	}
	
	IEnumerator tileStartFallDownFalse ()
	{
		yield return new WaitForSeconds (.3f);
		TileStartFallDown = false;
		//		anim.SetBool("IsWalking", true);
	}
	
	IEnumerator isTriggerFalse (BoxCollider isTriggerFalseC)
	{
		yield return new WaitForSeconds (0.6f);
		isTriggerFalseC.isTrigger = true;
	}
	
	IEnumerator coinStatusFalse ()
	{
		yield return new WaitForSeconds (1f);
		coinStatus = false;
	}
	
	IEnumerator jumpAction ()
	{
		//		Debug.Log ("jumpingState");
		anim.SetTrigger ("jump1");
		yield return new WaitForSeconds (.3f);
		jumpingState = 1;
		anim.SetTrigger ("jump2");
		yield return new WaitForSeconds (.4f);
		jumpingState = 2;
		yield return new WaitForSeconds (.15f);
		if (crossJump)
			yield return new WaitForSeconds (.1f);
		anim.SetTrigger ("jump3");
		yield return new WaitForSeconds (.1f);
		jumpingState = 0;
		anim.SetTrigger ("jump4");
		yield return new WaitForSeconds (.5f);
		jump = true;
		yield return new WaitForSeconds (0f);
	}
	
	
	
	void OnTriggerExit (Collider other)
	{
		
		//		if (other.gameObject.name == "b1" ||
		//		    other.gameObject.name == "b11" ||
		//		    other.gameObject.name == "b111" ||
		//		    other.gameObject.name == "b2" ||
		//		    other.gameObject.name == "b21" ||
		//		    other.gameObject.name == "b3" ||
		//		    other.gameObject.name == "b31" ||
		//		    other.gameObject.name == "b32" ||
		//		    other.gameObject.name == "b4" ||
		//		    other.gameObject.name == "b41" ||
		//		    other.gameObject.name == "b42" ||
		//		    other.gameObject.name == "b51" ||
		//		    other.gameObject.name == "b52" ||
		//		    other.gameObject.name == "b53" ||
		//		    other.gameObject.name == "b54" ||
		//		    other.gameObject.name == "b61" ||
		//		    other.gameObject.name == "b62" ||
		//		    other.gameObject.name == "b63" ||
		//		    other.gameObject.name == "b71" ||
		//		    other.gameObject.name == "b72" ||
		//		    other.gameObject.name == "b73") {
		//			
		//			if(MoveUpCubeTag){
		//				//Destroy(MoveUpCube1);
		//				MoveUpCubeTag1 = true;
		//				MoveUpCubeTag = false;
		//			}
		//		}
		
		if(other.gameObject.tag == "cartMoveTag"){
			transform.eulerAngles = euler0;
		}
		
		if (other.transform.tag == "StoneFallDown") {
			//				StartCoroutine(StoneFallDown(other.transform.gameObject));
			if (other.gameObject.name == "part_11") {
				StartCoroutine (StopFallDownBridgeSound ());
			}
		}
		
		//			if (other.transform.tag == "Water") {
		//				//				Debug.Log("Water");
		//				m_Character.swimStatus = false;
		//				anim.SetBool ("HanuSwim", false);
		//			}
		if (other.transform.tag == "SwimUp") {
			if (m_Character.swimStatus) {
				//					Debug.Log("SwimUp");
				m_Character.swimUpStatus = false;
				anim.SetBool ("HanuSwim", false);
			}
		}
		if (other.tag == "PathRemoval")
			return;
		if (other.transform.tag == "Xaxis") {
			ZoomOut ();
		}
		if (other.transform.tag == "StopSlid") {
			m_Character_User_Ctrl.SlidingStatus = false;
		}
		if (other.transform.tag == "Tree") {
			//			Debug.Log("Tree");
			moveDirection = 0;
			other.transform.GetComponent<Collider> ().isTrigger = false;
		}
		if (other.transform.tag == "RockUp") {
			
			slideAnimStatus = false;
			backAnimStatus = false;
			isRock = false;
		}
		if (other.transform.tag == "RockDown") {
			
			slideAnimStatus = false;
			backAnimStatus = false;
			isRock = false;
		}
		if (other.transform.tag == "BackRestrict") {
			
			PlayerPrefs.SetInt (backRestrict, 0);
		}
	}
	
	IEnumerator hangUp ()
	{
		//		yield return new WaitForSeconds (.1f);
		//		hangingState = 3;
		playerRigidbody.velocity = Vector3.zero;
		//		yield return new WaitForSeconds (.15f);
		hangingState = 4;
		yield return new WaitForSeconds (.0f);
		hangingState = 5;
		yield return new WaitForSeconds (.2f);
		hangingState = 0;
		playerRigidbody.useGravity = true;
	}
	
	IEnumerator rollForward ()
	{
		anim.SetTrigger ("rollForward");
		yield return new WaitForSeconds (0.5f);
		rollForstate = 1;
		yield return new WaitForSeconds (0.1f);
		rollForstate = 0;
	}
	
	IEnumerator rollback ()
	{
		anim.SetTrigger ("rollBackward");
		yield return new WaitForSeconds (0.5f);
		rollstate = 1;
		yield return new WaitForSeconds (0.1f);
		rollstate = 0;
		
	}
	
	IEnumerator moveback ()
	{
		anim.SetTrigger ("IsMoveBack");
		yield return new WaitForSeconds (0.5f);
		rollstate = 1;
		yield return new WaitForSeconds (0.1f);
		rollstate = 0;
		
	}
	
	void coinSetFalse ()
	{
		coinMove = 0;
		for (int i=0; i<3; i++) {
			coins [i].SetActive (false);
		}
	}
	
	void upJumping ()
	{
		if (JumpSate == 1) {
			Vector3 movement = new Vector3 (35.0f, 100.0f, 0.0f);
			playerRigidbody.AddForce (movement * speed);
		} else if (JumpSate == 2) {
			Vector3 movement = new Vector3 (-35.0f, 100.0f, 0.0f);
			playerRigidbody.AddForce (movement * speed);
		} else {
			Vector3 movement = new Vector3 (0.0f, 120.0f, 0.0f);
			playerRigidbody.AddForce (movement * speed);
		}
	}
	
//	void stopJumping ()
//	{
//		slidingstate = 0;
//		jumpOnce = false;
//		backRollStatus = false;
//		Mjump = 0;
//	}
	
	void downJumping ()
	{
		if (JumpSate == 1) {
			Vector3 movement = new Vector3 (35.0f, -150.0f, 0.0f);
			playerRigidbody.AddForce (movement * speed);
		} else if (JumpSate == 1) {
			Vector3 movement = new Vector3 (-35.0f, -150.0f, 0.0f);
			playerRigidbody.AddForce (movement * speed);
		} else {
			Vector3 movement = new Vector3 (0.0f, -170.0f, 0.0f);
			playerRigidbody.AddForce (movement * speed);
		}
	}
	
	void stopMjump ()
	{
		
		Mjump = 2;
	}
	
	private int LIFE_INDEX = 0;
	
	IEnumerator TextColorChange ()
	{
		yield return new WaitForSeconds (0.2f);
		Life.color = Color.white;
		yield return new WaitForSeconds (0.2f);
		Life.color = Color.red;
		yield return new WaitForSeconds (0.2f);
		Life.color = Color.white;
		yield return new WaitForSeconds (0.2f);
		Life.color = Color.red;
		
	}
	
	void Lifes ()
	{
		
		if (LIFE_INDEX == 0) {
			//			LIFE_INDEX=LIFE_INDEX+1;
			if (Lankacount != 0)
				PlayerPrefs.SetFloat ("AIMIII", Lankacount);
			PlayerPrefs.SetInt (COINS, count);
			
			//			Instantiate (ps,coinText.transform.position, Quaternion.identity);
			int gameOver = PlayerPrefs.GetInt (GameOver);
			if (gameOver == 0 && PlayerPrefs.GetFloat ("HEALTH") <= 0) {
				// Life.text="Life : 2";
				PlayerPrefs.SetInt (GameOver, 1);
				PlayerPrefs.SetFloat ("HEALTH", 500);
			}
			if (gameOver == 1 && PlayerPrefs.GetFloat ("HEALTH") <= 0) {
				// Life.text="Life : 2";
				PlayerPrefs.SetInt (GameOver, 2);
				PlayerPrefs.SetFloat ("HEALTH", 500);
			}
			
			
			if (gameOver == 2 && PlayerPrefs.GetFloat ("HEALTH") <= 0) {
				// Life.text="Life : 1";
				PlayerPrefs.SetInt (GameOver, 3);
				gameOver = 3;
				PlayerPrefs.SetFloat ("HEALTH", 500);
			}
			if (gameOver != 3)
				gameOver = PlayerPrefs.GetInt (GameOver);
			if (gameOver == 0) {
				Life.text = "3";
				StartCoroutine (TextColorChange ());
				// PlayerPrefs.SetInt (GameOver,3);
			}
			
			if (gameOver == 1) {
				Life.text = "2";
				StartCoroutine (TextColorChange ());
				// PlayerPrefs.SetInt (GameOver,3);
			}
			
			if (gameOver == 2) {
				Life.text = "1";
				StartCoroutine (TextColorChange ());
				// PlayerPrefs.SetInt (GameOver,3);
			}
			
			
			if (gameOver == 3) {
				//					int gameOver = PlayerPrefs.GetInt (GameOver);
				
				if (gameOver == 3) {
					PlayerPrefs.SetInt("LBSocketCall",1);
					PlayerPrefs.SetInt ("UARMR", 0);
					//						Application.LoadLevel ("gameOver");
					//					PlayerPrefs.SetInt("isGui",1);
					if(PlayerPrefs.GetInt("isWaiting") == 0){
						if (lifeover == null)
							lifeover = (GameObject)Instantiate (lifeoverPopup, new Vector3 (0f, 0f, 0f), Quaternion.identity);
						//						Time.timeScale=0;
						//						UI_DESABLE = false;
						//						PlayerPrefs.SetInt ("UI_DESABLE", 1);
						//						PlayerPrefs.SetInt ("isGui", 1);
						WaitAgain wg = new WaitAgain ();
						wg.OnPauseGame ();
						try{
							disableShieldFast ();
						}catch{
							
						}
					}
				} else {
					PlayerPrefs.SetInt (GameOver, 0);
					Application.LoadLevel ("DynamicPath");
				}
				
				
			}
		}
		
	}
	
	public GameObject lifeoverPopup;
	private GameObject lifeover;
	
	public void SaveData ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream fs = File.Open (Application.persistentDataPath + "/playerdata.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
		PlayerData pd = new PlayerData ();
		pd.AIM = 100000 - Lankacount;
		pd.DISTANCE = Lankacount;
		bf.Serialize (fs, pd);
		fs.Close ();
	}
	
	public PlayerData Load ()
	{
		
		if (File.Exists (Application.persistentDataPath + "/playerdata.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = File.Open (Application.persistentDataPath + "/playerdata.dat", FileMode.Open);
			PlayerData Player_pd = (PlayerData)bf.Deserialize (fs);
			//			Debug.Log (Player_pd.AIM + " : " + Player_pd.DISTANCE);
			return Player_pd;
		} else {
			
			return new PlayerData ();
		}
		
	}
	
	void startSliding ()
	{
		slidingstate = 1;
	}
	
	void stopspringJump ()
	{
		
		if (mushposition == 1) {
			
			this.playerRigidbody.velocity += new Vector3 (10f, -5f, 0f);
		}
		if (mushposition == 2) {
			
			this.playerRigidbody.velocity += new Vector3 (0f, 0f, 0f);
		}
	}
	
	void stopMushroomJump ()
	{
		
		//this.playerRigidbody.velocity += new Vector3 (20f,-10f,0f);
		
		if (mushposition == 1) {
			
			this.playerRigidbody.velocity += new Vector3 (-1f, 0f, 0f);
		}
		if (mushposition == 2) {
			
			this.playerRigidbody.velocity += new Vector3 (-13f, -3f, 0f);
		}
	}
	
	void BlastCoins (Collider other)
	{
		coinTossValue = 0;
		float diff = 0.0f;
		//		int random = Random.Range (5, 10);
		int random_Coin_Banana = Random.Range (0, 2);
		IsCoin = (random_Coin_Banana == 0);
		if(IsCoin)
		{
			int coinCount = PlayerPrefs.GetInt("coinRandom");
			coinRandom = Random.Range(5,11);
			coinCount = coinCount+coinRandom;
			PlayerPrefs.SetInt("coinRandom",coinCount);
			random = coinRandom;
		}
		else{
			int bananaCount = PlayerPrefs.GetInt("bananaRandom");
			bananaRandom = Random.Range(5,11);
			bananaCount = bananaCount+bananaRandom;
			PlayerPrefs.SetInt("bananaRandom",bananaRandom);
			random = bananaRandom;
		}
		for (int i=0; i<random; i++) {
			diff += 0.1f;
			Invoke ("createSignleCoin", diff);
		}
	}
	
	

	private void enableEnmyMotion(GameObject gameObject){
		Transform[] ts = gameObject.transform.GetComponentsInChildren<Transform> (true);
		foreach (Transform t in ts) {
			
		
			try {
				if (t.gameObject.name == "bear_claw(Clone)") {
					t.gameObject.GetComponent<SmallSoldierBehaviour> ().enabled = true;
				}
			} catch {
	
			}

			try {
				if (t.gameObject.name == "level3robot(Clone)") {
					t.gameObject.GetComponent<SmallSoldierBehaviour> ().enabled = true;
		
				}
			} catch {
	
			}

			try {
				if (t.gameObject.name == "LevelIIIFMan2 (3)(Clone)") {
					t.gameObject.GetComponent<SmallSoldierBehaviour> ().enabled = true;

				}

			} catch {
	
			}

			try {
				if (t.gameObject.name == "Red_Mny_02_Prefab(Clone)") {
					t.gameObject.GetComponent<SmallSoldierBehaviour> ().enabled = true;

				}
			} catch {
				
			}
			try {
				if (t.gameObject.name == "Bee_Prefab(Clone)") {
					t.gameObject.GetComponent<SmallSoldierBehaviour> ().enabled = true;
				}
			} catch {

			}
			try {
				if (t.gameObject.name == "Bat Anim 4(Clone)") {
					t.gameObject.GetComponent<SmallSoldierBehaviour> ().enabled = true;
				}
			} catch {
				
			}
		
		}

}

}

[System.Serializable]
public class PlayerData
{
	public float AIM;
	public float DISTANCE;
}
//}