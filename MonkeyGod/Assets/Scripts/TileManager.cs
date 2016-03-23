using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/*
	* @@ QUANTUMLEAP_HANUMAN_GAME @@
	*
	* I.:TileManager: For Creating Dynamic Tiles (i.e Platform Creation.)
	* II.Also Showing enemies at on avg. of 4000-5000 m.
	* III.5 TILES 300 M.
	* IV.Hnadling PowerUps at middle of the gameScene.
	*
	*/


public class TileManager : MonoBehaviour {
	
	public GameObject[] LEVELONEPREFABS,LEVELIIPREFABS,LEVEL3PREFABS;

	private GameObject[] temp_level2_enemy_arr,temp_level1_prefb_arr;
	public GameObject[] LEVELONE_ENEMIESARRAY,LEVELII_ENEMIESARRAY,LEVEL3_ENEMIESARRAY;

	private int prevRandomTile = 0;
	public int gapCount = 0;
	public static int FIGHTTAG=0;
	bool isFirstPowerUp = false;
	private int TilesCount;
	private GameObject mygameobject;
	public bool isFirstTile = true;
//	public GameObject[] smallEnemy;

	private Vector3 position,bg_position;

	
	public static int IDEAL = 0;


//	public Text LankText;
	public GameObject OverheadBox;
	public GameObject[] level3EnemyArray;


	Animator anim;

	Vector3 smallenemymovement;
	public  GameObject currentTile;


	private static TileManager instance;
	
	
	private int currentTileNumber;
	

	public Stack<GameObject> leftTiles=new Stack<GameObject>();
	public ArrayList leftTilesFinal = new ArrayList ();
	public ArrayList TotalTilesFinal = new ArrayList ();
	
	public int First_Enenmy_Position_Main____ = 17;
	public int Second_Enenmy_Position_Main____ = 17;
	public int Third_Enenmy_Position_Main____ = 17;
	public int Fourth_Enenmy_Position_Main____ = 17;
	public int Fifth_Enenmy_Position_Main____ = 17;
	
	
	private int F_F_T_N=0;
	private int S_F_T_N=1;
	private int T_F_T_N=2;
	private int FO_F_T_N=3;
	private int FIF_F_T_N=4;
	
	public static  string TILESCOUNT="TILESCOUNT";
	private bool isTileCreated = false;
	private int powerUpCount = 0;
	private GameObject powerUpObj;
	public GameObject[] powerUpsArray;
	public ArrayList BackGroundleftTilesFinal = new ArrayList ();

	public GameObject currentTile1;
	private bool IstransformError=false;
	private int Diamond_Display__Int = 0,random_bg;

	public GameObject bat_anim_obj;
	
	public GameObject[] LEVEL3_BG_PREFABS;
	
	
	
	//Creating TileManager instance to communicate with Other calsses ..
	public static TileManager Instance {
		get {
			if(instance == null)
			{
				instance=GameObject.FindObjectOfType<TileManager>();
			}
			return instance;
		}
	}
	
	/*
	 * FIGHTTAG is the key to know Hanuman to face Fights
	 * (i.e Hanuman to face 1st Fight or 2nd one or 3rd One or 4th or 5th)
	 * If FIGHTTAG is 0 , Hanuman will face 1st Fight at some distance
	 */
	
	void Start () {

		GameObject thePlayer = GameObject.Find("H T_P F R_Prefab");
		playerBehaviour playerScript1 = thePlayer.GetComponent<playerBehaviour>();
		First_Enenmy_Position_Main____ = playerScript1.TILESCOUNT;
		Second_Enenmy_Position_Main____ = playerScript1.TILESCOUNT;
		Third_Enenmy_Position_Main____ = playerScript1.TILESCOUNT;
		Fourth_Enenmy_Position_Main____ = playerScript1.TILESCOUNT;
		Fifth_Enenmy_Position_Main____ = playerScript1.TILESCOUNT;
		
		//		PlayerPrefs.SetInt ("Diamond_Display__Int", 0);
		//		if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELII")) {
		//			LEVELONEPREFABS=new GameObject[LEVELIIPREFABS.Length];
		//			for(int i =0;i<LEVELONEPREFABS.Length;i++){
		//				LEVELONEPREFABS[i]=LEVELIIPREFABS[i];
		//			}
		//		}
		
		PlayerPrefs.SetInt("JetPackStatus",0);
		instance=GameObject.FindObjectOfType<TileManager>();
		FIGHTTAG=PlayerPrefs.GetInt ("FIGHTTAG");

		mygameobject = new GameObject ();
	}
	
