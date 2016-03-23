using UnityEngine;
using System;
using System.Collections;

public class BattleGUI : UFEScreen {
	#region public class definitions
	[Serializable]
	public class PlayerInfo{
		public CharacterInfo character;
		public float targetLife;
		public float totalLife;
		public int wonRounds;
	}
	#endregion
	[HideInInspector] public static bool pauseOnce = false;

	#region protected instance properties
	protected PlayerInfo player1 = new PlayerInfo();
	protected PlayerInfo player2 = new PlayerInfo();
	protected bool isRunning;
	#endregion

	#region public override methods
	public override void DoFixedUpdate(){
		base.DoFixedUpdate ();
	}

	public override void OnShow (){
		base.OnShow ();

		/* Subscribe to UFE events:
		/* Possible Events:
		 * OnLifePointsChange(float newLifePoints, CharacterInfo player)
		 * OnNewAlert(string alertMessage, CharacterInfo player)
		 * OnHit(MoveInfo move, CharacterInfo hitter)
		 * OnMove(MoveInfo move, CharacterInfo player)
		 * OnRoundEnds(CharacterInfo winner, CharacterInfo loser)
		 * OnRoundBegins(int roundNumber)
		 * OnGameEnds(CharacterInfo winner, CharacterInfo loser)
		 * OnGameBegins(CharacterInfo player1, CharacterInfo player2, StageOptions stage)
		 * 
		 * usage:
		 * UFE.OnMove += YourFunctionHere;
		 * .
		 * .
		 * void YourFunctionHere(T param1, T param2){...}
		 * 
		 * The following code bellow show more usage examples
		 */

		UFE.OnGameBegin += this.OnGameBegin;
		UFE.OnGameEnds += this.OnGameEnd;
		UFE.OnGamePaused += this.OnGamePaused;
		UFE.OnRoundBegins += this.OnRoundBegin;
		UFE.OnRoundEnds += this.OnRoundEnd;
		UFE.OnLifePointsChange += this.OnLifePointsChange;
		UFE.OnNewAlert += this.OnNewAlert;
		UFE.OnHit += this.OnHit;
		UFE.OnMove += this.OnMove;
		UFE.OnTimer += this.OnTimer;
		UFE.OnTimeOver += this.OnTimeOver;
		UFE.OnInput += this.OnInput;
	}

	public override void OnHide (){
		UFE.OnGameBegin -= this.OnGameBegin;
		UFE.OnGameEnds -= this.OnGameEnd;
		UFE.OnGamePaused -= this.OnGamePaused;
		UFE.OnRoundBegins -= this.OnRoundBegin;
		UFE.OnRoundEnds -= this.OnRoundEnd;
		UFE.OnLifePointsChange -= this.OnLifePointsChange;
		UFE.OnNewAlert -= this.OnNewAlert;
		UFE.OnHit -= this.OnHit;
		UFE.OnMove -= this.OnMove;
		UFE.OnTimer -= this.OnTimer;
		UFE.OnTimeOver -= this.OnTimeOver;
		UFE.OnInput -= this.OnInput;

		base.OnHide ();
	}
	#endregion

