using UnityEngine;
using System.Collections;
using System.Threading;
using System;
using System.Collections.Generic;

public class TileScript : MonoBehaviour {
//	private float fallDelay=50f;
	private float fallDelay2=0f;
	public static bool RUNENERGY=false;
//	public static bool HEALTH = false;
	public GameObject ps;
//	private Thread main_Thread = null;

	// Use this for initialization
//	void Start () {
//
//	}
	private void Run()
	{
		PathCreation ();
	}
//	void Awake(){
//
//
//	}
	public static int ThreadINT=0;
	
	// Update is called once per frame
//	void Update () {

//		if(Tilecreation){
//			ThreadINT=ThreadINT+1;
////			Debug.Log("$$$$$$$$$$$$$$$$$$$$$$$$   "+ThreadINT+"   $$$$$$$$$$$$$$$$$$");
//			if(ThreadINT ==2)
//			{
//				ThreadINT=0;
//				TileManager.Instance.SpawnTile();
//			}
//			Tilecreation = false;
//		}

//	}
	public static  int RUNENERGYCOUNT=0;
	void OnTriggerEnter(Collider other){

		try{
			if (other.tag == "Dynamic") {
				//			Debug.Log("PLAYER");
				//			Debug.Log (other.tag);
				if(RUNENERGYCOUNT == 0)
				{
					RUNENERGY = true;
					
				}
				else
					RUNENERGY = false;
			}
		}
		catch{
		}

	}
	private bool Tilecreation = false;
	private void  PathCreation(){
		Tilecreation = true;
	}

	void OnTriggerExit(Collider other){
		RUNENERGYCOUNT=0;

	}
	
	IEnumerator Display(){
		yield return new WaitForSeconds (fallDelay2);
		Instantiate(ps,transform.position,Quaternion.identity);
	}

}