	public void level1Prefabs(){
		try{
			//			GameObject level2_stat_prfb = GameObject.Find ("land7_prefab");
			//			level2_stat_prfb.SetActive(false);
			//			GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();
			//			foreach (GameObject go in allObjects)
			//			if (go.transform.name .Contains ("Start (1)") || go.transform.name .Contains ("Start")) {
			//				go.SetActive (true);
			PlayerPrefs.SetString("LEVEL","LEVELI");
			//			}
			GameObject level2_stat_prfb = GameObject.Find ("land3_prefab");
			currentTile = level2_stat_prfb;
			//			//			GameObject start1 = GameObject.Find ("Start (1)");
			//			currentTile = start1;
			if(temp_level1_prefb_arr.Length != 0){
				GameObject thePlayer = GameObject.Find("H T_P F R_Prefab");
				playerBehaviour playerScript1 = thePlayer.GetComponent<playerBehaviour>();
				playerScript1.StartCoroutine(playerScript1.DeleteTiles(0f));
				LEVELONEPREFABS = temp_level1_prefb_arr;
				//				GameObject start1_1 = GameObject.Find ("Start (1)");
				//				currentTile = start1_1;
				playerScript1.isLevelCreated = false;
				
				LEVELONE_ENEMIESARRAY = temp_level2_enemy_arr;
				
				
			}else{}
			//	level2_stat_prfb.SetActive (false);
		}
		catch(System.Exception e){}
	}
	