	#region protected instance methods
	protected virtual void OnGameBegin(CharacterInfo player1, CharacterInfo player2, StageOptions stage){
		this.player1.character = player1;
		UFE.updatedLifePoints = UFE.config.player1Character.currentLifePoints;
//
//		if (UFE.lifepointsCheck == true) {
//			this.player1.targetLife = UFE.updatedLifePoints;
//			this.player1.totalLife = 500.0f;
//		} else {
			this.player1.targetLife = PlayerPrefs.GetFloat ("HEALTH");
			this.player1.totalLife = 500.0f;
//		}
		this.player1.wonRounds = 0;
		
		this.player2.character = player2;
		this.player2.targetLife = player2.lifePoints;
		this.player2.totalLife = player2.lifePoints;
		this.player2.wonRounds = 0;
		
		UFE.PlayMusic(stage.music);
		this.isRunning = true;

// making application pause to show popups for buying weapons

		if (IntroScreen.characterValue == 2 || IntroScreen.characterValue == 3 || IntroScreen.characterValue == 4 || IntroScreen.characterValue == 5 || IntroScreen.characterValue <= 13 || IntroScreen.characterValue == 18 || IntroScreen.characterValue == 19 || IntroScreen.characterValue == 20 || IntroScreen.characterValue == 21) {
			Invoke ("pauseFn", 5f);
		}
		else {
		}
	}
	void Update()
	{
		if (pauseOnce == true) {
			Debug.Log("cancelinvoke");
		}
	}
	void pauseFn()
	{
		pauseOnce = true;
		UFE.PauseGame (true);
	}
	protected virtual void OnGameEnd(CharacterInfo winner, CharacterInfo loser){
		this.isRunning = false;
		if (UFE.gameMode == GameMode.VersusMode){
			UFE.updatedLifePoints = UFE.config.player1Character.currentLifePoints;
			string level_fgt = PlayerPrefs.GetString("LEVEL");
			if(winner == this.player1.character)
			{
				// HANUMAN
				PlayerPrefs.SetInt ("FIGHTTAGBOOL", 200);
				int Fightabc=PlayerPrefs.GetInt ("FIGHTTAG");
				if(Fightabc == 3 && level_fgt.Equals("LEVELII"))
				{
					PlayerPrefs.SetInt("LankiniFight",3);
				}
				else if(Fightabc == 4 && level_fgt.Equals("LEVELII")){
					PlayerPrefs.SetInt("LankiniFight",2);
				}
				else if(Fightabc == 1 && level_fgt.Equals("LEVELIII"))
				{
					PlayerPrefs.SetInt("LankiniFight",4);
				}
				else{
					PlayerPrefs.SetInt("LankiniFight",0);
				}

				Fightabc=Fightabc+1;
				if(Fightabc == 5)
				{
					PlayerPrefs.SetString("LEVEL","LEVELII");
					PlayerPrefs.SetInt ("FIGHTTAG", 0);
				}else{
				TileManager.FIGHTTAG=Fightabc;
				PlayerPrefs.SetInt ("FIGHTTAG", TileManager.FIGHTTAG);
				}
				
				
			}else{
				// SKELETON
				
				PlayerPrefs.SetInt ("FIGHTTAGBOOL", 100);
				int Fightabc2=PlayerPrefs.GetInt ("FIGHTTAG");
				if(Fightabc2 == 4 && level_fgt.Equals("LEVELII"))
				{
					PlayerPrefs.SetInt("LankiniFight",1);
				}
				else{
					PlayerPrefs.SetInt("LankiniFight",0);
				}
				TileManager.FIGHTTAG=Fightabc2;
				PlayerPrefs.SetInt ("FIGHTTAG", TileManager.FIGHTTAG);
				
				
			}
			float Lankacount=PlayerPrefs.GetFloat ("AIMIII");
			if (PlayerPrefs.GetString ("LEVEL").Equals ("LEVELI"))
			{
			Lankacount=(Lankacount/4f);
			}
			else if(PlayerPrefs.GetString ("LEVEL").Equals("LEVELII") || PlayerPrefs.GetString ("LEVEL").Equals("LEVELIII")){
				Lankacount=(Lankacount/2f);
			}
			
			PlayerPrefs.SetFloat("enemyDistance",Lankacount);
			PlayerPrefs.SetFloat ("HEALTH", UFE.updatedLifePoints );
			UFE.StartVersusModeAfterBattleScreen();
		}else if (UFE.gameMode == GameMode.StoryMode){
			if (winner == this.player1.character){
				UFE.WonStoryModeBattle();
			}else{
				UFE.StartStoryModeContinueScreen();
			}
		}else{
			UFE.StartMainMenuScreen();
		}
	}

	protected virtual void OnGamePaused(bool isPaused){

	}

	protected virtual void OnRoundBegin(int roundNumber){

	}

	protected virtual void OnRoundEnd(CharacterInfo winner, CharacterInfo loser){
		// TODO: we should use the player number instead of the character info because both players could use the same character
		//++this.player1WonRounds;
		//++this.playe21WonRounds;
	}

	protected virtual void OnLifePointsChange(float newFloat, CharacterInfo player){
		// You can use this to have your own custom events when a player's life points changes
		// TODO: we should use the player number instead of the character info because both players could use the same character
	}

	protected virtual void OnNewAlert(string msg, CharacterInfo player){
		// You can use this to have your own custom events when a new text alert is fired from the engine
		// TODO: we should use the player number instead of the character info because both players could use the same character
	}

	protected virtual void OnHit(HitBox strokeHitBox, MoveInfo move, CharacterInfo player){
		// You can use this to have your own custom events when a character gets hit
		// TODO: we should use the player number instead of the character info because both players could use the same character
	}

	protected virtual void OnMove(MoveInfo move, CharacterInfo player){
		// Fires when a player successfully executes a move
	}

	protected virtual void OnTimer(float time){

	}

	protected virtual void OnTimeOver(){
		
	}

	protected virtual void OnInput(InputReferences[] inputReferences, int player){

	}
	#endregion
}
