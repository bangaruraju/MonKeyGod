using UnityEngine;
using System.Collections;
using System.Threading;

public class Manager_Two : MonoBehaviour {
	public GameObject currentTile;
	private Vector3 position;
	private bool Tilecreation2=false;
	private bool isTileCreated=false;
	public GameObject[] BackGround_NewTilePrefab;

	// Use this for initialization
	void Start () {
	
		for(int i=0;i<2;i++){
			BackGSpawnTile();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	private void  PathCreation2(){
//		Tilecreation2 = true;
//	}

	void FixedUpdate(){
		if(Tilecreation2){
			BackGSpawnTile();
			Tilecreation2 = false;
		}
		
	}
	public ArrayList BackGroundleftTilesFinal = new ArrayList ();
	void BackGSpawnTile(){
		position = currentTile.transform.GetChild (0).transform.GetChild (0).position;
		isTileCreated = true;
		currentTile = (GameObject)Instantiate (BackGround_NewTilePrefab [0], position, Quaternion.identity);
		StartCoroutine(AddPrevious(currentTile));
	}
	IEnumerator FallDown(GameObject obj){
		
		yield return new WaitForSeconds (1f);
		
		DestroyObject (obj);
		
	}

	IEnumerator AddPrevious(GameObject t){
		yield return new WaitForSeconds(1f);
		BackGroundleftTilesFinal.Add (t);

	}

	void OnCollisionEnter(Collision collision) {



	}


	void OnTriggerEnter(Collider other){

		if(other.transform.tag == "removetilesobjsBack"){
			//				if(TileManager.Instance.leftTilesFinal.Count == 6){
			
			for(int i =BackGroundleftTilesFinal.Count -1 ; i>=0 ; i--){
				GameObject go=(GameObject)BackGroundleftTilesFinal[i];
				BackGroundleftTilesFinal.RemoveAt(i);
				//						DestroyObject(go);
				StartCoroutine(FallDown(go));
			}
			//				}
		}
		


	}
}