	public void level2Prefabs(){
		PlayerPrefs.SetString("LEVEL","LEVELII");
		if (PlayerPrefs.GetString ("LEVELTILESCREATED").Equals ("YES")) {
			if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELII")) {
				GameObject level2_stat_prfb = GameObject.Find ("land3_prefab");
				currentTile = level2_stat_prfb;
				////				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();
				//				foreach (GameObject go in allObjects)
				//					if (go.transform.name .Contains ("Start (1)") || go.transform.name .Contains ("Start")) {
				//						go.SetActive (false);
				//					}
				//				GameObject thePlayer = GameObject.Find("H T_P F R_Prefab");
				//				playerBehaviour playerScript1 = thePlayer.GetComponent<playerBehaviour>();
				//				playerScript1.StartCoroutine(playerScript1.DeleteTiles(0f));
				temp_level1_prefb_arr = LEVELONEPREFABS;
				LEVELONEPREFABS = new GameObject[LEVELIIPREFABS.Length];
				for (int i =0; i<LEVELONEPREFABS.Length; i++) {
					LEVELONEPREFABS [i] = LEVELIIPREFABS [i];
				}
				temp_level2_enemy_arr = LEVELONE_ENEMIESARRAY;
				LEVELONE_ENEMIESARRAY = LEVELII_ENEMIESARRAY;
			}else{
				
			}
		}
	}

	public void level3Prefabs(){
		PlayerPrefs.SetString("LEVEL","LEVELIII");
		if (PlayerPrefs.GetString ("LEVELTILESCREATED").Equals ("YES")) {
			if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELIII")) {
				GameObject level2_stat_prfb = GameObject.Find ("land3_prefab");
//				GameObject level2_stat_prfb_bg = GameObject.Find ("land3_prefab (1)");
				currentTile = level2_stat_prfb;
//				currentTile1 = level2_stat_prfb_bg;
				////				GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();
				//				foreach (GameObject go in allObjects)
				//					if (go.transform.name .Contains ("Start (1)") || go.transform.name .Contains ("Start")) {
				//						go.SetActive (false);
				//					}
				//				GameObject thePlayer = GameObject.Find("H T_P F R_Prefab");
				//				playerBehaviour playerScript1 = thePlayer.GetComponent<playerBehaviour>();
				//				playerScript1.StartCoroutine(playerScript1.DeleteTiles(0f));
				temp_level1_prefb_arr = LEVELONEPREFABS;
				LEVELONEPREFABS = new GameObject[LEVEL3PREFABS.Length];
				for (int i =0; i<LEVELONEPREFABS.Length; i++) {
					LEVELONEPREFABS [i] = LEVEL3PREFABS [i];
				}
				temp_level2_enemy_arr = LEVELONE_ENEMIESARRAY;
				LEVELONE_ENEMIESARRAY = LEVEL3_ENEMIESARRAY;
			}else{
				
			}
		}
	}


	private IEnumerator level3Enemy(Vector3 position)
	{
		int enemyRandom = Random.Range(0,level3EnemyArray.Length);
//		enemyRandom = 4;
		powerUpObj = (GameObject)Instantiate (level3EnemyArray [enemyRandom], position, Quaternion.identity);
		powerUpObj.gameObject.transform.SetParent (currentTile.transform);
		powerUpObj.transform.rotation = Quaternion.Euler(0,-90,0);
//		switch(enemyRandom)
//		{
//
//		case 0 :
//
//			break;
//		case 1 :
//
//
//			break;
//		case 2 :
//
//			break;
//		case 3 :
////			powerUpObj.transform.position= new Vector3 (this.powerUpObj.transform.position.x, this.powerUpObj.transform.position.y+4f, this.powerUpObj.transform.position.z);
//
//			break;
//		case 4 :
//
//			break;
//		case 5:
//
//			break;
//
//		default :
//			break;
//		}
		yield return null;
	}
	
	/*
	 * @@ SpawnTile @@
	 * the fn which can do the dynamic creation of TILES;
	 */
	public void SpawnTile(){
		StartCoroutine(SpawnTile1 ());
	}
	IEnumerator disableJetPackWhileCreatingPts(){
		yield return new WaitForSeconds (1f);
		PlayerPrefs.SetInt("JetPackStatus",0);
	}
	
	private void PowerUps(Vector3 position){
		powerUpCount++;
		int powerUpRandom;
		if (powerUpCount % 100 == 0)
			powerUpRandom = 0;
		else
			powerUpRandom = Random.Range(1,powerUpsArray.Length);
		if ( !isFirstPowerUp) {
			if(FIGHTTAG == 1 || FIGHTTAG == 3)
				powerUpRandom = 2;
			else
			{
				if(powerUpRandom == 2){
					powerUpRandom=1;
				}
			}
		}
		if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELII") || PlayerPrefs.GetString ("LEVEL").Equals ("LEVELIII")) {
			if (powerUpRandom == 2) {
				powerUpRandom = Random.Range(3,powerUpsArray.Length);
			}
		}
				powerUpRandom = 2;
		powerUpObj = (GameObject)Instantiate (powerUpsArray [powerUpRandom], position, Quaternion.identity);
		powerUpObj.gameObject.transform.SetParent (currentTile.transform);
		isFirstPowerUp = true;
	}

	IEnumerator BGcreation(int random){
		yield return new WaitForSeconds (0.2f);
		bg_position = currentTile1.transform.GetChild (0).transform.GetChild (0).position;
//		if (gapCount < 8) {
			if (currentTile.gameObject.name != "red_enemy_prefab(Clone)") {
				currentTile1 = (GameObject)Instantiate (LEVEL3_BG_PREFABS [random], bg_position, Quaternion.identity);
				currentTile1.gameObject.transform.SetParent (currentTile.transform);
			}
//		}

	}

	IEnumerator SpawnTile1(){
		yield return new WaitForSeconds (0f);
		gapCount=gapCount+1;
		if (gapCount % 40 == 0) {
			PlayerPrefs.SetInt (TILESCOUNT,gapCount);
		} else {
		}

//		Debug.Log ("TC : "+gapCount);

		//		int randomTile;
		//		try{
		position = currentTile.transform.GetChild (0).transform.GetChild (0).position;
		int randomTile = Random.Range (0, LEVELONEPREFABS.Length);
		random_bg = Random.Range (0, LEVEL3_BG_PREFABS.Length);
		if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELIII")) {
			StartCoroutine (BGcreation (random_bg));
		}
		//		}
		//		catch{
		//		}
		
		
		/*
		 * isTileCreated bool verifies or checks Whether Tile is craeted or Not.
		 */
		
		isTileCreated = false;
		
		/*
		 * LoadgameEnemyPrevention is the key for PlayerPrefs UNITY
		 * which is used for not craeting the Tiles while Hanuman falling from platform.
		 */
		
		int LoadgameEnemyPrevention=PlayerPrefs.GetInt ("LoadgameEnemyPrevention");
		if (LoadgameEnemyPrevention == 0) {
			
			/*
			 * If FIGHTTAG is 0 , 1st enemy position Occures..
			 * FIGHTTAGBOOL is the key which is used for wheather fight is won or lost..
			 * if FIGHTTAGBOOL is 1 Hanuman defeated by enemy.we need to play again.
			 */
			
			if (FIGHTTAG == 0) {
				int Fightabc = PlayerPrefs.GetInt ("FIGHTTAGBOOL");
				if (Fightabc == 100 && gapCount == 2) {
					PlayerPrefs.SetInt ("1stF", 1);
					isTileCreated = true;
					currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [F_F_T_N], position, Quaternion.identity);
					randomTile =30;
					IDEAL = 100;
				}
				if (!isTileCreated) {
					if (gapCount % First_Enenmy_Position_Main____ == 0) {
						PlayerPrefs.SetInt ("1stF", 1);
						isTileCreated = true;
						currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [F_F_T_N], position, Quaternion.identity);
						randomTile =30;
						IDEAL = 100;
					}
				}
			}
			
			
			/*
			 * If FIGHTTAG is 1, 2nd enemy position Occures..
			 */
			if (FIGHTTAG == 1) {
				int Fightabc = PlayerPrefs.GetInt ("FIGHTTAGBOOL");
				if (Fightabc == 100 && gapCount == 2) {
					IDEAL = 1;
					PlayerPrefs.SetInt ("2ndF", 1);
					isTileCreated = true;
					currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [S_F_T_N], position, Quaternion.identity);
				}
				if (!isTileCreated) {
					if (gapCount % Second_Enenmy_Position_Main____ == 0) {
						IDEAL = 1;
						PlayerPrefs.SetInt ("2ndF", 1);
						isTileCreated = true;
						currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [S_F_T_N], position, Quaternion.identity);
					}
				}
			}
			
			
			/*
			 * If FIGHTTAG is 2, 3rd enemy position Occures..
			 */
			if (FIGHTTAG == 2) {
				int Fightabc = PlayerPrefs.GetInt ("FIGHTTAGBOOL");
				if (Fightabc == 100 && gapCount == 2) {
					IDEAL = 2;
					PlayerPrefs.SetInt ("3rdF", 1);
					isTileCreated = true;
					currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [T_F_T_N], position, Quaternion.identity);
				}
				if (!isTileCreated) {
					if (gapCount % Third_Enenmy_Position_Main____ == 0) {
						IDEAL = 2;
						PlayerPrefs.SetInt ("3rdF", 1);
						isTileCreated = true;
						currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [T_F_T_N], position, Quaternion.identity);
					}
				}
			}
			
			
			/*
			 * If FIGHTTAG is 3, 4th enemy position Occures..
			 */
			if (FIGHTTAG == 3) {
				int Fightabc = PlayerPrefs.GetInt ("FIGHTTAGBOOL");
				if (Fightabc == 100 && gapCount == 2) {
					IDEAL = 3;
					PlayerPrefs.SetInt ("4thF", 1);
					currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [FO_F_T_N], position, Quaternion.identity);
					isTileCreated = true;
				}
				if (!isTileCreated) {
					if (gapCount % Fourth_Enenmy_Position_Main____ == 0) {
						IDEAL = 3;
						PlayerPrefs.SetInt ("4thF", 1);
						isTileCreated = true;
						currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [FO_F_T_N], position, Quaternion.identity);
					}
				}
			}
			
			/*
			 * If FIGHTTAG is 4, 4th enemy position Occures..
			 */
			if (FIGHTTAG == 4) {
				int Fightabc = PlayerPrefs.GetInt ("FIGHTTAGBOOL");
				if (Fightabc == 100 && gapCount == 2) {
					IDEAL = 3;
					PlayerPrefs.SetInt ("5thF", 1);
					isTileCreated = true;
					currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [FIF_F_T_N], position, Quaternion.identity);
				}
				if (!isTileCreated) {
					if (gapCount % Fifth_Enenmy_Position_Main____ == 0) {
						IDEAL = 3;
						PlayerPrefs.SetInt ("5thF", 1);
						isTileCreated = true;
						currentTile = (GameObject)Instantiate (LEVELONE_ENEMIESARRAY [FIF_F_T_N], position, Quaternion.identity);
					}
				}
			}
		}
		int randomDistancex = 0;
		int randomDistancey = 0;
		if (TilesCount == 0) {
			TilesCount=PlayerPrefs.GetInt (TILESCOUNT);
		}
		
		
		/*
		 * 2nd AND 3rd Tiles Static Placement..
		 * If Hanuman won the Fight , Increasing Adimanav frequency..
		 */
		int Fightabccc = PlayerPrefs.GetInt ("FIGHTTAGBOOL");
		if(Fightabccc !=100)
		{
			if(gapCount == 2){
				randomTile=1;
				currentTile = (GameObject)Instantiate (LEVELONEPREFABS [1], position, Quaternion.identity);
				isTileCreated=true;
			}
			if(gapCount == 3 ){
				randomTile=2;
				currentTile = (GameObject)Instantiate (LEVELONEPREFABS [2], position, Quaternion.identity);
				isTileCreated=true;
			}
			if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELII")) {
//						if(gapCount == 25 ){
//							randomTile=1;
//							currentTile = (GameObject)Instantiate (LEVELONEPREFABS [1], position, Quaternion.identity);
//							isTileCreated=true;
//						}
//						if(gapCount == 5 ){
//							randomTile=2;
//							currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
//							isTileCreated=true;
//						}
//						if(gapCount == 6 ){
//							randomTile=2;
//							currentTile = (GameObject)Instantiate (LEVELONEPREFABS [5], position, Quaternion.identity);
//							isTileCreated=true;
//						}
						}
			if(FIGHTTAG == 2)
			{
				if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI"))
				{
				if(gapCount == 6 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
				if(gapCount == 9 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
			}
			}
			else if(FIGHTTAG == 3)
			{
				if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI"))
				{
				if(gapCount == 5 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
				if(gapCount == 8 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
				if(gapCount == 11 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
				}
			}
			else if(FIGHTTAG == 4)
			{
				if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI"))
				{
				if(gapCount == 4 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
				if(gapCount == 7 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
				if(gapCount == 10 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
				if(gapCount == 14 ){
					randomTile=4;
					currentTile = (GameObject)Instantiate (LEVELONEPREFABS [4], position, Quaternion.identity);
					isTileCreated=true;
				}
			}
			}
		}
		
		// 1st Tile Static Placement..
		if (isFirstTile) {
			int BACKRESTRICKT=PlayerPrefs.GetInt("BACKRESTRICKT");
			if(BACKRESTRICKT == 100)
			{
				Vector3 backRestrictposition = position;
				backRestrictposition.x = backRestrictposition.x ;
				backRestrictposition.y = backRestrictposition.y + randomDistancey;
				GameObject backRestrict = (GameObject)Instantiate (mygameobject, backRestrictposition, Quaternion.identity);
				BoxCollider backRestrictBoxCollider = backRestrict.AddComponent<BoxCollider> ();
				backRestrictBoxCollider.isTrigger = true;
				backRestrictBoxCollider.size = new Vector3 (4, 10, 4);
				backRestrict.tag = "BackRestrict";
			}
			isFirstTile = false;
			randomDistancex = 0;
			randomDistancey = 0;
			randomTile = 0;
			currentTile = (GameObject)Instantiate (LEVELONEPREFABS [0], position, Quaternion.identity);
			isTileCreated=true;
		}
		else if (gapCount % 6 == 0) {






//			if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI")) {
			if(!isTileCreated ){
					
					/*
				 * Distance (x,y) for  maintaing Tile Gap..
				 */
					
					
					
				if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI"))

				{

					randomDistancex = 0;
					randomDistancey = 0;
					
					randomTile = 0;
					Vector3 gameOverposition = position;
					gameOverposition.x = gameOverposition.x + (randomDistancex/2)+2;
					gameOverposition.y = gameOverposition.y - 10f;
					
					
					GameObject removeTilesObjs = (GameObject)Instantiate (mygameobject, position, Quaternion.identity);
					BoxCollider removeTilesObjsCollider = removeTilesObjs.AddComponent<BoxCollider> ();
					removeTilesObjsCollider.isTrigger = true;
					removeTilesObjsCollider.size = new Vector3 (0.003106713f, 75.98993f, 8.98942f);
					removeTilesObjsCollider.center=new Vector3 (0f, 12.86592f, 0f);
					removeTilesObjs.tag = "removetilesobjs";
					removeTilesObjs.name="REMOVE";
					/*
				 * GameOver Layer between platfoms gap..
				 */
					GameObject gameOver = (GameObject)Instantiate (mygameobject, gameOverposition, Quaternion.identity);
					BoxCollider gameOverBoxCollider = gameOver.AddComponent<BoxCollider> ();
					gameOverBoxCollider.isTrigger = true;
					gameOverBoxCollider.size = new Vector3 (randomDistancex +15, 0, 8.5f);
					gameOver.tag = "gameOver";


					/*
				 * HangingCube placement....
				 */
					
					Vector3 cubePosition = position;
					cubePosition.x = cubePosition.x + randomDistancex -1.0f;;
					cubePosition.y = cubePosition.y + randomDistancey -2.0f;
					GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
					cube.transform.position = cubePosition;
					cube.transform.localScale = new Vector3 (0.5f, 0.5f, 6);
					cube.tag = "HangingCube";
					BoxCollider collider=cube.GetComponent<BoxCollider>();
					collider.isTrigger = false;
					collider.size = new Vector3(1.5f,1.2f,1.5f);
					MeshRenderer meshRenderer = cube.GetComponent<MeshRenderer>();
					meshRenderer.enabled = false;


					/*
				 * BackRestriction for starting Tiles after gap..
				 */
					
					Vector3 backRestrictposition = position;
					backRestrictposition.x = backRestrictposition.x + randomDistancex;
					backRestrictposition.y = backRestrictposition.y + randomDistancey +5;
					GameObject backRestrict = (GameObject)Instantiate (mygameobject, backRestrictposition, Quaternion.identity);
					BoxCollider backRestrictBoxCollider = backRestrict.AddComponent<BoxCollider> ();
					backRestrictBoxCollider.isTrigger = true;
					if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI"))
						backRestrictBoxCollider.size = new Vector3 (4, 13, 4);
					else
						backRestrictBoxCollider.size = new Vector3 (4, 53, 4);
					backRestrict.tag = "BackRestrict";
					backRestrict.name="BackRestrict";

				}
					
					
					
					

				}
			}
//		}
		
		position.x = position.x + randomDistancex;
		position.y = position.y + randomDistancey;
		if (prevRandomTile == randomTile) {
			randomTile = randomTile + 1;
			if(randomTile>=LEVELONEPREFABS.Length){
				randomTile = 8;
			}
		}
		prevRandomTile = randomTile;
//		randomTile = 0;
		if(randomTile == 1){
			randomTile=randomTile+1;
		}
		
		/*
		 * @@@@ DYNAMIC CREATION OF TILES @@@@
		 */
		
		
		if (!isTileCreated) {
			currentTile = (GameObject)Instantiate (LEVELONEPREFABS [randomTile], position, Quaternion.identity);
		}
		
		// DAIMONDS DISPLY...
		
		if (PlayerPrefs.GetInt ("Diamond_Display__Int") == 0) {
			Diamond_Display__Int = Random.Range (1, 5);
			PlayerPrefs.SetInt ("Diamond_Display__Int", Diamond_Display__Int);
		} else {
			Diamond_Display__Int=PlayerPrefs.GetInt ("Diamond_Display__Int");
		}
		
		//		Debug.Log ("Diamond_Display__Int : "+Diamond_Display__Int);
		
		if(FIGHTTAG == 0  && Diamond_Display__Int == 0)
			
		{
			if(gapCount == 8){
				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			}
			
		}
		else if(FIGHTTAG == 1 && Diamond_Display__Int ==1)
			
		{
			if(gapCount == 10){
				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			}
		}else if(FIGHTTAG == 2 && Diamond_Display__Int ==2)
			
		{
			//			if(gapCount == 8){
			//				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			//			}
			
			if(gapCount == 25){
				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			}
		}else if(FIGHTTAG == 3 && Diamond_Display__Int ==3)
			
		{
			//			if(gapCount == 8){
			//				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			//			}
			if(gapCount == 16){
				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			}
			//			if(gapCount == 25){
			//				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			//			}
		}else if(FIGHTTAG == 4 && Diamond_Display__Int ==4)
			
		{
			//			if(gapCount == 8){
			//				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			//			}
			//			if(gapCount == 16){
			//				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			//			}
			if(gapCount == 20){
				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			}
			//			if(gapCount == 26){
			//				currentTile.transform.GetChild(2).gameObject.SetActive(true);
			//			}
		}
		
		
		
		/*
		 * Adding all tiles to array to remove while Hanman falling  from platforms..
		 */
		AddPrevious (currentTile);
		
		if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI")) {
			currentTile.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		}
		Rigidbody gameObjectsRigidBody = currentTile.AddComponent<Rigidbody> ();
		gameObjectsRigidBody.interpolation = RigidbodyInterpolation.Interpolate;
		gameObjectsRigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		gameObjectsRigidBody.mass = 0.1f;
		gameObjectsRigidBody.constraints = RigidbodyConstraints.FreezeAll;
		if(gameObjectsRigidBody != null)
			gameObjectsRigidBody.isKinematic = true;
		currentTile.AddComponent<TileScript> ();
		
		
		
		if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI")) {
			/*
		 *  Power Up Creation ...
		 */
			if (randomTile == 13 || randomTile == 14) {
				Transform[] ts = currentTile.transform.GetComponentsInChildren<Transform> (true);
				foreach (Transform t in ts) {
					if (t.gameObject.name == "Gift_Box_Prefab") {
						PowerUps (new Vector3 (t.gameObject.transform.position.x + 0.3f, t.gameObject.transform.position.y + 1f, t.gameObject.transform.position.z));
						t.gameObject.SetActive (false);
					}
				}
			}
			
			
			/*
		 *  Adding Background TEMPLES to Tiles...
		 */
			if ("enemy1(Clone)" == currentTile.transform.name.ToString () || "XMovingPlatPrefabSmall(Clone)" == currentTile.transform.name.ToString ()
			    || "Wodden_Bridge_Prefab(Clone)" == currentTile.transform.name.ToString () || "RotatePlatPrefab(Clone)" == currentTile.transform.name.ToString ()
			    || "Combi3_plat_Prefab 2(Clone)" == currentTile.transform.name.ToString ()) {
				IstransformError = true;
			}
			
			if (!IstransformError) {
				int random = Random.Range (0, 3);
				try {
					currentTile.transform.GetChild (1).GetChild (random).gameObject.SetActive (true);
				} catch {
					//					Debug.Log (gapCount + " GAP " + currentTile.transform.name);
				}
			} else {
				IstransformError = false;
			}
		}
		else if(PlayerPrefs.GetString ("LEVEL").Equals ("LEVELII")){


			if ("Branch3_prefab(Clone)" == currentTile.transform.name.ToString ()||"land5_Treasure_prefab(Clone)" == currentTile.transform.name.ToString ()){
				
				Transform[] ts = currentTile.transform.GetComponentsInChildren<Transform> (true);
				foreach (Transform t in ts) {
					if (t.gameObject.name == "Gift_Box_Prefab") {
						PowerUps (new Vector3 (t.gameObject.transform.position.x + 0.3f, t.gameObject.transform.position.y + 1f, t.gameObject.transform.position.z));
						t.gameObject.SetActive (false);
					}
				}
				
			}
		}
		else if(PlayerPrefs.GetString ("LEVEL").Equals ("LEVELIII")){

			// Random COIN GENERATION  && DYNAMIC ENEMY REPREGENTATION
			Transform[] ts2 = currentTile.transform.GetComponentsInChildren<Transform> (true);
			foreach (Transform t in ts2) {
				if (t.gameObject.name == "coin1") {
					StartCoroutine(CoinGeneration(new Vector3 (t.gameObject.transform.position.x + 0.3f, t.gameObject.transform.position.y + 1f, t.gameObject.transform.position.z)));
					t.gameObject.SetActive (false);

				}
				if(t.gameObject.name == "randomEnemyCreation")
				{
					StartCoroutine(level3Enemy (new Vector3 (t.gameObject.transform.position.x + 5f, t.gameObject.transform.position.y, t.gameObject.transform.position.z)));
					t.gameObject.SetActive (false);
				}
				if(t.gameObject.name == "bat1")
				{
					StartCoroutine(batcreation(t.transform));
					t.gameObject.SetActive (false);
				}
			}


			if ("ST1_prefab(Clone)" == currentTile.transform.name.ToString () || "P1_prefab(Clone)" == currentTile.transform.name.ToString ()){
				
				Transform[] ts = currentTile.transform.GetComponentsInChildren<Transform> (true);
				foreach (Transform t in ts) {
					if (t.gameObject.name == "Gift_Box_Prefab") {
						PowerUps (new Vector3 (t.gameObject.transform.position.x + 0.3f, t.gameObject.transform.position.y + 1f, t.gameObject.transform.position.z));
						t.gameObject.SetActive (false);
					}
				}
				
			}
		}

//		Transform[] ts5 = currentTile.transform.GetComponentsInChildren<Transform> (true);
//		foreach (Transform t in ts5) {
//			if (t.gameObject.name == "new_wall") {
//				Mesh mesh=t.GetComponent<MeshFilter>().sharedMesh;
//				DestroyImmediate(mesh,true);
//			}
//		}




	}

	IEnumerator CoinGeneration (Vector3 objPosition)
	{
		yield return new WaitForSeconds (0.1f);
		GameObject coinObj = (GameObject)Instantiate (OverheadBox, objPosition, Quaternion.identity);
		coinObj.gameObject.transform.SetParent (currentTile.transform);
	}

	public void  AddPrevious(GameObject t){
		TotalTilesFinal.Add (currentTile);
	}
	private IEnumerator batcreation (Transform point){
		powerUpObj = (GameObject)Instantiate (bat_anim_obj,point.position,Quaternion.Euler(0,180,0));
		powerUpObj.gameObject.transform.SetParent (currentTile.transform);
		yield return null;
	}
	
}

